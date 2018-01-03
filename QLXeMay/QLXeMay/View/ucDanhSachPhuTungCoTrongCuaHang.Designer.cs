namespace QLXeMay.View
{
    partial class ucDanhSachPhuTungCoTrongCuaHang
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gcDanhSachPhuTungCoTrongCuaHang = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachPhuTungCoTrongCuaHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachPhuTungCoTrongCuaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachPhuTungCoTrongCuaHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(892, 109);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelControl1.Location = new System.Drawing.Point(159, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(574, 31);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "DANH SÁCH PHỤ TÙNG TRONG CỬA HÀNG";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.btnPrint);
            this.panelControl2.Controls.Add(this.gcDanhSachPhuTungCoTrongCuaHang);
            this.panelControl2.Location = new System.Drawing.Point(0, 110);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(892, 351);
            this.panelControl2.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(716, 310);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(141, 36);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "In danh sách";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gcDanhSachPhuTungCoTrongCuaHang
            // 
            this.gcDanhSachPhuTungCoTrongCuaHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDanhSachPhuTungCoTrongCuaHang.Location = new System.Drawing.Point(35, 23);
            this.gcDanhSachPhuTungCoTrongCuaHang.MainView = this.gvDanhSachPhuTungCoTrongCuaHang;
            this.gcDanhSachPhuTungCoTrongCuaHang.Name = "gcDanhSachPhuTungCoTrongCuaHang";
            this.gcDanhSachPhuTungCoTrongCuaHang.Size = new System.Drawing.Size(822, 281);
            this.gcDanhSachPhuTungCoTrongCuaHang.TabIndex = 0;
            this.gcDanhSachPhuTungCoTrongCuaHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachPhuTungCoTrongCuaHang});
            // 
            // gvDanhSachPhuTungCoTrongCuaHang
            // 
            this.gvDanhSachPhuTungCoTrongCuaHang.GridControl = this.gcDanhSachPhuTungCoTrongCuaHang;
            this.gvDanhSachPhuTungCoTrongCuaHang.Name = "gvDanhSachPhuTungCoTrongCuaHang";
            this.gvDanhSachPhuTungCoTrongCuaHang.OptionsView.ShowGroupPanel = false;
            // 
            // ucDanhSachPhuTungCoTrongCuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDanhSachPhuTungCoTrongCuaHang";
            this.Size = new System.Drawing.Size(892, 461);
            this.Load += new System.EventHandler(this.ucDanhSachPhuTungCoTrongCuaHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachPhuTungCoTrongCuaHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachPhuTungCoTrongCuaHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcDanhSachPhuTungCoTrongCuaHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachPhuTungCoTrongCuaHang;
        private System.Windows.Forms.Button btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
