namespace KafahStore
{
    partial class frmPenjualan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.PenjualanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KafahStoreDb = new KafahStore.KafahStoreDb();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.PenjualanAdapter = new KafahStore.KafahStoreDbTableAdapters.m_penjualanTableAdapter();
            this.BarangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BarangAdapter = new KafahStore.KafahStoreDbTableAdapters.m_barangTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbarangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pembeliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bulanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahunDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KafahStoreDb)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.idbarangDataGridViewTextBoxColumn,
            this.clmHarga,
            this.nama_barang,
            this.tglDataGridViewTextBoxColumn,
            this.pembeliDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.bulanDataGridViewTextBoxColumn,
            this.tahunDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.PenjualanBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(516, 350);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            // 
            // PenjualanBindingSource
            // 
            this.PenjualanBindingSource.DataMember = "m_penjualan";
            this.PenjualanBindingSource.DataSource = this.KafahStoreDb;
            // 
            // KafahStoreDb
            // 
            this.KafahStoreDb.DataSetName = "KafahStoreDb";
            this.KafahStoreDb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 405);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.dtp);
            this.tabMain.Controls.Add(this.dgv);
            this.tabMain.Controls.Add(this.btnUpdate);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(522, 379);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(136, 113);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(200, 20);
            this.dtp.TabIndex = 3;
            this.dtp.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(3, 353);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(516, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.rpt);
            this.tabReport.Controls.Add(this.grp);
            this.tabReport.Location = new System.Drawing.Point(4, 22);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(522, 379);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Report";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt.Location = new System.Drawing.Point(3, 51);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(516, 325);
            this.rpt.TabIndex = 1;
            // 
            // grp
            // 
            this.grp.Controls.Add(this.cboYear);
            this.grp.Controls.Add(this.btnShow);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(3, 3);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(516, 48);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            this.grp.Text = "Criteria";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(427, 15);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // PenjualanAdapter
            // 
            this.PenjualanAdapter.ClearBeforeFill = true;
            // 
            // BarangBindingSource
            // 
            this.BarangBindingSource.DataMember = "m_barang";
            this.BarangBindingSource.DataSource = this.KafahStoreDb;
            // 
            // BarangAdapter
            // 
            this.BarangAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // idbarangDataGridViewTextBoxColumn
            // 
            this.idbarangDataGridViewTextBoxColumn.DataPropertyName = "id_barang";
            this.idbarangDataGridViewTextBoxColumn.DataSource = this.BarangBindingSource;
            this.idbarangDataGridViewTextBoxColumn.DisplayMember = "nama";
            this.idbarangDataGridViewTextBoxColumn.HeaderText = "Barang";
            this.idbarangDataGridViewTextBoxColumn.Name = "idbarangDataGridViewTextBoxColumn";
            this.idbarangDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idbarangDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.idbarangDataGridViewTextBoxColumn.ValueMember = "id";
            // 
            // clmHarga
            // 
            this.clmHarga.DataPropertyName = "harga_barang";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.clmHarga.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmHarga.HeaderText = "Harga Barang";
            this.clmHarga.Name = "clmHarga";
            this.clmHarga.ReadOnly = true;
            // 
            // nama_barang
            // 
            this.nama_barang.DataPropertyName = "nama_barang";
            this.nama_barang.HeaderText = "Nama Barang";
            this.nama_barang.Name = "nama_barang";
            this.nama_barang.ReadOnly = true;
            // 
            // tglDataGridViewTextBoxColumn
            // 
            this.tglDataGridViewTextBoxColumn.DataPropertyName = "tgl";
            dataGridViewCellStyle6.Format = "yyyy-MM-dd";
            this.tglDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.tglDataGridViewTextBoxColumn.HeaderText = "Tanggal";
            this.tglDataGridViewTextBoxColumn.Name = "tglDataGridViewTextBoxColumn";
            // 
            // pembeliDataGridViewTextBoxColumn
            // 
            this.pembeliDataGridViewTextBoxColumn.DataPropertyName = "pembeli";
            this.pembeliDataGridViewTextBoxColumn.HeaderText = "Pembeli";
            this.pembeliDataGridViewTextBoxColumn.Name = "pembeliDataGridViewTextBoxColumn";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            dataGridViewCellStyle7.Format = "N0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "total";
            dataGridViewCellStyle8.Format = "N0";
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bulanDataGridViewTextBoxColumn
            // 
            this.bulanDataGridViewTextBoxColumn.DataPropertyName = "bulan";
            this.bulanDataGridViewTextBoxColumn.HeaderText = "Bulan";
            this.bulanDataGridViewTextBoxColumn.Name = "bulanDataGridViewTextBoxColumn";
            this.bulanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tahunDataGridViewTextBoxColumn
            // 
            this.tahunDataGridViewTextBoxColumn.DataPropertyName = "tahun";
            this.tahunDataGridViewTextBoxColumn.HeaderText = "Tahun";
            this.tahunDataGridViewTextBoxColumn.Name = "tahunDataGridViewTextBoxColumn";
            this.tahunDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "2018"});
            this.cboYear.Location = new System.Drawing.Point(6, 17);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 21);
            this.cboYear.TabIndex = 1;
            // 
            // frmPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 405);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmPenjualan";
            this.Text = "Penjualan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPenjualan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KafahStoreDb)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BarangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtp;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Button btnShow;
        private KafahStoreDb KafahStoreDb;
        private System.Windows.Forms.BindingSource PenjualanBindingSource;
        private KafahStoreDbTableAdapters.m_penjualanTableAdapter PenjualanAdapter;
        private System.Windows.Forms.BindingSource BarangBindingSource;
        private KafahStoreDbTableAdapters.m_barangTableAdapter BarangAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idbarangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_barang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pembeliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bulanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahunDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cboYear;
    }
}