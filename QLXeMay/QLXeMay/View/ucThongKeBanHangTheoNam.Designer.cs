namespace QLXeMay.View
{
    partial class ucThongKeBanHangTheoNam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThongKeBanHangTheoNam));
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
            this.btnThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.lueChonNam = new DevExpress.XtraEditors.LookUpEdit();
            this.lueChonLoaiThongKe = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonLoaiThongKe.Properties)).BeginInit();
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
            this.panelControl1.Location = new System.Drawing.Point(0, 176);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(961, 346);
            this.panelControl1.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(705, 266);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(222, 36);
            this.btnIn.TabIndex = 15;
            this.btnIn.Text = "In danh sách";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lblTienBan
            // 
            this.lblTienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTienBan.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienBan.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTienBan.Location = new System.Drawing.Point(35, 311);
            this.lblTienBan.Name = "lblTienBan";
            this.lblTienBan.Size = new System.Drawing.Size(124, 19);
            this.lblTienBan.TabIndex = 14;
            this.lblTienBan.Text = "Tổng tiền bán: ";
            // 
            // lblTienLai
            // 
            this.lblTienLai.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTienLai.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienLai.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTienLai.Location = new System.Drawing.Point(366, 311);
            this.lblTienLai.Name = "lblTienLai";
            this.lblTienLai.Size = new System.Drawing.Size(114, 19);
            this.lblTienLai.TabIndex = 13;
            this.lblTienLai.Text = "Tổng tiền lãi: ";
            // 
            // lblTienNhap
            // 
            this.lblTienNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTienNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNhap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTienNhap.Location = new System.Drawing.Point(35, 276);
            this.lblTienNhap.Name = "lblTienNhap";
            this.lblTienNhap.Size = new System.Drawing.Size(134, 19);
            this.lblTienNhap.TabIndex = 12;
            this.lblTienNhap.Text = "Tổng tiền nhập: ";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSoLuong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSoLuong.Location = new System.Drawing.Point(366, 276);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(126, 19);
            this.lblSoLuong.TabIndex = 11;
            this.lblSoLuong.Text = "Tổng số lượng: ";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gcDanhSachThongKe);
            this.groupControl1.Location = new System.Drawing.Point(33, 21);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(894, 239);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // gcDanhSachThongKe
            // 
            this.gcDanhSachThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachThongKe.Location = new System.Drawing.Point(2, 20);
            this.gcDanhSachThongKe.MainView = this.gvDanhSachThongKe;
            this.gcDanhSachThongKe.Name = "gcDanhSachThongKe";
            this.gcDanhSachThongKe.Size = new System.Drawing.Size(890, 217);
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
            this.panelControl2.Controls.Add(this.btnThongKe);
            this.panelControl2.Controls.Add(this.lueChonNam);
            this.panelControl2.Controls.Add(this.lueChonLoaiThongKe);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(961, 177);
            this.panelControl2.TabIndex = 1;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Appearance.Options.UseFont = true;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.Location = new System.Drawing.Point(678, 88);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(201, 62);
            this.btnThongKe.TabIndex = 15;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // lueChonNam
            // 
            this.lueChonNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueChonNam.Location = new System.Drawing.Point(412, 124);
            this.lueChonNam.Name = "lueChonNam";
            this.lueChonNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueChonNam.Properties.Appearance.Options.UseFont = true;
            this.lueChonNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonNam.Size = new System.Drawing.Size(154, 26);
            this.lueChonNam.TabIndex = 14;
            // 
            // lueChonLoaiThongKe
            // 
            this.lueChonLoaiThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueChonLoaiThongKe.Location = new System.Drawing.Point(116, 124);
            this.lueChonLoaiThongKe.Name = "lueChonLoaiThongKe";
            this.lueChonLoaiThongKe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueChonLoaiThongKe.Properties.Appearance.Options.UseFont = true;
            this.lueChonLoaiThongKe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonLoaiThongKe.Size = new System.Drawing.Size(171, 26);
            this.lueChonLoaiThongKe.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl3.Location = new System.Drawing.Point(441, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 23);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Chọn năm";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Location = new System.Drawing.Point(116, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(180, 23);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Chọn loại thống kê";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(281, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(399, 29);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "THỐNG KÊ HÀNG BÁN THEO NĂM";
            // 
            // ucThongKeBanHangTheoNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucThongKeBanHangTheoNam";
            this.Size = new System.Drawing.Size(961, 522);
            this.Load += new System.EventHandler(this.ucThongKeBanHangTheoNam_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.lueChonNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonLoaiThongKe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcDanhSachThongKe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachThongKe;
        private DevExpress.XtraEditors.SimpleButton btnThongKe;
        private DevExpress.XtraEditors.LookUpEdit lueChonNam;
        private DevExpress.XtraEditors.LookUpEdit lueChonLoaiThongKe;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.LabelControl lblTienBan;
        private DevExpress.XtraEditors.LabelControl lblTienLai;
        private DevExpress.XtraEditors.LabelControl lblTienNhap;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
    }
}
