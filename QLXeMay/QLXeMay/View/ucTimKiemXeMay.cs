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
    public partial class ucTimKiemXeMay : UserControl
    {
        public ucTimKiemXeMay()
        {
            InitializeComponent();
        }

        XeControl xcontrol = new XeControl();

        private void ucTimKiemXeMay_Load(object sender, EventArgs e)
        {

            txtTimKiem.Visible = true;
            dateNgayNhap.Visible = false;

            cboTuyChonTimKiem.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);
            
            cboTuyChonTimKiem.Properties.Items.Clear();
            cboTuyChonTimKiem.Properties.Items.Add("Xe đã nhập");
            cboTuyChonTimKiem.Properties.Items.Add("Xe đã bán");
            cboTuyChonTimKiem.Properties.Items.Add("Xe có trong cửa hàng");

            cboTuyChonTimKiem.Text = "Xe có trong cửa hàng";
            cboTimKiem.Properties.Items.Clear();
            cboTimKiem.Properties.Items.Add("Mã xe");
            cboTimKiem.Properties.Items.Add("Tên xe");
            cboTimKiem.Properties.Items.Add("Màu xe");
            cboTimKiem.Properties.Items.Add("Ngày nhập");
            cboTimKiem.Properties.Items.Add("Đơn giá");
            cboTimKiem.Properties.Items.Add("Tên nhân viên");
            cboTimKiem.Text = "Mã xe";

            cboTimKiem.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);

            cboTuyChonTimKiem.TabIndex = 1;
            cboTimKiem.TabIndex = 2;
            txtTimKiem.TabIndex = 3;
            btnTimKiem.TabIndex = 4;
           
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtTimKiemXe = new DataTable();
            string timKiem = "";

            if (cboTuyChonTimKiem.EditValue as string == "Xe đã nhập")
            {
                if (cboTimKiem.EditValue as string == "Tên xe") timKiem = string.Format("tblTTXe.TENXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Màu xe") timKiem = string.Format("tblTTXe.MAUXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên nhân viên nhập") timKiem = string.Format("tblNhanVien.TENNV LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Ngày nhập") {
                    try
                    {
                        timKiem = string.Format("tblNhap.NGAYNHAP = CONVERT(date, '{0}', 103)", dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0]);
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Ngày bạn nhập sai.\nVui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                
                }

                dtTimKiemXe = xcontrol.timKiemXeDaNhap(timKiem);
                gcTimKiemXeMay.DataSource = null;
                gcTimKiemXeMay.DataSource = dtTimKiemXe;
                gcTimKiemXeMay.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvTimKiemXeMay);

            }

            else if (cboTuyChonTimKiem.EditValue as string == "Xe đã bán")
            {
                if (cboTimKiem.EditValue as string == "Mã xe") timKiem = string.Format("tblXe.MAXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên xe") timKiem = string.Format("tblTTXe.TENXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Màu xe") timKiem = string.Format("tblTTXe.MAUXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Ngày bán")
                {
                    {

                        try
                        {
                            timKiem = string.Format("tblHDBan.NGAYBAN = CONVERT(date, '{0}', 103)", dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0]);
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Ngày bạn nhập sai.\nVui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }

                else if (cboTimKiem.EditValue as string == "Tên khách hàng") timKiem = string.Format("tblKhachHang.TENKH LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên nhân viên bán") timKiem = string.Format(" tblNhanVien.TENNV LIKE N'%{0}%'", txtTimKiem.EditValue);

                dtTimKiemXe = xcontrol.timKiemXeDaBan(timKiem);
                gcTimKiemXeMay.DataSource = null;
                gcTimKiemXeMay.DataSource = dtTimKiemXe;
                gcTimKiemXeMay.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvTimKiemXeMay);
            }

            else if (cboTuyChonTimKiem.EditValue as string == "Xe có trong cửa hàng")
            {
                if (cboTimKiem.EditValue as string == "Mã xe") timKiem = string.Format("tblXe.MAXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên xe") timKiem = string.Format("tblTTXe.TENXE LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Màu xe") timKiem = string.Format("tblTTXe.MAUXE  LIKE N'%{0}%'", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Ngày nhập")
                {
                    try
                    {
                        timKiem = string.Format("tblNhap.NGAYNHAP = CONVERT(date, '{0}', 103)", dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0]);

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Ngày bạn nhập sai.\nVui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (cboTimKiem.EditValue as string == "Đơn giá") timKiem = string.Format("tblXe.DONGIABAN = {0}", txtTimKiem.EditValue);
                else if (cboTimKiem.EditValue as string == "Tên nhân viên") timKiem = string.Format("tblNhanVien.TENNV LIKE N'%{0}%'", txtTimKiem.EditValue);

                dtTimKiemXe = xcontrol.timKiemXeCoTrongCuaHang(timKiem);
                gcTimKiemXeMay.DataSource = null;
                gcTimKiemXeMay.DataSource = dtTimKiemXe;
                gcTimKiemXeMay.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvTimKiemXeMay);

            }
        }

        //Khi combobox tùy chọn thay đổi
        private void cboTuyChonTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuyChonTimKiem.EditValue as string == "Xe đã nhập")
            {
                cboTimKiem.Properties.Items.Clear();
                cboTimKiem.Properties.Items.Add("Tên xe");
                cboTimKiem.Properties.Items.Add("Màu xe");
                cboTimKiem.Properties.Items.Add("Tên nhân viên nhập");
                cboTimKiem.Properties.Items.Add("Ngày nhập");
                cboTimKiem.Text = "Tên xe";
            }
            else if (cboTuyChonTimKiem.EditValue as string == "Xe đã bán")
            {
                cboTimKiem.Properties.Items.Clear();
                cboTimKiem.Properties.Items.Add("Mã xe");
                cboTimKiem.Properties.Items.Add("Tên xe");
                cboTimKiem.Properties.Items.Add("Màu xe");
                cboTimKiem.Properties.Items.Add("Ngày bán");
                cboTimKiem.Properties.Items.Add("Tên khách hàng");
                cboTimKiem.Properties.Items.Add("Tên nhân viên");
                cboTimKiem.Text = "Mã xe";
            }
            else if (cboTuyChonTimKiem.EditValue as string == "Xe có trong cửa hàng")
            {
                cboTimKiem.Properties.Items.Clear();
                cboTimKiem.Properties.Items.Add("Mã xe");
                cboTimKiem.Properties.Items.Add("Tên xe");
                cboTimKiem.Properties.Items.Add("Màu xe");
                cboTimKiem.Properties.Items.Add("Ngày nhập");
                cboTimKiem.Properties.Items.Add("Đơn giá");
                cboTimKiem.Properties.Items.Add("Tên nhân viên");
                cboTimKiem.Text = "Mã xe";
            }
        }

        //Khi combobox tìm kiếm thay đổi
        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimKiem.EditValue = "";
            if (cboTimKiem.SelectedIndex == 3)
            {
                txtTimKiem.Visible = false;
                dateNgayNhap.Visible = true;
                dateNgayNhap.Size = new Size(201, 26);
                dateNgayNhap.Location = new Point(322, 100);
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
