using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using DevExpress.XtraEditors;
namespace QLXeMay.View
{
    public partial class ucTimKiemPhuTung : UserControl
    {
        public ucTimKiemPhuTung()
        {
            InitializeComponent();
        }

        PhuTungControl PTControl = new PhuTungControl();

        private void ucTimKiemPhuTung_Load(object sender, EventArgs e)
        {
            txtTimKiem.Visible = true;
            dateNgayNhap.Visible = false;

            cboTuyChonTimKiem.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);

            cboTuyChonTimKiem.Properties.Items.Clear();
            cboTuyChonTimKiem.Properties.Items.Add("Phụ tùng đã nhập");
            cboTuyChonTimKiem.Properties.Items.Add("Phụ tùng đã bán");
            cboTuyChonTimKiem.Properties.Items.Add("Phụ tùng có trong cửa hàng");

            cboTuyChonTimKiem.Text = "Phụ tùng có trong cửa hàng";

            cboTimKiem.Properties.Items.Clear();
            cboTimKiem.Properties.Items.Add("Mã phụ tùng");
            cboTimKiem.Properties.Items.Add("Tên phụ tùng");
            cboTimKiem.Properties.Items.Add("Ngày nhập");
            cboTimKiem.Properties.Items.Add("Tên nhân viên");

            cboTimKiem.Text = "Mã phụ tùng";

            cboTimKiem.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);

            cboTuyChonTimKiem.TabIndex = 1;
            cboTimKiem.TabIndex = 2;
            txtTimKiem.TabIndex = 3;
            btnTimKiem.TabIndex = 4;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtTimKiemPhuTung = new DataTable();
            string timKiem = "";
            if (cboTuyChonTimKiem.EditValue as string == "Phụ tùng đã nhập")
            {
                if (cboTimKiem.EditValue as string == "Tên phụ tùng") timKiem = string.Format("tblTTPhuTung.TENPT LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên nhân viên") timKiem = string.Format("tblNhanVien.TENNV LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Ngày nhập")
                {
                    try
                    {
                        timKiem = string.Format("tblNhapPhuTung.NGAYNHAP = CONVERT(date, '{0}', 103)", dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0]);
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Ngày bạn nhập sai.\nVui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                dtTimKiemPhuTung = PTControl.timKiemPhuTungDaNhap(timKiem);
                gcDanhSachTimKiemPhuTung.DataSource = null;
                gcDanhSachTimKiemPhuTung.DataSource = dtTimKiemPhuTung;
                gcDanhSachTimKiemPhuTung.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachTimKiemPhuTung);


            }

            else if (cboTuyChonTimKiem.EditValue as string == "Phụ tùng đã bán")
            {
                if (cboTimKiem.EditValue as string == "Mã phụ tùng") timKiem = string.Format("tblePhuTung.MAPT LIKE '%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên phụ tùng") timKiem = string.Format("tblTTPhuTung.TENPT LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Ngày bán") timKiem = string.Format("tblHDBanPhuTung.NGAYBAN = CONVERT(date, '{0}', 103)", dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0]);
                else if (cboTimKiem.EditValue as string == "Tên khách hàng") timKiem = string.Format("tblKhachHang.TENKH LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên nhân viên") timKiem = string.Format("tblNhanVien.TENNV LIKE N'%{0}%'", txtTimKiem.EditValue);


                dtTimKiemPhuTung = PTControl.timKiemPhuTungDaBan(timKiem);
                gcDanhSachTimKiemPhuTung.DataSource = null;
                gcDanhSachTimKiemPhuTung.DataSource = dtTimKiemPhuTung;
                gcDanhSachTimKiemPhuTung.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachTimKiemPhuTung);

            }
            else if (cboTuyChonTimKiem.EditValue as string == "Phụ tùng có trong cửa hàng")
            {
                if (cboTimKiem.EditValue as string == "Mã phụ tùng") timKiem = string.Format("tblePhuTung.MAPT LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên phụ tùng") timKiem = string.Format("tblTTPhuTung.TENPT LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Ngày nhập") timKiem = string.Format("tblNhapPhuTung.NGAYNHAP = CONVERT(date, '{0}', 103)", dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0]);
                else if (cboTimKiem.EditValue as string == "Tên nhân viên") timKiem = string.Format("tblNhanVien.TENNV LIKE N'%{0}%'", txtTimKiem.EditValue);

                dtTimKiemPhuTung = PTControl.timKiemPhuTungCoTrongCuaHang(timKiem);
                gcDanhSachTimKiemPhuTung.DataSource = null;
                gcDanhSachTimKiemPhuTung.DataSource = dtTimKiemPhuTung;
                gcDanhSachTimKiemPhuTung.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachTimKiemPhuTung);
            }
        }

        private void cboTuyChonTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuyChonTimKiem.EditValue as string == "Phụ tùng đã nhập")
            {
                cboTimKiem.Properties.Items.Clear();
                cboTimKiem.Properties.Items.Add("Tên phụ tùng");
                cboTimKiem.Properties.Items.Add("Tên nhân viên");
                cboTimKiem.Properties.Items.Add("Ngày nhập");

                cboTimKiem.Text = "Tên phụ tùng";
            }
            else if (cboTuyChonTimKiem.EditValue as string == "Phụ tùng có trong cửa hàng")
            {
                cboTimKiem.Properties.Items.Clear();
                cboTimKiem.Properties.Items.Add("Mã phụ tùng");
                cboTimKiem.Properties.Items.Add("Tên phụ tùng");
                cboTimKiem.Properties.Items.Add("Ngày nhập");
                cboTimKiem.Properties.Items.Add("Tên nhân viên");
                cboTimKiem.Text = "Mã phụ tùng";
            }
            else if (cboTuyChonTimKiem.EditValue as string == "Phụ tùng đã bán")
            {
                cboTimKiem.Properties.Items.Clear();
                cboTimKiem.Properties.Items.Add("Mã phụ tùng");
                cboTimKiem.Properties.Items.Add("Tên phụ tùng");
                cboTimKiem.Properties.Items.Add("Ngày bán");
                cboTimKiem.Properties.Items.Add("Tên khách hàng");
                cboTimKiem.Properties.Items.Add("Tên nhân viên");
                cboTimKiem.Text = "Mã phụ tùng";
            }
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimKiem.EditValue = "";
            if (cboTimKiem.SelectedIndex == 2)
            {
                txtTimKiem.Visible = false;
                dateNgayNhap.Visible = true;
                dateNgayNhap.Size = new Size(201, 26);
                dateNgayNhap.Location = new Point(306, 96);
                dateNgayNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }
            else
            {
                txtTimKiem.Visible = true;
                dateNgayNhap.Visible = false;
            }


        }
        

    }
}
