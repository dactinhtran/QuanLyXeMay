namespace QLXeMay.View
{
    partial class frmChonQuyenTruyCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonQuyenTruyCap));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.clbQuyenTruyCap = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonTatCa = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbQuyenTruyCap)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.clbQuyenTruyCap);
            this.panelControl1.Location = new System.Drawing.Point(1, -2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(376, 362);
            this.panelControl1.TabIndex = 0;
            // 
            // clbQuyenTruyCap
            // 
            this.clbQuyenTruyCap.Appearance.BackColor = System.Drawing.Color.PeachPuff;
            this.clbQuyenTruyCap.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbQuyenTruyCap.Appearance.Options.UseBackColor = true;
            this.clbQuyenTruyCap.Appearance.Options.UseFont = true;
            this.clbQuyenTruyCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbQuyenTruyCap.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "1.Thêm tài khoản đăng nhập"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "2.Thay đổi mật khẩu đăng nhập"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "3.Quản lý khách hàng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "4.Quản lý nhân viên"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "5.Quản lý nhà cung cấp"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "6.Quản lý xe máy"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "7.Quản lý Phụ tùng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "8.Quản lý nhập xe máy"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "9.Quản lý nhập phụ tùng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "10.Quản lý bán xe máy"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "11.Quản lý bán phụ tùng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "12.Quản lý bảo hành xe máy"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "13.Xem báo cáo thống kê theo ngày"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "14.Xem báo cáo thống kê hàng nhập theo tháng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "15.Xem báo cáo thống kê hàng bán theo tháng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "16.Xem báo cáo thống kê hàng nhập theo năm"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "17.Xem báo cáo thống kê hàng bán theo năm"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "18.Xem báo cáo thống kê hàng nhập theo thời gian"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "19.Xem báo cáo thống kê hàng bán theo thời gian")});
            this.clbQuyenTruyCap.Location = new System.Drawing.Point(2, 2);
            this.clbQuyenTruyCap.Name = "clbQuyenTruyCap";
            this.clbQuyenTruyCap.Size = new System.Drawing.Size(372, 358);
            this.clbQuyenTruyCap.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(227, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 39);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnChonTatCa
            // 
            this.btnChonTatCa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChonTatCa.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonTatCa.Appearance.Options.UseFont = true;
            this.btnChonTatCa.Location = new System.Drawing.Point(21, 377);
            this.btnChonTatCa.Name = "btnChonTatCa";
            this.btnChonTatCa.Size = new System.Drawing.Size(134, 39);
            this.btnChonTatCa.TabIndex = 2;
            this.btnChonTatCa.Text = "Chọn tất cả";
            this.btnChonTatCa.Click += new System.EventHandler(this.btnChonTatCa_Click);
            // 
            // frmChonQuyenTruyCap
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 428);
            this.Controls.Add(this.btnChonTatCa);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonQuyenTruyCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quyền truy cập đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChonQuyenTruyCap_FormClosed);
            this.Load += new System.EventHandler(this.frmChonQuyenTruyCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clbQuyenTruyCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl clbQuyenTruyCap;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnChonTatCa;

    }
}