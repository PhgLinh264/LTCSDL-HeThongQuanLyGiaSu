using BusinessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.UserControlFolder
{
    public partial class ucKhuyenMai : UserControl
    {
        KhuyenMaiBL khuyenMaiBL;
        KhuyenMaiLopHoc_BL kmLopHoc_BL;
        KhuyenMaiKhoaHoc_BL kmKhoaHoc_BL;
        public ucKhuyenMai()
        {
            InitializeComponent();
            khuyenMaiBL = new KhuyenMaiBL();
            kmLopHoc_BL = new KhuyenMaiLopHoc_BL();
            kmKhoaHoc_BL = new KhuyenMaiKhoaHoc_BL();
        }
        private void LoadDataKhuyenMai()
        {
            List<KhuyenMai> dsKM = khuyenMaiBL.GetKhuyenMai();
            dgvKhuyenMai.DataSource = dsKM;
            dgvKhuyenMai.Columns["KhoaHocs"].Visible = false;
            dgvKhuyenMai.Columns["LopHocs"].Visible = false;
        }
        private void LoadDataKMLopHoc()
        {
            List<LopHoc> dsKMLH = kmLopHoc_BL.GetLopHoc();
            dgvLopHoc.DataSource = dsKMLH;
            dgvLopHoc.Columns["MonHoc"].Visible = false;
            dgvLopHoc.Columns["SoBuoi"].Visible = false;
            dgvLopHoc.Columns["MaGS"].Visible = false;
            dgvLopHoc.Columns["SoLuongHV"].Visible = false;
            dgvLopHoc.Columns["NgayNhanLop"].Visible = false;
            dgvLopHoc.Columns["YeuCau"].Visible = false;
            dgvLopHoc.Columns["PhuHuynh"].Visible = false;
            dgvLopHoc.Columns["KhuyenMai"].Visible = false;
            dgvLopHoc.Columns["GiaSu"].Visible = false;
            dgvLopHoc.Columns["Hocs"].Visible = false;
            dgvLopHoc.Columns["DanhGiaLHs"].Visible = false;

            cboLH_MaKM.Items.Clear();
            //Thêm danh sách mã KM vào combobox
            var danhSachMaKM = khuyenMaiBL.GetDanhSachMaKM();
            cboLH_MaKM.Items.AddRange(danhSachMaKM.ToArray());
            cboLH_MaKM.SelectedIndex = -1;
        }
        private void LoadDataKMKhoaHoc()
        {
            List<KhoaHoc> dsKMKH = kmKhoaHoc_BL.GetKhoaHoc();
            dgvKhoaHoc.DataSource = dsKMKH;
            dgvKhoaHoc.Columns["LinhVuc"].Visible = false;
            dgvKhoaHoc.Columns["ThoiGian"].Visible = false;
            dgvKhoaHoc.Columns["DoiTac"].Visible = false;
            dgvKhoaHoc.Columns["KhuyenMai"].Visible = false;
            dgvKhoaHoc.Columns["DangKyKHs"].Visible = false;
            dgvKhoaHoc.Columns["ThamGiaKHs"].Visible = false;
            dgvKhoaHoc.Columns["HocViens"].Visible = false;
            dgvKhoaHoc.Columns["DanhGiaKHs"].Visible = false;

            //Thêm danh sách mã KM vào combobox
            var danhSachMaKM = khuyenMaiBL.GetDanhSachMaKM();
            cboKH_MaKM.Items.Clear();
            cboKH_MaKM.Items.AddRange(danhSachMaKM.ToArray());
            cboKH_MaKM.SelectedIndex = -1;
        }
        private void ResetFormLopHoc()
        {
            lbLH_MaLH.Text = "Mã lớp học";
            lbLH_PhanTram.Text = "0%";
            lbLH_SoTienKM.Text = "0";
        }
        private void ResetFormKhoaHoc()
        {
            lbKH_MaKH.Text = "Mã khóa học";
            lbKH_PhanTram.Text = "0%";
            lbKH_SoTienKM.Text = "0";
        }
        private void ucKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadDataKhuyenMai();
            LoadDataKMLopHoc();
            LoadDataKMKhoaHoc();

            cboLH_TimKiem.Items.Add("Mã lớp học");
            cboLH_TimKiem.Items.Add("Mã phụ huynh");
            cboKH_TimKiem.Items.Add("Mã khóa học");
        }
        private void btnKM_Add_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng
            var km = new KhuyenMai
            {
                MaKM = txtKM_MaKM.Text,
                PhanTram = int.Parse(txtKM_PhanTram.Text.Trim())
            };
            bool kq = khuyenMaiBL.ThemKhuyenMai(km);
            if (kq)
            {
                MessageBox.Show("Thêm khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKhuyenMai();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng nhập phần trăm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow == null || dgvLopHoc.CurrentRow.Index < 0) return;

            DataGridViewRow row = dgvLopHoc.CurrentRow;

            // Lấy thông tin từ các cột và gán lên form
            string maLH = row.Cells["MaLH"].Value?.ToString();
            string maKM = row.Cells["MaKM"].Value?.ToString();
            lbLH_MaLH.Text = maLH;
            cboLH_MaKM.SelectedItem = maKM;

            if (!string.IsNullOrEmpty(maKM))
            {
                string phanTramStr = khuyenMaiBL.GetPhanTram(maKM);
                lbLH_PhanTram.Text = phanTramStr + "%";
                if (int.TryParse(row.Cells["HocPhi"].Value?.ToString(), out int hocPhi) &&
            int.TryParse(phanTramStr, out int phanTram))
                {
                    int soTienKM = hocPhi * phanTram / 100;
                    lbLH_SoTienKM.Text = soTienKM.ToString();
                }
                else
                {
                    lbLH_SoTienKM.Text = "0";
                }
            }
            else
            {
                lbLH_PhanTram.Text = "0%";
                lbLH_SoTienKM.Text = "0";
            }
        }
        private void cboLH_MaKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLH_MaKM.SelectedItem != null)
            {
                string maKM = cboLH_MaKM.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(maKM))
                {
                    string phanTramStr = khuyenMaiBL.GetPhanTram(maKM);
                    lbLH_PhanTram.Text = phanTramStr + "%";
                    if (int.TryParse(dgvLopHoc.CurrentRow.Cells["HocPhi"].Value?.ToString(), out int hocPhi) &&
                int.TryParse(phanTramStr, out int phanTram))
                    {
                        int soTienKM = hocPhi * phanTram / 100;
                        lbLH_SoTienKM.Text = soTienKM.ToString();
                    }
                    else
                    {
                        lbLH_SoTienKM.Text = "0";
                    }
                }
                else
                {
                    lbLH_PhanTram.Text = "0%";
                    lbLH_SoTienKM.Text = "0";
                }
            }
        }

        private void btnLH_UpdateKM_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow == null) return;

            string maLH = dgvLopHoc.CurrentRow.Cells["MaLH"].Value?.ToString();
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Tạo đối tượng
            var km = new LopHoc
            {
                MaLH = maLH,
                MaKM = cboLH_MaKM.SelectedItem.ToString(),
                TienKM = int.Parse(lbLH_SoTienKM.Text.Trim())
            };
            bool kq = kmLopHoc_BL.CapNhatKhuyenMai(km);
            if (kq)
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKMLopHoc();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLH_DeleteKM_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow == null) return;

            string maLH = dgvLopHoc.CurrentRow.Cells["MaLH"].Value?.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn XÓA khuyến mãi khỏi lớp học này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = kmLopHoc_BL.XoaKhuyenMaiKhoiLopHoc(maLH);
            if (kq)
            {
                MessageBox.Show("Xóa khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKMLopHoc();
            }
            else
            {
                MessageBox.Show("Thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhoaHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoaHoc.CurrentRow == null || dgvKhoaHoc.CurrentRow.Index < 0) return;

            DataGridViewRow row = dgvKhoaHoc.CurrentRow;

            // Lấy thông tin từ các cột và gán lên form
            string maKH = row.Cells["MaKH"].Value?.ToString();
            string maKM = row.Cells["MaKM"].Value?.ToString();
            lbKH_MaKH.Text = maKH;
            cboKH_MaKM.SelectedItem = maKM;

            if (!string.IsNullOrEmpty(maKM))
            {
                string phanTramStr = khuyenMaiBL.GetPhanTram(maKM);
                lbKH_PhanTram.Text = phanTramStr + "%";
                if (int.TryParse(row.Cells["HocPhi"].Value?.ToString(), out int hocPhi) &&
            int.TryParse(phanTramStr, out int phanTram))
                {
                    int soTienKM = hocPhi * phanTram / 100;
                    lbKH_SoTienKM.Text = soTienKM.ToString();
                }
                else
                {
                    lbKH_SoTienKM.Text = "0";
                }
            }
            else
            {
                lbKH_PhanTram.Text = "0%";
                lbKH_SoTienKM.Text = "0";
            }
        }

        private void cboKH_MaKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKH_MaKM.SelectedItem != null)
            {
                string maKM = cboKH_MaKM.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(maKM))
                {
                    string phanTramStr = khuyenMaiBL.GetPhanTram(maKM);
                    lbKH_PhanTram.Text = phanTramStr + "%";
                    if (int.TryParse(dgvKhoaHoc.CurrentRow.Cells["HocPhi"].Value?.ToString(), out int hocPhi) &&
                int.TryParse(phanTramStr, out int phanTram))
                    {
                        int soTienKM = hocPhi * phanTram / 100;
                        lbKH_SoTienKM.Text = soTienKM.ToString();
                    }
                    else
                    {
                        lbKH_SoTienKM.Text = "0";
                    }
                }
                else
                {
                    lbKH_PhanTram.Text = "0%";
                    lbKH_SoTienKM.Text = "0";
                }
            }
        }

        private void btnKH_UpdateKM_Click(object sender, EventArgs e)
        {
            if (dgvKhoaHoc.CurrentRow == null) return;

            string maKH = dgvKhoaHoc.CurrentRow.Cells["MaKH"].Value?.ToString();
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Tạo đối tượng
            var kh = new KhoaHoc
            {
                MaKH = maKH,
                MaKM = cboKH_MaKM.SelectedItem.ToString(),
                TienKM = int.Parse(lbKH_SoTienKM.Text.Trim())
            };
            bool kq = kmKhoaHoc_BL.CapNhatKhuyenMai(kh);
            if (kq)
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKMKhoaHoc();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKH_DeleteKM_Click(object sender, EventArgs e)
        {
            if (dgvKhoaHoc.CurrentRow == null) return;

            string maKH = dgvKhoaHoc.CurrentRow.Cells["MaKH"].Value?.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn XÓA khuyến mãi khỏi khóa học này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = kmKhoaHoc_BL.XoaKhuyenMaiKhoiKhoaHoc(maKH);
            if (kq)
            {
                MessageBox.Show("Xóa khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKMKhoaHoc();
            }
            else
            {
                MessageBox.Show("Thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLH_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboLH_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtLH_TuKhoa.Text.Trim();
            var ketQua = kmLopHoc_BL.TimKiem(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvLopHoc.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvLopHoc.Columns["MonHoc"].Visible = false;
                dgvLopHoc.Columns["SoBuoi"].Visible = false;
                dgvLopHoc.Columns["MaGS"].Visible = false;
                dgvLopHoc.Columns["SoLuongHV"].Visible = false;
                dgvLopHoc.Columns["NgayNhanLop"].Visible = false;
                dgvLopHoc.Columns["YeuCau"].Visible = false;
                dgvLopHoc.Columns["PhuHuynh"].Visible = false;
                dgvLopHoc.Columns["KhuyenMai"].Visible = false;
                dgvLopHoc.Columns["GiaSu"].Visible = false;
                dgvLopHoc.Columns["Hocs"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLH_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataKMLopHoc();
        }

        private void btnKH_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboKH_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtKH_TuKhoa.Text.Trim();
            var ketQua = kmKhoaHoc_BL.TimKiem(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvKhoaHoc.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvKhoaHoc.Columns["LinhVuc"].Visible = false;
                dgvKhoaHoc.Columns["ThoiGian"].Visible = false;
                dgvKhoaHoc.Columns["DoiTac"].Visible = false;
                dgvKhoaHoc.Columns["KhuyenMai"].Visible = false;
                dgvKhoaHoc.Columns["DangKyKHs"].Visible = false;
                dgvKhoaHoc.Columns["ThamGiaKHs"].Visible = false;
                dgvKhoaHoc.Columns["HocViens"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKH_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataKMKhoaHoc();
        }

        private void tabKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataKhuyenMai();
            LoadDataKMLopHoc();
            LoadDataKMKhoaHoc();
        }
    }
}
