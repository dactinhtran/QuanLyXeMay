using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QLXeMay.Control;
using QLXeMay.Object;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class ucXe : UserControl
    {
        public ucXe()
        {
            InitializeComponent();
        }

        XeControl xcontrol = new XeControl();
        XeObj xObj = new XeObj();
        ChiTietNhapXeControl ctnxControl = new ChiTietNhapXeControl();
        frmMain frm = new frmMain();


        private void ucXe_Load(object sender, EventArgs e)
        {
            enableText(false);
            deleteText();
            lueMaChiTietNhap.EditValue = string.Empty;

            //Thêm tìm kiếm theo cột
            gvDanhSachXe.OptionsView.ShowAutoFilterRow = true;

            gcDanhSachXe.DataSource = xcontrol.getAllDataUCXe();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachXe);

            lueMaChiTietNhap.Properties.DataSource = ctnxControl.getDataMaChiTiet();
            lueMaChiTietNhap.Properties.DisplayMember = "MACTN";

            DataTable dtTrongCuaHang = new DataTable();
            dtTrongCuaHang = xcontrol.getDataMaSoLuongXeTrongCuahang();

            var listTrongCuahang = new List<string>();
            for (int i = 0; i < dtTrongCuaHang.Rows.Count; i++)
            {
                listTrongCuahang.Add(dtTrongCuaHang.Rows[i][0].ToString());
            }

            DataTable dtDaNhap = new DataTable();

            dtDaNhap = xcontrol.getDataMaSoLuongXeNhanVienDaNhap();

            for (int i = dtDaNhap.Rows.Count - 1; i >= 0; i--)
            {
                if (listTrongCuahang.Contains(dtDaNhap.Rows[i][0].ToString().Trim())) dtDaNhap.Rows[i].Delete();
            }

            gcDanhSachXeChuaThem.DataSource = dtDaNhap;
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachXeChuaThem);
            frmMain.SapXepLaiGridView(gvDanhSachXe, "MAXE", false);
        }

        private void enableText(bool k)
        {
            layoutControl1.Enabled = btnLuu.Enabled = btnHuy.Enabled = k;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = !k;
            if (k)
            {
                btnThem.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnSua.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnXoa.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnLuu.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnHuy.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                btnThem.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnSua.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnXoa.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnLuu.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnHuy.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void deleteText()
        {
            txtDonGia.EditValue = txtMaXe.EditValue = txtNamSanXuat.EditValue = txtSoKhung.EditValue = txtSoMay.EditValue = string.Empty;
        }

        bool flag = true;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(gvDanhSachXeChuaThem.RowCount > 0)
            {
                flag = true;
                enableText(true);
                txtMaXe.Text = frm.MaSoTuTang("X", xcontrol.getAllData());
            }
            else XtraMessageBox.Show("Không còn xe để nhập thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            enableText(true);

            int HangDangChon = gvDanhSachXe.FocusedRowHandle;
            object value1 = gvDanhSachXe.GetRowCellValue(HangDangChon, "MAXE");

            if (value1 != null)
            {
                object value2 = gvDanhSachXe.GetRowCellValue(HangDangChon, "MACTN");
                object value3 = gvDanhSachXe.GetRowCellValue(HangDangChon, "SOKHUNG");
                object value4 = gvDanhSachXe.GetRowCellValue(HangDangChon, "SOMAY");
                object value5 = gvDanhSachXe.GetRowCellValue(HangDangChon, "DONGIABAN");
                object value6 = gvDanhSachXe.GetRowCellValue(HangDangChon, "NAMSANXUAT");

                txtMaXe.Text = value1.ToString();
                lueMaChiTietNhap.Text = value2.ToString();
                txtSoKhung.Text = value3.ToString();
                txtSoMay.Text = value4.ToString();
                txtDonGia.Text = value5.ToString();
                txtNamSanXuat.Text = value6.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucXe_Load(sender, e);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int row_index = gvDanhSachXe.FocusedRowHandle;
                object value = gvDanhSachXe.GetRowCellValue(row_index, "MAXE");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (xcontrol.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gcDanhSachXe.DataSource = xcontrol.getAllData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn đối tượng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        bool kiemTra = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaXe.Text != "") xObj.MaXe = txtMaXe.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xObj.MaXe = string.Empty;
                txtMaXe.Focus();
            }

            if (lueMaChiTietNhap.Text != "") xObj.MaCTN = lueMaChiTietNhap.Text.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã chi tiết nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xObj.MaCTN = string.Empty;
                lueMaChiTietNhap.Focus();
            }

            if (txtSoKhung.Text != "") xObj.SoKhung = txtSoKhung.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số khung xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xObj.SoKhung = string.Empty;
                txtSoKhung.Focus();
                return;
            }

            if (txtSoMay.Text != "") xObj.SoMay = txtSoMay.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xObj.SoMay = string.Empty;
                txtSoMay.Focus(); 
                return;
            }

            if (txtDonGia.Text != string.Empty)
            {
                try
                {
                    kiemTra = true;
                    xObj.DonGiaban = Convert.ToInt32(txtDonGia.EditValue.ToString().Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Đơn giá nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDonGia.Text = string.Empty;
                    txtDonGia.Focus();
                    return;
                }

            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Đơn giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Focus(); return;
            }

            if (txtNamSanXuat.Text != string.Empty)
            {
                try
                {
                    kiemTra = true;
                    xObj.NamSX = Convert.ToInt32(txtNamSanXuat.EditValue.ToString().Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Năm sản xuất nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamSanXuat.Text = string.Empty;
                    txtNamSanXuat.Focus(); return;
                }

            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Năm sản xuất", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSanXuat.Focus(); return;
            }

            try
            {
                if (flag)
                {
                    if (txtMaXe.Text != string.Empty && lueMaChiTietNhap.Text != string.Empty &&
                        txtSoMay.Text != string.Empty && txtSoKhung.Text != string.Empty &&
                        txtDonGia.Text != string.Empty && txtNamSanXuat.Text != string.Empty && kiemTra)
                    {
                        if (xcontrol.addData(xObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucXe_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

                else
                {

                    if (txtMaXe.Text != string.Empty && lueMaChiTietNhap.Text != string.Empty &&
                        txtSoMay.Text != string.Empty && txtSoKhung.Text != string.Empty &&
                        txtDonGia.Text != string.Empty && txtNamSanXuat.Text != string.Empty && kiemTra)
                    {
                        if (xcontrol.updateData(xObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucXe_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void gcDanhSachXeChuaThem_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachXeChuaThem.FocusedRowHandle;
            object value1 = gvDanhSachXeChuaThem.GetRowCellValue(HangDangChon, "MACTN");

            if (value1 != null)
            {
                lueMaChiTietNhap.Text = value1.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ucXe_Load(sender, e);
        }

        private void lueMaChiTietNhap_EditValueChanged(object sender, EventArgs e)
        {
            txtTenXe.Text = xcontrol.getTenXeUCXe(lueMaChiTietNhap.Text.Trim());
            txtMauXe.Text = xcontrol.getMauXeUCXe(lueMaChiTietNhap.Text.Trim());
            txtDungTich.Text = xcontrol.getDungTichUCXe(lueMaChiTietNhap.Text.Trim());
        }

    }
}
