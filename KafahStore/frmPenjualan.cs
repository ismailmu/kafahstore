using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace KafahStore
{
    public partial class frmPenjualan : Form
    {
        public frmPenjualan()
        {
            InitializeComponent();
        }

        private void frmPenjualan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KafahStoreDb.m_barang' table. You can move, or remove it, as needed.
            this.BarangAdapter.Fill(this.KafahStoreDb.m_barang);
            // TODO: This line of code loads data into the 'kafahStoreDb.m_penjualan' table. You can move, or remove it, as needed.
            this.PenjualanAdapter.Fill(this.KafahStoreDb.m_penjualan);

            SetCriteria();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dtp = new DateTimePicker();
                dtp.Format = DateTimePickerFormat.Short;
                //dtp.Value = DateTime.Now;
                //setBulanTahun();

                dgv.Controls.Add(dtp);

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                dtp.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                dtp.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                dtp.CloseUp -= dtp_CloseUp;
                dtp.CloseUp += dtp_CloseUp;

                // An event attached to dateTimePicker Control which is fired when any date is selected 
                dtp.TextChanged -= dtp_OnTextChange;
                dtp.TextChanged += dtp_OnTextChange;    

                dtp.Visible = true;

            }
        }

        private void setBulanTahun(DateTime dt)
        {
            object objRow = dgv.CurrentRow.Index;
            
            if (objRow != null)
            {
                int rowPos = (int)objRow;

                dgv[8, rowPos].Value = dt.Month.ToString();
                dgv[9, rowPos].Value = dt.Year.ToString();
            }
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            object objRow = dgv.CurrentRow.Index;

            if (objRow != null)
            {
                int rowPos = (int)objRow;
                DateTimePicker dtp = (DateTimePicker)sender;
                dgv[4, rowPos].Value = dtp.Value;
                setBulanTahun(dtp.Value);
            }
        }

        private void dtp_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            dtp.Visible = false;
        }

        private void SetTotal(int harga, int qty, int rowPos)
        {
            int total = harga * qty;
            dgv[7, rowPos].Value = total;
        }

        private void cboBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            if (cbo.SelectedValue == null)
            {
                return;
            }
            int idBarang;
            bool isInt = int.TryParse(cbo.SelectedValue.ToString(), out idBarang);
            if (!isInt)
            {
                return;
            }

            string sql = String.Format("SELECT nama,harga_jual FROM m_barang where id={0}", idBarang);
            DataTable dt = MyUtil.ExecuteReader(sql);

            object objRow = dgv.CurrentRow.Index;

            if (objRow != null && dt.Rows.Count > 0)
            {
                int rowPos = (int)objRow;
                string nama = dt.Rows[0][0].ToString();
                int harga = (int)dt.Rows[0][1];

                dgv[3, rowPos].Value = nama;
                dgv[2, rowPos].Value = harga;
                string strQty = dgv[6, rowPos].Value.ToString();
                if (strQty == String.Empty)
                {
                    strQty = "1";
                    dgv[6, rowPos].Value = strQty;
                }
                SetTotal(harga, Int32.Parse(strQty), rowPos);
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            int rowPos = dgv.CurrentRow.Index;

            string harga = dgv[2, rowPos].Value.ToString();
            harga = harga.Replace(".", String.Empty);
            harga = harga.Replace(",", String.Empty);

            TextBox txt = (TextBox)sender;
            SetTotal(Int32.Parse(harga), Int32.Parse(txt.Text), rowPos);
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;

                comboBox.SelectedIndexChanged -= cboBarang_SelectedIndexChanged;
                comboBox.SelectedIndexChanged += cboBarang_SelectedIndexChanged;
            }

            if (dgv.CurrentCell.ColumnIndex == 6)
            {
                TextBox txt = e.Control as TextBox;
                txt.KeyPress -= txt_KeyPress;
                txt.KeyPress += txt_KeyPress;

                txt.Leave -= txt_Leave;
                txt.Leave += txt_Leave;
            }
        }

        private void SetCriteria()
        {
            DataTable dt = MyUtil.ExecuteReader("select distinct tahun from m_penjualan order by tahun desc");

            cboYear.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboYear.Items.Add(dt.Rows[0][0].ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.PenjualanAdapter.Update(this.KafahStoreDb.m_penjualan);
                this.PenjualanAdapter.Fill(this.KafahStoreDb.m_penjualan);
                SetCriteria();
                dgv.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboYear.SelectedIndex <= -1)
                {
                    MessageBox.Show("Pilih criteria tahun terlebih dahulu");
                    return;
                }


                string myAppPath = Path.GetDirectoryName(Application.ExecutablePath);

                rpt.ProcessingMode = ProcessingMode.Local;
                LocalReport localReport = rpt.LocalReport;

                localReport.EnableExternalImages = true;

                localReport.ReportPath = @"REPORT\RptPenjualan.rdlc"; //String.Format(@"{0}\{1}\{2}", myAppPath, Properties.Settings.Default.report_path,"RptBarang.rdlc");
                string sql = String.Format("SELECT * FROM m_penjualan WHERE tahun='{0}' order by tgl", cboYear.SelectedItem.ToString());
                DataSet dstPenjualan = MyUtil.ExecuteReader(sql, "dstPenjualan", "m_penjualan");

                ReportDataSource dsPenjualan = new ReportDataSource("dsPenjualan");
                dsPenjualan.Value = dstPenjualan.Tables["m_penjualan"];

                localReport.DataSources.Clear();
                localReport.DataSources.Add(dsPenjualan);

                ReportParameter prmImage = new ReportParameter();
                prmImage.Name = "ImagePath";
                prmImage.Values.Add(String.Format(@"{0}\{1}", myAppPath, Properties.Settings.Default.image_path));

                ReportParameter prmYear = new ReportParameter();
                prmYear.Name = "Year";
                prmYear.Values.Add(cboYear.SelectedItem.ToString());

                localReport.SetParameters(new ReportParameter[] { prmImage, prmYear });

                localReport.DisplayName = "Penjualan";
                rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }//end class
}//end namespace