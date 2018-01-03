using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using QLXeMay.Object;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class ucPhuTung : UserControl
    {
        public ucPhuTung()
        {
            InitializeComponent();
        }

        PhuTungControl ptControl = new PhuTungControl();
        PhuTungObj ptObj = new PhuTungObj();
        frmMain frm = new frmMain();

        bool flagDelete = false;
        private void ucPhuTung_Load(object sender, EventArgs e)
        {
            //splitContainerControl1.FixedPanel = SplitFixedPanel.None;
            enable(false);
            deleteText();
            lueMaChiTietNhapPT.EditValue = string.Empty;
            lblDonGiaBan.Visible = false;
            txtSuaDonGiaBan.Visible = false;
            groupControl3.Visible = true;
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = true;
            txtSuaDonGiaBan.Text = string.Empty;

            //Thêm tìm kiếm theo cột
            gvDanhSachPhuTung.OptionsView.ShowAutoFilterRow = false;

            //tổng phụ tùng trong cửa hàng <= tổng phụ tùng đã nhập

            //Danh sách phụ tùng (theo mã chi tiết nhập) nhân viên đã nhập
            DataTable dtPTNhanVienDaNhap = new DataTable();
            dtPTNhanVienDaNhap = ptControl.getAllDataNhanVienDaNhap();

            //Danh sách phụ tùng có trong cửa hàng với điều kiện tổng số giống nhau mã chi tiết nhập = số lượng
            DataTable dtPTTrongCuaHang = new DataTable();
            dtPTTrongCuaHang = ptControl.getAllDataSoLuongBangMaChiTietNhapPT();

            var listPTTrongCuaHang = new List<string>();
            for (int i = 0; i < dtPTTrongCuaHang.Rows.Count; i++)
            {
                listPTTrongCuaHang.Add(dtPTTrongCuaHang.Rows[i][0].ToString());
            }

            for (int i = 0; i < dtPTNhanVienDaNhap.Rows.Count; i++)
            {
                if (listPTTrongCuaHang.Contains(dtPTNhanVienDaNhap.Rows[i][0].ToString())) dtPTNhanVienDaNhap.Rows[i].Delete();
            }

            gcPhuTungChuaNhap.DataSource = dtPTNhanVienDaNhap;
            frmMain.DatLaiTenCotCuaGridView(gvPhuTungChuaNhap);

            //Lấy datasource cho lueMaChiTietNhap
            var listlueMaCTN = new List<string>();
            DataTable dtCholueMaCTN = frm.ChuyenGridViewSangDataTable(gvPhuTungChuaNhap);
            for (int i = 0; i < dtCholueMaCTN.Rows.Count; i++)
            {
                listlueMaCTN.Add(dtCholueMaCTN.Rows[i][0].ToString());
            }
            lueMaChiTietNhapPT.Properties.DataSource = listlueMaCTN;

            //Update DataSource cho gridcontrol
            gcDanhSachPhuTung.DataSource = null;
            gcDanhSachPhuTung.DataSource = ptControl.getAllDataUCPhuTung(); 
            gcDanhSachPhuTung.MainView.PopulateColumns();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachPhuTung);
            frmMain.SapXepLaiGridView(gvDanhSachPhuTung, "MAPT", false);
            
        }


        private void enable(bool k)
        {
            layoutControl1.Enabled = btnLuu.Enabled = btnHuy.Enabled = k;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = !k;
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
          lueMaChiTietNhapPT.Text = txtLoaiPT.Text = txtTenPT.Text = txtDonGiaBan.Text = txtDonGiaNhap.Text = txtSoLuong.Text = txtDonViTinh.Text = string.Empty;
        }

        bool flag = true;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (gvPhuTungChuaNhap.RowCount > 0)
            {
                flag = true;
                enable(true);
                txtDonGiaBan.Enabled = lueMaChiTietNhapPT.Enabled = true;
                txtLoaiPT.Enabled = txtTenPT.Enabled = txtDonGiaNhap.Enabled = txtSoLuong.Enabled = txtDonViTinh.Enabled = false;
            }
            else XtraMessageBox.Show("Không còn xe để nhập thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool kiemTra = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flagDelete)
            {
                #region Xóa
                var dtXoa = new DataTable();
                dtXoa = frm.ChuyenGridViewSangDataTable(gvDanhSachPhuTung);

                if (XtraMessageBox.Show("Bạn có muốn xóa dữ liệu đã chọn bên bảng Danh sách phụ tùng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dtXoa.Rows.Count != 0)
                    {
                        bool kiemTraXoa = false;
                        for (int i = 0; i < dtXoa.Rows.Count; i++)
                        {
                            if (ptControl.deleteData(dtXoa.Rows[i][0].ToString().Trim()))
                            {
                                kiemTraXoa = true;
                            }
                            else kiemTraXoa = false;
                        }
                        if (kiemTraXoa)
                        {
                            XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flagDelete = false;
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flagDelete = false;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa chọn dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                #endregion
            }
            else
            {

                if (flag)
                {
                    #region Lưu thêm
                    int dem = 0;
                    if (lueMaChiTietNhapPT.Text != "") ptObj.MaCTNhapPT = lueMaChiTietNhapPT.Text.Trim();
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa nhập Mã chi tiết nhập phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ptObj.MaCTNhapPT = string.Empty;
                        lueMaChiTietNhapPT.Focus();
                    }

                    if (txtDonGiaBan.Text != string.Empty)
                    {
                        try
                        {
                            kiemTra = true;
                            ptObj.DonGiaBan = Convert.ToInt32(txtDonGiaBan.EditValue.ToString().Trim());
                        }
                        catch (Exception)
                        {
                            kiemTra = false;
                            XtraMessageBox.Show("Đơn giá bán nhập với số quá lớn,\nNhập lại với số nhỏ hơn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDonGiaBan.Text = string.Empty;
                            txtDonGiaBan.Focus(); return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa nhập Đơn giá bán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDonGiaBan.Focus();
                        kiemTra = false;
                        return;
                    }

                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(txtSoLuong.Text); i++)
                        {
                            ptObj.MaPT = frm.MaSoTuTang("PT", ptControl.getAlldata());
                            if (lueMaChiTietNhapPT.Text != string.Empty && txtDonGiaBan.Text != string.Empty && kiemTra)
                            {
                                if (ptControl.addData(ptObj))
                                {
                                    dem++;
                                    if (dem == Convert.ToInt32(txtSoLuong.Text))
                                    {
                                        XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                                    break;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
#endregion 
                }
                else
                {
                    //Sửa
                    var dtSua = new DataTable();
                    dtSua = frm.ChuyenGridViewSangDataTable(gvDanhSachPhuTung);
                    //Kiểm tra điều kiện đơn giá
                    bool kiemtraDonGia = false;
                    if (txtSuaDonGiaBan.Text != string.Empty)
                    {
                        try
                        {
                            kiemtraDonGia = true;
                            ptObj.DonGiaBan = Convert.ToInt32(txtSuaDonGiaBan.EditValue.ToString().Trim());
                        }
                        catch (Exception)
                        {
                            kiemtraDonGia = false;
                            XtraMessageBox.Show("Đơn giá bán không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSuaDonGiaBan.Text = string.Empty;
                            txtSuaDonGiaBan.Focus(); return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa nhập Đơn giá bán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSuaDonGiaBan.Focus();
                        kiemTra = false;
                        return;

                    }

                    if (dtSua.Rows.Count != 0)
                    {
                        try
                        {
                            int count = 0;
                            for (int i = 0; i <dtSua.Rows.Count; i++)
                            {
                                ptObj.MaPT = dtSua.Rows[i][0].ToString().Trim();
                                ptObj.MaCTNhapPT = dtSua.Rows[i][1].ToString().Trim();

                                if (txtSuaDonGiaBan.Text != string.Empty && (Convert.ToInt32(txtSuaDonGiaBan.Text) != 0) && kiemtraDonGia)
                                {
                                    if (ptControl.updateData(ptObj))
                                    {
                                        count++;
                                        if (count == dtSua.Rows.Count)
                                        {
                                            XtraMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                                        break;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
            }

            ucPhuTung_Load(sender, e);
        }

        private void lueMaChiTietNhapPT_EditValueChanged(object sender, EventArgs e)
        {
            txtLoaiPT.Text = ptControl.getLoaiPT(lueMaChiTietNhapPT.Text.Trim());
            txtTenPT.Text = ptControl.getTenPT(lueMaChiTietNhapPT.Text.Trim());
            txtDonGiaNhap.Text = ptControl.getDonGiaNhap(lueMaChiTietNhapPT.Text.Trim());
            txtSoLuong.Text = ptControl.getSoLuong(lueMaChiTietNhapPT.Text.Trim());
            txtDonViTinh.Text = ptControl.getDonViTinh(lueMaChiTietNhapPT.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            flagDelete = true;
            enable(true);
            gvDanhSachPhuTung.OptionsView.ShowAutoFilterRow = true;
            layoutControl1.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            enable(true);
            gvDanhSachPhuTung.OptionsView.ShowAutoFilterRow = true;
            layoutControl1.Enabled = false;
            lblDonGiaBan.Visible = true;
            txtSuaDonGiaBan.Visible = true;
            groupControl3.Visible = false;
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ucPhuTung_Load(sender, e);
        }

        private void gcPhuTungChuaNhap_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvPhuTungChuaNhap.FocusedRowHandle;
            object value1 = gvPhuTungChuaNhap.GetRowCellValue(HangDangChon, "MACTNPT");

            if (value1 != null)
            {
                object value2 = gvPhuTungChuaNhap.GetRowCellValue(HangDangChon, "SOLUONG");
                object value3 = gvPhuTungChuaNhap.GetRowCellValue(HangDangChon, "LOAIPT");
                object value4 = gvPhuTungChuaNhap.GetRowCellValue(HangDangChon, "TENPT");
                object value5 = gvPhuTungChuaNhap.GetRowCellValue(HangDangChon, "DONVITINH");
                object value6 = gvPhuTungChuaNhap.GetRowCellValue(HangDangChon, "DONGIANHAP");

                lueMaChiTietNhapPT.Text = value1.ToString();
                txtSoLuong.Text = value2.ToString();
                txtLoaiPT.Text = value3.ToString();
                txtTenPT.Text = value4.ToString();
                txtDonViTinh.Text = value5.ToString();
                txtDonGiaNhap.Text = value6.ToString();
            }
        }

    }
}