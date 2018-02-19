using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace KafahStore
{
    public partial class frmBarang : Form
    {
        private static int flag = 0; //insert
        private const string IMG_FILTER = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
        
        public frmBarang()
        {
            InitializeComponent();
        }

        private void txtBeli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtBeli_Leave(object sender, EventArgs e)
        {
            txtBeli.Text = MyUtil.GetFormatNumber(txtBeli.Text);
        }

        private void txtJual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtJual_Leave(object sender, EventArgs e)
        {

            txtJual.Text = MyUtil.GetFormatNumber(txtJual.Text);
        }

        private void txtBerat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtBerat_Leave(object sender, EventArgs e)
        {
            txtBerat.Text = MyUtil.GetFormatNumber(txtBerat.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strVal = String.Empty;
            string id = txtId.Text.Trim();

            foreach ( TextBox tb in this.panel1.Controls.OfType<TextBox>())
            {
                if (tb.Name == "txtGbr2" || tb.Name == "txtGbr3" || tb.Name == "txtGbr4" || (flag == 0 && tb.Name=="txtId") )
                {
                    continue;
                }

                if (tb.Text.Trim() == String.Empty)
                {
                    strVal += String.Format("{0} harus diisi \r\n", tb.Tag);
                }
            }

            string sql = String.Format("SELECT nama from m_barang where nama='{0}'", txtNama.Text);
            string nama = MyUtil.ExecuteScalar(sql);
            if (flag == 0) //insert
            {
                if (nama.Trim().Length > 0)
                {
                    strVal += String.Format("{0} sudah ada, harus isi yang unik\r\n", txtNama.Text);
                }
            }
            else //update
            {
                sql = String.Format("SELECT nama from m_barang where id={0}", id);
                string namaOld = MyUtil.ExecuteScalar(sql);

                if (txtNama.Text.Trim().ToLower() != namaOld.ToLower())
                {
                    if (nama.Trim().Length > 0)
                    {
                        strVal += String.Format("{0} sudah ada, harus isi yang unik\r\n", txtNama.Text);
                    }
                }
            }

            if (strVal != String.Empty)
            {
                MessageBox.Show(strVal, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus();
                return;
            }
            try
            {
                sql = String.Empty;

                nama = txtNama.Text.Trim();
                string beli = txtBeli.Text.Trim();
                beli = beli.Replace(",", "");
                beli = beli.Replace(".", "");

                string jual = txtJual.Text.Trim();
                jual = jual.Replace(",", "");
                jual = jual.Replace(".", "");
                string satuan = txtSatuan.Text.Trim();
                string berat = txtBerat.Text.Trim();
                berat = berat.Replace(",", "");
                berat = berat.Replace(".", "");
                string unit = cboUnit.SelectedItem.ToString();

                string gbr1 = txtGbr1.Text;
                string gbr2 = txtGbr2.Text;
                string gbr3 = txtGbr3.Text;
                string gbr4 = txtGbr4.Text;

                string ket = txtKet.Text.Trim();
                string ket_1 = String.Empty;
                string ket_2 = String.Empty;
                string ket_3 = String.Empty;

                if (ket.Length > MyUtil.MAX_FIELD_LENGTH)
                {
                    ket_1 = ket.Substring(MyUtil.MAX_FIELD_LENGTH);
                }

                if (ket_1.Length > MyUtil.MAX_FIELD_LENGTH)
                {
                    ket_2 = ket_1.Substring(MyUtil.MAX_FIELD_LENGTH);
                    ket_1 = ket_1.Substring(0, MyUtil.MAX_FIELD_LENGTH);
                }

                if (ket_2.Length > MyUtil.MAX_FIELD_LENGTH)
                {
                    ket_3 = ket_2.Substring(MyUtil.MAX_FIELD_LENGTH);
                    ket_2 = ket_2.Substring(0, MyUtil.MAX_FIELD_LENGTH);
                }


                ket = ket.Substring(0, MyUtil.MAX_FIELD_LENGTH);

                if (flag == 0)
                {
                    sql = "INSERT INTO m_barang (";
                    sql += "nama,harga_beli,harga_jual,satuan,berat";
                    sql += ",unit,keterangan,gambar_1,gambar_2,gambar_3,gambar_4,keterangan_1,keterangan_2,keterangan_3) values (";
                    sql += "'{0}',{1},{2},'{3}',{4}";
                    sql += ",'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')";

                    gbr1 = MyUtil.SaveImage(gbr1, nama.Trim(), "1");
                    gbr2 = MyUtil.SaveImage(gbr2, nama.Trim(), "2");
                    gbr3 = MyUtil.SaveImage(gbr3, nama.Trim(), "3");
                    gbr4 = MyUtil.SaveImage(gbr4, nama.Trim(), "4");

                    sql = String.Format(sql, nama.Trim(), beli, jual, satuan.Trim(), berat, unit, ket.Trim(), gbr1, gbr2, gbr3, gbr4, ket_1.Trim(), ket_2.Trim(), ket_3.Trim());
                }
                else
                {
                    sql = "UPDATE m_barang ";
                    sql += "set nama='{0}',harga_beli={1},harga_jual={2},satuan='{3}',berat={4},unit='{5}',keterangan='{6}'";
                    sql = String.Format(sql, nama.Trim(), beli, jual, satuan.Trim(), berat, unit, ket.Trim());

                    gbr1 = MyUtil.SaveImage(gbr1, nama.Trim(), "1", id);
                    gbr2 = MyUtil.SaveImage(gbr2, nama.Trim(), "2", id);
                    gbr3 = MyUtil.SaveImage(gbr3, nama.Trim(), "3", id);
                    gbr4 = MyUtil.SaveImage(gbr4, nama.Trim(), "4", id);

                    if (gbr1 != MyUtil.IMG_UPDATE)
                    {
                        sql += ",gambar_1='" + gbr1 + "'";
                    }

                    if (gbr2 != MyUtil.IMG_UPDATE)
                    {
                        sql += ",gambar_2='" + gbr2 + "'";
                    }

                    if (gbr3 != MyUtil.IMG_UPDATE)
                    {
                        sql += ",gambar_3='" + gbr3 + "'";
                    }


                    if (gbr4 != MyUtil.IMG_UPDATE)
                    {
                        sql += ",gambar_4='" + gbr4 + "'";
                    }

                    sql += ",keterangan_1='{0}',keterangan_2='{1}',keterangan_3='{2}'";
                    sql += " WHERE id={3}";

                    sql = String.Format(sql, ket_1.Trim(), ket_2.Trim(), ket_3.Trim(), id);
                }

                MyUtil.ExecuteNonQuery(sql);
                MessageBox.Show("Save Sukses", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnCancel.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBarang_Load(object sender, EventArgs e)
        {
            this.barangTableAdapter.Fill(this.kafahStoreDb.m_barang);
            cboUnit.SelectedIndex = 0;
            flag = 0; //insert
            txtBerat.Text = "1000";
            txtSatuan.Text = "1 pcs";
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.panel1.Controls.OfType<TextBox>())
            {
                tb.Text = String.Empty;
            }
            flag = 0; //insert
            txtBerat.Text = "1000";
            txtId.ReadOnly = false;
            txtId.Focus();
            this.barangTableAdapter.Fill(this.kafahStoreDb.m_barang);
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.CheckFileExists = true;
            open1.Title = "Pilih gambar";
            open1.Filter = IMG_FILTER;

            if (open1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtGbr1.Text = open1.FileName;
            }
            open1.Dispose();
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.CheckFileExists = true;
            open1.Title = "Pilih gambar";
            open1.Filter = IMG_FILTER;

            if (open1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtGbr2.Text = open1.FileName;
            }
            open1.Dispose();
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.CheckFileExists = true;
            open1.Title = "Pilih gambar";
            open1.Filter = IMG_FILTER;

            if (open1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtGbr3.Text = open1.FileName;
            }
            open1.Dispose();
        }

        private void btnGbr4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.CheckFileExists = true;
            open1.Title = "Pilih gambar";
            open1.Filter = IMG_FILTER;

            if (open1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtGbr4.Text = open1.FileName;
            }
            open1.Dispose();
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text.Trim().Length > 0)
            {
                this.UseWaitCursor = true;
                try
                {
                    string sql = String.Format("SELECT * FROM m_barang where id={0}", txtId.Text.Trim());
                    DataTable dt = MyUtil.ExecuteReader(sql);
                    if (dt.Rows.Count > 0)
                    {
                        flag = 1;//update
                        txtId.ReadOnly = true;
                        txtNama.Focus();

                        txtNama.Text = dt.Rows[0][1].ToString();
                        txtBeli.Text = MyUtil.GetFormatNumber(dt.Rows[0][2].ToString());
                        txtJual.Text = MyUtil.GetFormatNumber(dt.Rows[0][3].ToString());
                        txtSatuan.Text = dt.Rows[0][4].ToString();
                        txtBerat.Text = dt.Rows[0][5].ToString();
                        string unit = dt.Rows[0][6].ToString();
                        if (unit.ToLower() == "gram")
                        {
                            cboUnit.SelectedIndex = 0;
                        }
                        else
                        {
                            cboUnit.SelectedIndex = 1;
                        }

                        string gbr1 = dt.Rows[0][8].ToString();
                        txtGbr1.Text = (File.Exists(gbr1) || gbr1 == String.Empty) ? gbr1 : MyUtil.IMG_UPDATE;
                        string gbr2 = dt.Rows[0][9].ToString();
                        txtGbr2.Text = (File.Exists(gbr2) || gbr2 == String.Empty) ? gbr2 : MyUtil.IMG_UPDATE;
                        string gbr3 = dt.Rows[0][10].ToString();
                        txtGbr3.Text = (File.Exists(gbr3) || gbr3 == String.Empty) ? gbr3 : MyUtil.IMG_UPDATE;
                        string gbr4 = dt.Rows[0][11].ToString();
                        txtGbr4.Text = (File.Exists(gbr4) || gbr4 == String.Empty) ? gbr4 : MyUtil.IMG_UPDATE;

                        txtKet.Text = dt.Rows[0][7].ToString() + dt.Rows[0][12].ToString() + dt.Rows[0][13].ToString() + dt.Rows[0][14].ToString();
                    }
                    else
                    {
                        flag = 0;
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Find Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.UseWaitCursor = false;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNama_Leave(object sender, EventArgs e)
        {
            if (txtNama.Text.Trim().Length > 0)
            {
                txtNama.Text = MyUtil.AllowCharacter(txtNama.Text.Trim(),String.Empty);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string myAppPath = Path.GetDirectoryName(Application.ExecutablePath); 
               
                rpt.ProcessingMode = ProcessingMode.Local;
                LocalReport localReport = rpt.LocalReport;

                localReport.EnableExternalImages = true;

                localReport.ReportPath = @"REPORT\RptBarang.rdlc"; //String.Format(@"{0}\{1}\{2}", myAppPath, Properties.Settings.Default.report_path,"RptBarang.rdlc");
                DataSet dstBarang = MyUtil.ExecuteReader("SELECT * FROM m_barang order by nama", "dstBarang", "m_barang");

                ReportDataSource dsBarang = new ReportDataSource("dsBarang");
                dsBarang.Value = dstBarang.Tables["m_barang"];

                localReport.DataSources.Clear();
                localReport.DataSources.Add(dsBarang);

                ReportParameter prmImage = new ReportParameter();
                prmImage.Name = "ImagePath";
                prmImage.Values.Add(String.Format(@"{0}\{1}", myAppPath, Properties.Settings.Default.image_path));

                ReportParameter prmComplete = new ReportParameter();
                prmComplete.Name = "chkAll";
                prmComplete.Values.Add(chkAll.Checked.ToString());

                localReport.SetParameters(new ReportParameter[] { prmImage, prmComplete });

                localReport.DisplayName = "PriceList";
                rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }//end class
}//end namespace