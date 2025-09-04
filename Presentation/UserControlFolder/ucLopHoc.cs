using BusinessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.HocBL;

namespace Presentation.UserControlFolder
{
    public partial class ucLopHoc : UserControl
    {
        GiaSuBL giaSuBL;
        LopHocBL lopHocBL;
        HocBL hocBL;
        public ucLopHoc()
        {
            InitializeComponent();
            giaSuBL = new GiaSuBL();
            lopHocBL = new LopHocBL();
            hocBL = new HocBL();
        }
        private void LoadDataGiaSu()
        {
            List<GiaSu> dsGiaSu = giaSuBL.GetGiaSu();
            dgvGiaSu.DataSource = dsGiaSu;
            dgvGiaSu.Columns["LopHocs"].Visible = false;

        }
        private void LoadDataLopHoc()
        {
            List<LopHoc> dsLopHoc = lopHocBL.GetLopHoc();
            dgvLopHoc.DataSource = dsLopHoc;
            //Ẩn cột không cần hiển thị 
            dgvLopHoc.Columns["PhuHuynh"].Visible = false;
            dgvLopHoc.Columns["MaKM"].Visible = false;
            dgvLopHoc.Columns["KhuyenMai"].Visible = false;
            dgvLopHoc.Columns["TienKM"].Visible = false;
            dgvLopHoc.Columns["GiaSu"].Visible = false;
            dgvLopHoc.Columns["Hocs"].Visible = false;
            dgvLopHoc.Columns["DanhGiaLHs"].Visible = false;

            cboLH_MaGS.Items.Clear();
            //Thêm danh sách mã GS vào combobox
            var danhSachMaGS = lopHocBL.GetDanhSachMaGS();
            cboLH_MaGS.Items.AddRange(danhSachMaGS.ToArray());
            cboLH_MaGS.SelectedIndex = -1;

        }
        private void LoadDataHoc()
        {
            List<Hoc> dsHoc = hocBL.GetHoc();
            dgvHoc.DataSource = dsHoc;

            dgvHoc.Columns["HocVien"].Visible = false;
            dgvHoc.Columns["LopHoc"].Visible = false;

            lbHV_MaLH.Text = "Mã lớp học";

            //// Lấy danh sách MaLH đã có trong bảng Hoc (đã gán học viên)
            //List<string> maLH_DaCoHoc = dsHoc.Select(h => h.MaLH).Distinct().ToList();
            //// Lấy danh sách tất cả MaLH từ bảng LopHoc
            //List<string> allMaLH = lopHocBL.GetDanhSachMaLH();
            //// Lọc ra những MaLH chưa có trong bảng Hoc
            //List<string> maLH_ChuaCoHoc = allMaLH.Except(maLH_DaCoHoc).ToList();
            //// Load các MaLH chưa có học viên vào ComboBox
            //cboHV_MaLH.DataSource = null;
            //cboHV_MaLH.DataSource = maLH_ChuaCoHoc;
            //cboHV_MaLH.SelectedIndex = -1;
            //cboHV_MaLH.Enabled = true; // Khi load ban đầu thì ComboBox được chọn bình thường

            List<string> maLH_ChuaDuHV = lopHocBL.GetDanhSachMaLH();

            cboHV_MaLH.DataSource = null;
            cboHV_MaLH.DataSource = maLH_ChuaDuHV;
            cboHV_MaLH.SelectedIndex = -1;
            cboHV_MaHV.Enabled = false;
        }
        private void ResetFormGiaSu()
        {
            cboGS_GioiTinh.SelectedIndex = -1;
            cboGS_XepHang.SelectedIndex = -1;
            txtGS_Hoten.Text = "";
            txtGS_DienThoai.Text = "";
            txtGS_DiaChi.Text = "";
            txtGS_DaiHoc.Text = "";
            txtGS_MonDay.Text = "";
            dtpGS_NgaySinh.Value = DateTime.Now;

        }
        private void ResetFormLopHoc()
        {
            cboLH_MaPH.SelectedIndex = -1;
            cboLH_MaGS.SelectedIndex = -1;
            cboLH_TrangThai.SelectedIndex = -1;
            txtLH_HocPhi.Text = "";
            txtLH_MonHoc.Text = "";
            txtLH_SoLuong.Text = "";
            txtLH_YeuCau.Text = "";
            txtLH_SoBuoi.Text = "";
            dtpLH_NgayDangKy.Value = DateTime.Now;
            dtpLH_NgayNhanLop.Value = DateTime.Now;
        }
        private void ucLopHoc_Load(object sender, EventArgs e)
        {
            LoadDataGiaSu();
            LoadDataLopHoc();
            LoadDataHoc();

            cboGS_TimKiem.Items.Add("Mã gia sư");
            cboGS_TimKiem.Items.Add("Giới tính");
            cboGS_TimKiem.Items.Add("Xếp hạng");

            cboGS_GioiTinh.Items.Add("Nam");
            cboGS_GioiTinh.Items.Add("Nữ");
            cboGS_GioiTinh.SelectedIndex = -1;

            cboGS_XepHang.Items.Add("Hạng A");
            cboGS_XepHang.Items.Add("Hạng B");
            cboGS_XepHang.Items.Add("Hạng C");
            cboGS_XepHang.Items.Add("");
            cboGS_XepHang.SelectedIndex = 3;


            cboLH_TimKiem.Items.Add("Mã lớp học");
            cboLH_TimKiem.Items.Add("Mã gia sư");
            cboLH_TimKiem.Items.Add("Mã phụ huynh");
            cboLH_TimKiem.SelectedIndex = -1;

            cboLH_TrangThai.Items.Add("Ngưng");
            cboLH_TrangThai.Items.Add("Hoạt động");
            cboLH_TrangThai.SelectedIndex = -1;


            cboLH_MaPH.Items.Clear();
            //Thêm danh sách mã PH vào combobox
            var danhSachMaPH = lopHocBL.GetDanhSachMaPH();
            cboLH_MaPH.Items.AddRange(danhSachMaPH.ToArray());
            cboLH_MaPH.SelectedIndex = -1;

            cboHV_TimKiem.Items.Add("Mã lớp học");
            cboHV_TimKiem.Items.Add("Mã học viên");
            cboHV_TimKiem.SelectedIndex = -1;

            dtpGS_NgaySinh.Format = DateTimePickerFormat.Custom;
            dtpGS_NgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpLH_NgayDangKy.Format = DateTimePickerFormat.Custom;
            dtpLH_NgayDangKy.CustomFormat = "dd/MM/yyyy";
            dtpLH_NgayNhanLop.Format = DateTimePickerFormat.Custom;
            dtpLH_NgayNhanLop.CustomFormat = "dd/MM/yyyy";

            toolTip_LuuY.SetToolTip(pbxLuuY, "Chỉ hiển thị lớp học chưa được thêm học viên");

        }
        private void btnGS_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboGS_TimKiem.SelectedItem?.ToString();
            string tuKhoa = txtGS_TuKhoa.Text.Trim();

