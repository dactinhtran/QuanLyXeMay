namespace QLXeMay.View
{
    partial class ucThongKeNhapTheoThang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThongKeNhapTheoThang));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.lblTienNhap = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.grctDanhSach = new DevExpress.XtraEditors.GroupControl();
            this.gcDanhSachThongKe = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachThongKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.grctNam = new DevExpress.XtraEditors.GroupControl();
            this.spinEditNam = new DevExpress.XtraEditors.SpinEdit();
            this.grcThang = new DevExpress.XtraEditors.GroupControl();
            this.spinEditThang = new DevExpress.XtraEditors.SpinEdit();
            this.rdogrChon = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPhuTung = new DevExpress.XtraEditors.SimpleButton();
            this.btnXeMay = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grctDanhSach)).BeginInit();
            this.grctDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grctNam)).BeginInit();
            this.grctNam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcThang)).BeginInit();
            this.grcThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdogrChon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnIn);
            this.panelControl1.Controls.Add(this.lblTienNhap);
            this.panelControl1.Controls.Add(this.lblSoLuong);
            this.panelControl1.Controls.Add(this.grctDanhSach);
            this.panelControl1.Location = new System.Drawing.Point(0, 198);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(952, 315);
            this.panelControl1.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(692, 261);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(225, 36);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In danh sách";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lblTienNhap
            // 
            this.lblTienNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTienNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNhap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTienNhap.Location = new System.Drawing.Point(315, 271);
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
            this.lblSoLuong.Location = new System.Drawing.Point(36, 271);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(126, 19);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Tổng số lượng: ";
            // 
            // grctDanhSach
            // 
            this.grctDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grctDanhSach.Controls.Add(this.gcDanhSachThongKe);
            this.grctDanhSach.Location = new System.Drawing.Point(34, 27);
            this.grctDanhSach.Name = "grctDanhSach";
            this.grctDanhSach.Size = new System.Drawing.Size(884, 228);
            this.grctDanhSach.TabIndex = 0;
            this.grctDanhSach.Text = "Danh sách thống kê";
            // 
            // gcDanhSachThongKe
            // 
            this.gcDanhSachThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachThongKe.Location = new System.Drawing.Point(2, 20);
            this.gcDanhSachThongKe.MainView = this.gvDanhSachThongKe;
            this.gcDanhSachThongKe.Name = "gcDanhSachThongKe";
            this.gcDanhSachThongKe.Size = new System.Drawing.Size(880, 206);
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
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(952, 200);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl4
            // 
            this.panelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl4.Controls.Add(this.grctNam);
            this.panelControl4.Controls.Add(this.grcThang);
            this.panelControl4.Controls.Add(this.rdogrChon);
            this.panelControl4.Controls.Add(this.groupControl1);
            this.panelControl4.Location = new System.Drawing.Point(0, 65);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(952, 135);
            this.panelControl4.TabIndex = 1;
            // 
            // grctNam
            // 
            this.grctNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grctNam.Appearance.Options.UseTextOptions = true;
            this.grctNam.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grctNam.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grctNam.Controls.Add(this.spinEditNam);
            this.grctNam.Location = new System.Drawing.Point(739, 23);
            this.grctNam.Name = "grctNam";
            this.grctNam.Size = new System.Drawing.Size(154, 86);
            this.grctNam.TabIndex = 4;
            this.grctNam.Text = "Nhập năm";
            // 
            // spinEditNam
            // 
            this.spinEditNam.EditValue = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.spinEditNam.Location = new System.Drawing.Point(29, 35);
            this.spinEditNam.Name = "spinEditNam";
            this.spinEditNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditNam.Properties.Appearance.Options.UseFont = true;
            this.spinEditNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditNam.Properties.IsFloatValue = false;
            this.spinEditNam.Properties.Mask.EditMask = "d";
            this.spinEditNam.Properties.MaxValue = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.spinEditNam.Properties.MinValue = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.spinEditNam.Size = new System.Drawing.Size(89, 26);
            this.spinEditNam.TabIndex = 0;
            this.spinEditNam.EditValueChanged += new System.EventHandler(this.spinEditNam_EditValueChanged);
            // 
            // grcThang
            // 
            this.grcThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grcThang.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcThang.Appearance.Options.UseFont = true;
            this.grcThang.Appearance.Options.UseTextOptions = true;
            this.grcThang.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grcThang.Controls.Add(this.spinEditThang);
            this.grcThang.Location = new System.Drawing.Point(541, 23);
            this.grcThang.Name = "grcThang";
            this.grcThang.Size = new System.Drawing.Size(154, 86);
            this.grcThang.TabIndex = 3;
            this.grcThang.Text = "Nhập thángcần thống kê";
            // 
            // spinEditThang
            // 
            this.spinEditThang.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditThang.Location = new System.Drawing.Point(29, 35);
            this.spinEditThang.Name = "spinEditThang";
            this.spinEditThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditThang.Properties.Appearance.Options.UseFont = true;
            this.spinEditThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditThang.Properties.IsFloatValue = false;
            this.spinEditThang.Properties.Mask.EditMask = "d";
            this.spinEditThang.Properties.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.spinEditThang.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditThang.Size = new System.Drawing.Size(89, 26);
            this.spinEditThang.TabIndex = 0;
            this.spinEditThang.EditValueChanged += new System.EventHandler(this.spinEditThang_EditValueChanged);
            // 
            // rdogrChon
            // 
            this.rdogrChon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdogrChon.Location = new System.Drawing.Point(253, 23);
            this.rdogrChon.Name = "rdogrChon";
            this.rdogrChon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdogrChon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdogrChon.Properties.Appearance.Options.UseBackColor = true;
            this.rdogrChon.Properties.Appearance.Options.UseFont = true;
            this.rdogrChon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tháng hiện tại"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tháng bất kỳ")});
            this.rdogrChon.Size = new System.Drawing.Size(244, 86);
            this.rdogrChon.TabIndex = 1;
            this.rdogrChon.SelectedIndexChanged += new System.EventHandler(this.rdogrChon_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.btnPhuTung);
            this.groupControl1.Controls.Add(this.btnXeMay);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(247, 135);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chọn loại thống kê";
            // 
            // btnPhuTung
            // 
            this.btnPhuTung.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhuTung.Appearance.Options.UseFont = true;
            this.btnPhuTung.Image = ((System.Drawing.Image)(resources.GetObject("btnPhuTung.Image")));
            this.btnPhuTung.Location = new System.Drawing.Point(36, 75);
            this.btnPhuTung.Name = "btnPhuTung";
            this.btnPhuTung.Size = new System.Drawing.Size(163, 46);
            this.btnPhuTung.TabIndex = 1;
            this.btnPhuTung.Text = "Phụ tùng";
            this.btnPhuTung.Click += new System.EventHandler(this.btnPhuTung_Click);
            // 
            // btnXeMay
            // 
            this.btnXeMay.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXeMay.Appearance.Options.UseFont = true;
            this.btnXeMay.Image = ((System.Drawing.Image)(resources.GetObject("btnXeMay.Image")));
            this.btnXeMay.Location = new System.Drawing.Point(36, 23);
            this.btnXeMay.Name = "btnXeMay";
            this.btnXeMay.Size = new System.Drawing.Size(163, 46);
            this.btnXeMay.TabIndex = 0;
            this.btnXeMay.Text = "Xe máy";
            this.btnXeMay.Click += new System.EventHandler(this.btnXeMay_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(952, 67);
            this.panelControl3.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(253, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(447, 29);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "THỐNG KÊ HÀNG NHẬP THEO THÁNG";
            // 
            // ucThongKeNhapTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucThongKeNhapTheoThang";
            this.Size = new System.Drawing.Size(952, 513);
            this.Load += new System.EventHandler(this.ucThongKeNhapTheoThang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grctDanhSach)).EndInit();
            this.grctDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grctNam)).EndInit();
            this.grctNam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcThang)).EndInit();
            this.grcThang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdogrChon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPhuTung;
        private DevExpress.XtraEditors.SimpleButton btnXeMay;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rdogrChon;
        private DevExpress.XtraEditors.GroupControl grctNam;
        private DevExpress.XtraEditors.SpinEdit spinEditNam;
        private DevExpress.XtraEditors.GroupControl grcThang;
        private DevExpress.XtraEditors.SpinEdit spinEditThang;
        private DevExpress.XtraEditors.GroupControl grctDanhSach;
        private DevExpress.XtraGrid.GridControl gcDanhSachThongKe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachThongKe;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.LabelControl lblTienNhap;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
    }
}
