namespace QLXeMay.View
{
    partial class ucThongKeBanTheoThang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThongKeBanTheoThang));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.lblTienBan = new DevExpress.XtraEditors.LabelControl();
            this.lblTienLai = new DevExpress.XtraEditors.LabelControl();
            this.lblTienNhap = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcDanhSachThongKe = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachThongKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lueLoaiThongKe = new DevExpress.XtraEditors.LookUpEdit();
            this.btnThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spedThang = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiThongKe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spedThang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnIn);
            this.panelControl1.Controls.Add(this.lblTienBan);
            this.panelControl1.Controls.Add(this.lblTienLai);
            this.panelControl1.Controls.Add(this.lblTienNhap);
            this.panelControl1.Controls.Add(this.lblSoLuong);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(209, 64);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(739, 460);
            this.panelControl1.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(488, 381);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(222, 64);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In danh sách";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lblTienBan
            // 
            this.lblTienBan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTienBan.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienBan.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTienBan.Location = new System.Drawing.Point(72, 409);
            this.lblTienBan.Name = "lblTienBan";
            this.lblTienBan.Size = new System.Drawing.Size(124, 19);
            this.lblTienBan.TabIndex = 9;
            this.lblTienBan.Text = "Tổng tiền bán: ";
            // 
            // lblTienLai
            // 
            this.lblTienLai.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTienLai.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienLai.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTienLai.Location = new System.Drawing.Point(72, 436);
            this.lblTienLai.Name = "lblTienLai";
            this.lblTienLai.Size = new System.Drawing.Size(114, 19);
            this.lblTienLai.TabIndex = 8;
            this.lblTienLai.Text = "Tổng tiền lãi: ";
            // 
            // lblTienNhap
            // 
            this.lblTienNhap.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTienNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNhap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTienNhap.Location = new System.Drawing.Point(72, 382);
            this.lblTienNhap.Name = "lblTienNhap";
            this.lblTienNhap.Size = new System.Drawing.Size(134, 19);
            this.lblTienNhap.TabIndex = 7;
            this.lblTienNhap.Text = "Tổng tiền nhập: ";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSoLuong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSoLuong.Location = new System.Drawing.Point(72, 355);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(126, 19);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Tổng số lượng: ";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gcDanhSachThongKe);
            this.groupControl1.Location = new System.Drawing.Point(29, 22);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(681, 327);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách";
            // 
            // gcDanhSachThongKe
            // 
            this.gcDanhSachThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachThongKe.Location = new System.Drawing.Point(2, 20);
            this.gcDanhSachThongKe.MainView = this.gvDanhSachThongKe;
            this.gcDanhSachThongKe.Name = "gcDanhSachThongKe";
            this.gcDanhSachThongKe.Size = new System.Drawing.Size(677, 305);
            this.gcDanhSachThongKe.TabIndex = 0;
            this.gcDanhSachThongKe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachThongKe});
            // 
            // gvDanhSachThongKe
            // 
            this.gvDanhSachThongKe.GridControl = this.gcDanhSachThongKe;
            this.gvDanhSachThongKe.Name = "gvDanhSachThongKe";
            this.gvDanhSachThongKe.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(948, 66);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(260, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(429, 29);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "THỐNG KÊ BÁN HÀNG THEO THÁNG";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(15, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(180, 23);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Chọn loại thống kê";
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl3.Controls.Add(this.lueLoaiThongKe);
            this.panelControl3.Controls.Add(this.btnThongKe);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.cboNam);
            this.panelControl3.Controls.Add(this.spedThang);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Location = new System.Drawing.Point(0, 64);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(211, 460);
            this.panelControl3.TabIndex = 2;
            // 
            // lueLoaiThongKe
            // 
            this.lueLoaiThongKe.Location = new System.Drawing.Point(37, 62);
            this.lueLoaiThongKe.Name = "lueLoaiThongKe";
            this.lueLoaiThongKe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLoaiThongKe.Properties.Appearance.Options.UseFont = true;
            this.lueLoaiThongKe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLoaiThongKe.Size = new System.Drawing.Size(136, 26);
            this.lueLoaiThongKe.TabIndex = 11;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Appearance.Options.UseFont = true;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.Location = new System.Drawing.Point(5, 337);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(198, 73);
            this.btnThongKe.TabIndex = 10;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(37, 228);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(96, 23);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Chọn năm";
            // 
            // cboNam
            // 
            this.cboNam.Location = new System.Drawing.Point(37, 266);
            this.cboNam.Name = "cboNam";
            this.cboNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.Properties.Appearance.Options.UseFont = true;
            this.cboNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNam.Size = new System.Drawing.Size(136, 26);
            this.cboNam.TabIndex = 8;
            // 
            // spedThang
            // 
            this.spedThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.spedThang.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spedThang.Location = new System.Drawing.Point(37, 162);
            this.spedThang.Name = "spedThang";
            this.spedThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spedThang.Properties.Appearance.Options.UseFont = true;
            this.spedThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spedThang.Properties.Mask.EditMask = "d";
            this.spedThang.Properties.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.spedThang.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spedThang.Size = new System.Drawing.Size(136, 26);
            this.spedThang.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(37, 124);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(110, 23);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Chọn tháng";
            // 
            // ucThongKeBanTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucThongKeBanTheoThang";
            this.Size = new System.Drawing.Size(948, 524);
            this.Load += new System.EventHandler(this.ucThongKeBanTheoThang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiThongKe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spedThang.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcDanhSachThongKe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachThongKe;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.LabelControl lblTienBan;
        private DevExpress.XtraEditors.LabelControl lblTienLai;
        private DevExpress.XtraEditors.LabelControl lblTienNhap;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnThongKe;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboNam;
        private DevExpress.XtraEditors.SpinEdit spedThang;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lueLoaiThongKe;
    }
}