            var ketQua = giaSuBL.TimKiemGiaSu(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvGiaSu.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvGiaSu.Columns["LopHocs"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGS_HienThi_Click(object sender, EventArgs e)
        {
            dgvGiaSu.DataSource = null;
            LoadDataGiaSu();
            ResetFormGiaSu();
        }

        private void btnLH_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboLH_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtLH_TuKhoa.Text.Trim();

            var result = lopHocBL.TimKiemLopHoc(tieuChi, tuKhoa);
            if (result != null)
            {
                dgvLopHoc.DataSource = result.ToList();
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnLH_HienThi_Click(object sender, EventArgs e)
        {
            dgvLopHoc.DataSource = null;
            LoadDataLopHoc();
            ResetFormLopHoc();
        }
        private void dgvGiaSu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGiaSu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvGiaSu.CurrentRow;

                // Lấy thông tin từ các cột và gán lên form
                txtGS_Hoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtGS_DienThoai.Text = row.Cells["SDT"].Value?.ToString();
                txtGS_DiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtGS_DaiHoc.Text = row.Cells["DaiHoc"].Value?.ToString();
                txtGS_MonDay.Text = row.Cells["MonDay"].Value?.ToString();

                // Ngày sinh của gia sư
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                {
                    dtpGS_NgaySinh.Value = ngaySinh.Date;
                }

                // ComboBox GioiTinh
                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                if (!string.IsNullOrEmpty(gioiTinh))
                    cboGS_GioiTinh.SelectedItem = gioiTinh;

                // ComboBox XepHang
                string xepHang = row.Cells["XepHang"].Value?.ToString();
                if (!string.IsNullOrEmpty(xepHang))
                    cboGS_XepHang.SelectedItem = xepHang;
                else
                    cboGS_XepHang.SelectedIndex = 3;

                //cboLH_MaGS.Enabled = false;
            }

        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLopHoc.CurrentRow;

                // Lấy thông tin từ các cột và gán lên form
                txtLH_HocPhi.Text = row.Cells["HocPhi"].Value?.ToString();
                txtLH_MonHoc.Text = row.Cells["MonHoc"].Value?.ToString();
                txtLH_SoLuong.Text = row.Cells["SoLuongHV"].Value?.ToString();
                txtLH_YeuCau.Text = row.Cells["YeuCau"].Value?.ToString();
                txtLH_SoBuoi.Text = row.Cells["SoBuoi"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayDangKy"].Value?.ToString(), out DateTime ngayDangKy))
                {
                    dtpLH_NgayDangKy.Value = ngayDangKy.Date;
                }
                if (DateTime.TryParse(row.Cells["NgayNhanLop"].Value?.ToString(), out DateTime ngayNhanLop))
                {
                    dtpLH_NgayNhanLop.Value = ngayNhanLop.Date;
                }
                string maGS = row.Cells["MaGS"].Value?.ToString();
                if (!string.IsNullOrEmpty(maGS))
                    cboLH_MaGS.SelectedItem = maGS;
                string maPH = row.Cells["MaPH"].Value?.ToString();
                if (!string.IsNullOrEmpty(maPH))
                    cboLH_MaPH.SelectedItem = maPH;
                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                if (!string.IsNullOrEmpty(trangThai))
                    cboLH_TrangThai.SelectedItem = trangThai;
            }
            
                
        }

        private void btnGS_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Tạo đối tượng
            var gs = new GiaSu
            {
                MaGS = "0", // Mã đã tự sinh ra trong sql qua trigger
                HoTen = txtGS_Hoten.Text.Trim(),
                SDT = txtGS_DienThoai.Text.Trim(),
                DiaChi = txtGS_DiaChi.Text.Trim(),
                GioiTinh = cboGS_GioiTinh.SelectedItem.ToString(),
                NgaySinh = dtpGS_NgaySinh.Value.Date,
                DaiHoc = txtGS_DaiHoc.Text.Trim(),
                MonDay = txtGS_MonDay.Text.Trim()
            };
            bool kq = giaSuBL.ThemGiaSu(gs);
            if (kq)
            {
                MessageBox.Show("Thêm gia sư thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGiaSu();
            }
            else
            {
                MessageBox.Show("Thiếu thông tin hoặc gia sư đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGS_Update_Click(object sender, EventArgs e)
        {
            if (dgvGiaSu.CurrentRow == null) return;

            string maGS = dgvGiaSu.CurrentRow.Cells["MaGS"].Value?.ToString();
            var gs = new GiaSu
            {
                MaGS = maGS,
                HoTen = txtGS_Hoten.Text.Trim(),
                SDT = txtGS_DienThoai.Text.Trim(),
                DiaChi = txtGS_DiaChi.Text.Trim(),
                GioiTinh = cboGS_GioiTinh.SelectedItem.ToString(),
                NgaySinh = dtpGS_NgaySinh.Value.Date,
                DaiHoc = txtGS_DaiHoc.Text.Trim(),
                MonDay = txtGS_MonDay.Text.Trim(),
                XepHang = cboGS_XepHang.SelectedItem.ToString()
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = giaSuBL.CapNhatGiaSu(gs);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGiaSu(); // hoặc cập nhật lại lưới
                dgvGiaSu.DataSource = new List<object> { new { gs.MaGS, gs.HoTen, gs.SDT, gs.DiaChi, gs.GioiTinh, gs.NgaySinh, gs.DaiHoc, gs.MonDay, gs.TrangThai, gs.XepHang } };
                dgvGiaSu.Rows[0].Selected = true;
                dgvGiaSu.CurrentCell = dgvGiaSu.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLH_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;
            string error;
            // Tạo đối tượng
            var lh = new LopHoc
            {
                MaLH = "0", // Mã đã tự sinh ra trong sql qua trigger
                MaGS = cboLH_MaGS.SelectedItem.ToString(),
                MaPH = cboLH_MaPH.SelectedItem.ToString(),
                MonHoc = txtLH_MonHoc.Text.Trim(),
                SoBuoi = int.Parse(txtLH_SoBuoi.Text),
                HocPhi = int.Parse(txtLH_HocPhi.Text),
                TrangThai = cboLH_TrangThai.SelectedItem.ToString(),
                NgayNhanLop = dtpLH_NgayNhanLop.Value.Date,
                SoLuongHV = int.Parse(txtLH_SoLuong.Text),
                NgayDangKy = dtpLH_NgayDangKy.Value.Date,
                YeuCau = txtLH_YeuCau.Text.Trim()
            };
            bool kq = lopHocBL.ThemLopHoc(lh, out error);
            if (kq)
            {
                MessageBox.Show("Thêm lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataLopHoc();
                ResetFormLopHoc();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLH_Update_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow == null) return;

            string maLH = dgvLopHoc.CurrentRow.Cells["MaLH"].Value?.ToString();
            var lh = new LopHoc
            {
                MaLH = maLH,
                MaGS = cboLH_MaGS.SelectedItem.ToString(),
                MaPH = cboLH_MaPH.SelectedItem.ToString(),
                MonHoc = txtLH_MonHoc.Text.Trim(),
                SoBuoi = int.Parse(txtLH_SoBuoi.Text),
                HocPhi = int.Parse(txtLH_HocPhi.Text),
                TrangThai = cboLH_TrangThai.SelectedItem.ToString(),
                NgayNhanLop = dtpLH_NgayNhanLop.Value.Date,
                SoLuongHV = int.Parse(txtLH_SoLuong.Text),
                NgayDangKy = dtpLH_NgayDangKy.Value.Date,
                YeuCau = txtLH_YeuCau.Text.Trim()
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = lopHocBL.CapNhatLopHoc(lh, out string error);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataLopHoc(); // hoặc cập nhật lại lưới
                dgvLopHoc.DataSource = new List<object> { new { lh.MaLH, lh.MaGS, lh.MaPH, lh.MonHoc, lh.SoBuoi, lh.HocPhi, lh.TrangThai, lh.NgayNhanLop, lh.SoLuongHV, lh.NgayDangKy, lh.YeuCau } };
                dgvLopHoc.Rows[0].Selected = true;
                dgvLopHoc.CurrentCell = dgvLopHoc.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHocVienTheoMaLH(string maLH)
        {
            var lopHoc = lopHocBL.GetLopHoc().FirstOrDefault(l => l.MaLH == maLH);
            if (lopHoc == null)
            {
                cboHV_MaHV.DataSource = null;
                return;
            }

            var danhSachHocVien = hocBL.GetDanhSachHocVienTheoMaPH(lopHoc.MaPH);
            cboHV_MaHV.DataSource = (danhSachHocVien != null && danhSachHocVien.Count > 0) ? danhSachHocVien : null;
            if (danhSachHocVien != null && danhSachHocVien.Count > 0)
            {
                cboHV_MaHV.DisplayMember = "MaHV";
                cboHV_MaHV.ValueMember = "MaHV";
                cboHV_MaHV.SelectedIndex = -1;
            }
        }
        private void dgvHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoc.SelectedRows.Count > 0)
            {
                // Lấy MaLH từ dòng được chọn
                string maLH = dgvHoc.SelectedRows[0].Cells["MaLH"].Value?.ToString();
                if (!string.IsNullOrEmpty(maLH))
                {
                    lbHV_MaLH.Text = maLH; // Gán MaLH vào Label
                    cboHV_MaLH.Enabled = false; // Khóa ComboBox
                    LoadHocVienTheoMaLH(maLH);
                }
            }
        }

        private void cboHV_MaLH_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboHV_MaLH.Enabled && cboHV_MaLH.SelectedIndex >= 0)
            {
                string maLH = cboHV_MaLH.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(maLH))
                {
                    lbHV_MaLH.Text = maLH; // Gán MaLH vào Label
                    cboHV_MaHV.Enabled = true;
                    LoadHocVienTheoMaLH(maLH);
                }
            }
        }

        private void btnHV_HienThi_Click(object sender, EventArgs e)
        {
            dgvHoc.DataSource = null;
            LoadDataHoc();
            //cboHV_MaLH.Enabled = true;
            //lbHV_MaLH.Text = "Mã lớp học";
        }
        private void btnHV_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboHV_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtHV_TuKhoa.Text.Trim();

            var result = hocBL.TimKiemHoc(tieuChi, tuKhoa);
            if (result != null)
            {
                dgvHoc.DataSource = result.ToList();
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHV_CapNhat_Click(object sender, EventArgs e)
        {
            string maLH = lbHV_MaLH.Text.Trim();
            var hoc = new Hoc
            {
                MaLH = maLH,
                MaHV = cboHV_MaHV.SelectedValue.ToString()
            };
            var ketQua = hocBL.CapNhatHoc(hoc, out string error);
            if (ketQua)
            {
                MessageBox.Show("Thêm học viên vào lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHoc();
                lbHV_MaLH.Text = "Mã lớp học";
                cboHV_MaHV.SelectedIndex = -1;
                cboHV_MaHV.Enabled = false;
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabGiaSu_MouseClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem điểm click có nằm ngoài vùng DataGridView không
            if (!dgvGiaSu.Bounds.Contains(e.Location))
            {
                dgvGiaSu.ClearSelection();
                cboGS_XepHang.SelectedIndex = 3;
                ResetFormGiaSu();
            }
        }


        private void tabHocVien_MouseClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem điểm click có nằm ngoài vùng DataGridView không
            if (!dgvHoc.Bounds.Contains(e.Location))
            {
                dgvHoc.ClearSelection();
                cboHV_MaLH.Enabled = true;
                lbHV_MaLH.Text = "Mã lớp học";
            }
        }

        private void tabLopHoc_LH_MouseClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem điểm click có nằm ngoài vùng DataGridView không
            if (!dgvLopHoc.Bounds.Contains(e.Location))
            {
                dgvLopHoc.ClearSelection();
                ResetFormLopHoc();
            }
        }

        private void btnHV_Delete_Click(object sender, EventArgs e)
        {
            if (dgvHoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHoc.SelectedRows[0];

                string maLH = selectedRow.Cells["MaLH"].Value?.ToString();
                string maHV = selectedRow.Cells["MaHV"].Value?.ToString();

                if (!string.IsNullOrEmpty(maLH) && !string.IsNullOrEmpty(maHV))
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa học viên {maHV} khỏi khóa học {maLH}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bool xoaThanhCong = hocBL.XoaDangKyHoc(maLH, maHV);
                        if (xoaThanhCong)
                        {
                            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Tải lại dữ liệu sau khi xóa
                            LoadDataHoc();
                            lbHV_MaLH.Text = "Mã lớp học";
                            cboHV_MaHV.SelectedIndex = -1;
                            cboHV_MaHV.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Chỉ được xóa khi chưa đánh giá lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGiaSu();
            LoadDataLopHoc();
            LoadDataHoc();
        }
    }
    
}
