using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLXeMay.Control;
using QLXeMay.Object;

namespace QLXeMay.View
{
    public partial class frmNhaCungCap : XtraForm
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        NhaCungCapControl nccControl = new NhaCungCapControl();
        NhaCungCapObj nccObj = new NhaCungCapObj();
        public bool flag = true;
        public string maNCC = "";
        public string tenNCC = "";
        public string diaChi = "";
        public string sdt = "";
        public string email = "";

        private void GanDuLieu()
        {
            txtMaNhaCC.EditValue = maNCC;
            txtMaNhaCC.Enabled = false;
            txtTenNhaCC.EditValue = tenNCC;
            txtDiaChi.EditValue = diaChi;
            txtSDT.EditValue = sdt;
            txtEmail.EditValue = email;
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            DeleteText();
            if (!flag) GanDuLieu();
            if (flag)
            {
                frmMain frm = new frmMain();
                txtMaNhaCC.Text = frm.MaSoTuTang("NCC", nccControl.getAllData());
            }
        }

        private void DeleteText()
        {
            txtMaNhaCC.Text = txtTenNhaCC.Text = txtDiaChi.Text = txtSDT.Text = txtEmail.Text = string.Empty;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtMaNhaCC.Text != string.Empty) nccObj.MaNCC = txtMaNhaCC.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNhaCC.Focus();
            }

            if (txtTenNhaCC.Text != string.Empty) nccObj.TenNCC = txtTenNhaCC.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNhaCC.Focus();
            }

            if (txtDiaChi.Text != string.Empty) nccObj.DiaChi = txtDiaChi.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
            }

            if (txtSDT.Text != string.Empty) nccObj.Sdt = txtSDT.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }

            if (txtEmail.Text != string.Empty) nccObj.Email = txtEmail.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Email", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }

            try
            {
                if (flag)
                {
                    if (txtMaNhaCC.Text != string.Empty && txtTenNhaCC.Text != string.Empty && 
                        txtDiaChi.Text != string.Empty && txtSDT.Text != string.Empty && 
                        txtEmail.Text != string.Empty)
                    {
                        if (nccControl.addData(nccObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmNhaCungCap_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMaNhaCC.Text != string.Empty && txtTenNhaCC.Text != string.Empty && 
                        txtDiaChi.Text != string.Empty && txtSDT.Text != string.Empty && 
                        txtEmail.Text != string.Empty)
                    {
                        if (nccControl.updateData(nccObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
            
    }
}
