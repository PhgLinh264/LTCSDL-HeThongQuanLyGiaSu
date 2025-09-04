using BusinessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.UserControlFolder
{
    public partial class ucKhoaHoc : UserControl
    {
        DoiTacBL doiTacBL;
        KhoaHocBL khoaHocBL;
        DangKyKH_BL dangKyKH_BL;
        ThamGiaKH_BL thamGiaKH_BL;
        HocVienBL hocVienBL;
        public ucKhoaHoc()
        {
            InitializeComponent();
            doiTacBL = new DoiTacBL();
            khoaHocBL = new KhoaHocBL();
            dangKyKH_BL = new DangKyKH_BL();
            thamGiaKH_BL = new ThamGiaKH_BL();
            hocVienBL = new HocVienBL();
        }
        private void LoadDataDoiTac()
        {
            List<DoiTac> dsDoiTac = doiTacBL.GetDoiTac();
            dgvDoiTac.DataSource = dsDoiTac;
            dgvDoiTac.Columns["KhoaHocs"].Visible = false;
            cboKH_MaDT.Items.Clear();
            //Thêm danh sách mã DT vào combobox
            var danhSachMaDT = khoaHocBL.GetDanhSachMaDT();
            cboKH_MaDT.Items.AddRange(danhSachMaDT.ToArray());
            cboKH_MaDT.SelectedIndex = -1;
        }
        private void LoadDataKhoaHoc()
        {
            List<KhoaHoc> dsKhoaHoc = khoaHocBL.GetKhoaHoc();
            dgvKhoaHoc.DataSource = dsKhoaHoc;
            dgvKhoaHoc.Columns["DoiTac"].Visible = false;
            dgvKhoaHoc.Columns["HocViens"].Visible = false;
            dgvKhoaHoc.Columns["KhuyenMai"].Visible = false;
            dgvKhoaHoc.Columns["MaKM"].Visible = false;
            dgvKhoaHoc.Columns["TienKM"].Visible = false;
            dgvKhoaHoc.Columns["DangKyKHs"].Visible = false;
            dgvKhoaHoc.Columns["ThamGiaKHs"].Visible = false;
            dgvKhoaHoc.Columns["DanhGiaKHs"].Visible = false;
        }
        private void LoadDataDangKy()
        {
            List<DangKyKH> dsKhoaHoc = dangKyKH_BL.GetDangKyKH();
            dgvDangKyKH.DataSource = dsKhoaHoc;
            //dgvDangKyKH.DataSource = dangKyKH_BL.GetDangKyKH().Select(dk => new { dk.MaDK, dk.MaPH,dk.MaKH,dk.NgayDangKy,dk.SoLuongHV}).ToList();
            dgvDangKyKH.Columns["KhoaHoc"].Visible = false;
            dgvDangKyKH.Columns["PhuHuynh"].Visible = false;
            //Thêm danh sách mã PH vào combobox
            cboDK_MaPH.Items.Clear();
            var danhSachMaPH = dangKyKH_BL.GetDanhSachMaPH();
            cboDK_MaPH.Items.AddRange(danhSachMaPH.ToArray());
            cboDK_MaPH.SelectedIndex = -1;
            //Thêm danh sách mã KH vào combobox
            cboDK_MaKH.Items.Clear();
            var danhSachMaKH = dangKyKH_BL.GetDanhSachMaKH();
            cboDK_MaKH.Items.AddRange(danhSachMaKH.ToArray());
            cboDK_MaKH.SelectedIndex = -1;
        }
        private void LoadDataHocVien()
        {
            List<ThamGiaKH> dsKhoaHoc = thamGiaKH_BL.GetThamGiaKH();
            dgvHocVien.DataSource = dsKhoaHoc;
            dgvHocVien.Columns["KhoaHoc"].Visible = false;
            dgvHocVien.Columns["HocVien"].Visible = false;

            cboHV_MaKH.Items.Clear();
            var danhSachMaKH = dangKyKH_BL.GetDanhSachMaKH();
            cboHV_MaKH.Items.AddRange(danhSachMaKH.ToArray());
            cboHV_MaKH.SelectedIndex = -1;

            //List<string> maKH_ChuaDuHV = dangKyKH_BL.GetDanhSachMaKH();

            //cboHV_MaKH.DataSource = null;
            //cboHV_MaKH.DataSource = maKH_ChuaDuHV;
            //cboHV_MaKH.SelectedIndex = -1;
            //cboHV_MaHV.Enabled = false;
        }
        private void ResetFormKhoaHoc()
        {
            txtKH_Ten.Text = "";
            txtKH_LinhVuc.Text = "";
            txtKH_ThoiGian.Text = "";
            txtKH_HocPhi.Text = "";
            cboKH_TrangThai.SelectedIndex = -1;
            cboKH_MaDT.SelectedIndex = -1;
        }
        private void ResetFormHocVien()
        {
            cboHV_MaKH.Enabled = true;
            cboHV_MaPH.SelectedIndex = -1;
            cboHV_MaHV.SelectedIndex = -1;
            cboHV_MaPH.Enabled = false;
            cboHV_MaHV.Enabled = false;
            cboHV_MaKH.SelectedIndex = -1;
            cboHV_MaHV.SelectedIndex = -1;
            lbHV_MaKH.Text = "Mã khóa học";
        }
        private void ucKhoaHoc_Load(object sender, EventArgs e)
        {
            LoadDataDoiTac();
            LoadDataKhoaHoc();
            LoadDataDangKy();
            LoadDataHocVien();
            cboKH_TimKiem.Items.Add("Mã khóa học");
            cboKH_TimKiem.Items.Add("Mã đối tác");
            cboDK_TimKiem.Items.Add("Mã khóa học");
            cboDK_TimKiem.Items.Add("Mã phụ huynh");
            cboHV_TimKiem.Items.Add("Mã khóa học");
            cboHV_TimKiem.Items.Add("Mã học viên");

            cboDT_TrangThai.Items.Add("Hoạt động");
            cboDT_TrangThai.Items.Add("Hủy HD");

            cboKH_TrangThai.Items.Add("Hoạt động");
            cboKH_TrangThai.Items.Add("Ngưng");

            dtpDK_NgayDK.Format = DateTimePickerFormat.Custom;
            dtpDK_NgayDK.CustomFormat = "dd/MM/yyyy";

            cboHV_MaPH.Enabled = false;
            cboHV_MaHV.Enabled = false;

        }

        private void btnDT_TimKiem_Click(object sender, EventArgs e)
        {
            var ketQua = doiTacBL.TimKiemDoiTac(txtDT_TuKhoa.Text.Trim());
            if (ketQua != null)
            {
                dgvDoiTac.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvDoiTac.Columns["KhoaHocs"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDT_HienThi_Click(object sender, EventArgs e)
        {
            //dgvDoiTac.DataSource = null;
            LoadDataDoiTac();
        }

        private void dgvDoiTac_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoiTac.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDoiTac.CurrentRow;

                // Lấy thông tin từ các cột và gán lên form
                txtDT_Ten.Text = row.Cells["TenDT"].Value?.ToString();
                txtDT_Email.Text = row.Cells["Email"].Value?.ToString();

                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                if (!string.IsNullOrEmpty(trangThai))
                    cboDT_TrangThai.SelectedItem = trangThai;
            }
        }

        private void btnDT_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Tạo đối tượng
            var dt = new DoiTac
            {
                MaDT = "0", // Mã đã tự sinh ra trong sql qua trigger
                TenDT = txtDT_Ten.Text.Trim(),
                Email = txtDT_Email.Text.Trim(),
                TrangThai = cboDT_TrangThai.SelectedItem.ToString()
            };
            bool kq = doiTacBL.ThemDoiTac(dt);
            if (kq)
            {
                MessageBox.Show("Thêm đối tác thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDoiTac();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDT_Update_Click(object sender, EventArgs e)
        {
            if (dgvDoiTac.CurrentRow == null) return;

            string maDT = dgvDoiTac.CurrentRow.Cells["MaDT"].Value?.ToString();
            var dt = new DoiTac
            {
                MaDT = maDT, 
                TenDT = txtDT_Ten.Text.Trim(),
                Email = txtDT_Email.Text.Trim(),
                TrangThai = cboDT_TrangThai.SelectedItem.ToString()
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = doiTacBL.CapNhatDoiTac(dt);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDoiTac(); // hoặc cập nhật lại lưới
                dgvDoiTac.DataSource = new List<object> { new { dt.MaDT, dt.TenDT, dt.Email, dt.TrangThai } };
                dgvDoiTac.Rows[0].Selected = true;
                dgvDoiTac.CurrentCell = dgvDoiTac.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKH_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboKH_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtKH_TuKhoa.Text.Trim();
            var ketQua = khoaHocBL.TimKiemKhoaHoc(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvKhoaHoc.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvKhoaHoc.Columns["DoiTac"].Visible = false;
                dgvKhoaHoc.Columns["HocViens"].Visible = false;
                dgvKhoaHoc.Columns["KhuyenMai"].Visible = false;
                dgvKhoaHoc.Columns["MaKM"].Visible = false;
                dgvKhoaHoc.Columns["TienKM"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKH_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataKhoaHoc();
            ResetFormKhoaHoc();
        }

        private void dgvKhoaHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoaHoc.CurrentRow == null || dgvKhoaHoc.CurrentRow.Index < 0) return;

            DataGridViewRow row = dgvKhoaHoc.CurrentRow;

            // Lấy thông tin từ các cột và gán lên form
            txtKH_Ten.Text = row.Cells["TenKH"].Value?.ToString();
            txtKH_LinhVuc.Text = row.Cells["LinhVuc"].Value?.ToString();
            txtKH_ThoiGian.Text = row.Cells["ThoiGian"].Value?.ToString();
            txtKH_HocPhi.Text = row.Cells["HocPhi"].Value?.ToString();

            string trangThai = row.Cells["TrangThai"].Value?.ToString();
            if (!string.IsNullOrEmpty(trangThai))
                cboKH_TrangThai.SelectedItem = trangThai;
            string maDT = row.Cells["MaDT"].Value?.ToString();
            if (!string.IsNullOrEmpty(maDT))
                cboKH_MaDT.SelectedItem = maDT;
        }

        private void btnKH_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Tạo đối tượng
            var kh = new KhoaHoc
            {
                MaKH = "0", // Mã đã tự sinh ra trong sql qua trigger
                TenKH = txtKH_Ten.Text.Trim(),
                LinhVuc = txtKH_LinhVuc.Text.Trim(),
                ThoiGian = txtKH_ThoiGian.Text.Trim(),
                HocPhi = int.Parse(txtKH_HocPhi.Text),
                TrangThai = cboKH_TrangThai.SelectedItem.ToString(),
                MaDT = cboKH_MaDT.SelectedItem.ToString(),
            };
            bool kq = khoaHocBL.ThemKhoaHoc(kh);
            if (kq)
            {
                MessageBox.Show("Thêm khóa học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKhoaHoc();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKH_Update_Click(object sender, EventArgs e)
        {
            if (dgvKhoaHoc.CurrentRow == null) return;

            string maKH = dgvKhoaHoc.CurrentRow.Cells["MaKH"].Value?.ToString();
            var kh = new KhoaHoc
            {
                MaKH = maKH, // Mã đã tự sinh ra trong sql qua trigger
                TenKH = txtKH_Ten.Text.Trim(),
                LinhVuc = txtKH_LinhVuc.Text.Trim(),
                ThoiGian = txtKH_ThoiGian.Text.Trim(),
                HocPhi = int.Parse(txtKH_HocPhi.Text),
                TrangThai = cboKH_TrangThai.SelectedItem.ToString(),
                MaDT = cboKH_MaDT.SelectedItem.ToString(),
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = khoaHocBL.CapNhatKhoaHoc(kh);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKhoaHoc(); // hoặc cập nhật lại lưới
                dgvKhoaHoc.DataSource = new List<object> { new { kh.MaKH, kh.TenKH, kh.LinhVuc, kh.ThoiGian, kh.HocPhi, kh.TrangThai, kh.MaDT } };
                dgvKhoaHoc.Rows[0].Selected = true;
                dgvKhoaHoc.CurrentCell = dgvKhoaHoc.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDK_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboDK_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtDK_TuKhoa.Text.Trim();
            var ketQua = dangKyKH_BL.TimKiemDangKyKH(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvDangKyKH.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvDangKyKH.Columns["KhoaHoc"].Visible = false;
                dgvDangKyKH.Columns["PhuHuynh"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDK_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataDangKy();
            cboHV_MaKH.Enabled = true;
            cboHV_MaKH.SelectedIndex = -1;
            cboHV_MaHV.SelectedIndex = -1;
            lbHV_MaKH.Text = "Mã khóa học";
        }

        private void dgvDangKyKH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDangKyKH.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDangKyKH.CurrentRow;

                // Lấy thông tin từ các cột và gán lên form
                txtDK_SoLuong.Text = row.Cells["SoLuongHV"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayDangKy"].Value?.ToString(), out DateTime ngayDK))
                {
                    dtpDK_NgayDK.Value = ngayDK.Date;
                }

                string maPH = row.Cells["MaPH"].Value?.ToString();
                if (!string.IsNullOrEmpty(maPH))
                    cboDK_MaPH.SelectedItem = maPH;

                string maKH = row.Cells["MaKH"].Value?.ToString();
                if (!string.IsNullOrEmpty(maKH))
                    cboDK_MaKH.SelectedItem = maKH;

                cboDK_MaPH.Enabled = false;
                cboDK_MaKH.Enabled = false;
            }
        }
        private void btnDK_Add_Click(object sender, EventArgs e)
        {
            string error;
            string maPH = cboDK_MaPH.Text;
            string maKH = cboDK_MaKH.Text;
            // Tạo đối tượng DangKyKH
            var dk = new DangKyKH
            {
                MaPH = maPH,
                MaKH = maKH,
                NgayDangKy = dtpDK_NgayDK.Value.Date,
                SoLuongHV = int.Parse(txtDK_SoLuong.Text)
            };
            // Gọi Business Layer để thêm
            bool kq = dangKyKH_BL.ThemDangKyKH(dk, out error);
            if (kq)
            {
                MessageBox.Show("Thêm đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDangKy(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDK_Update_Click(object sender, EventArgs e)
        {
            if (dgvDangKyKH.SelectedRows.Count > 0)
            {
                string error;
                string maPH = cboDK_MaPH.Text;
                string maKH = cboDK_MaKH.Text;
                // Tạo đối tượng
                var dk = new DangKyKH
                {
                    MaPH = maPH,
                    MaKH = maKH,
                    NgayDangKy = dtpDK_NgayDK.Value.Date,
                    SoLuongHV = int.Parse(txtDK_SoLuong.Text)
                };

                bool kq = dangKyKH_BL.CapNhatDangKyKH(dk, out error);
                if (kq)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataDangKy();
                    dgvDangKyKH.DataSource = new List<object> { new { dk.MaPH, dk.MaKH, dk.NgayDangKy, dk.SoLuongHV } };
                    dgvDangKyKH.Rows[0].Selected = true;
                    dgvDangKyKH.CurrentCell = dgvDangKyKH.Rows[0].Cells[0];
                }
                else
                {
                    MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
        private void LoadHocVienTheoDKKH(string maKH, string maPH)
        {
            var dangKyKH = dangKyKH_BL.GetDangKyKH().FirstOrDefault(k => k.MaKH == maKH && k.MaPH == maPH);
            if (dangKyKH == null)
            {
                cboHV_MaHV.DataSource = null;
                return;
            }

            var danhSachHocVien = thamGiaKH_BL.GetHocVienTheoMaPH(dangKyKH.MaPH);
            cboHV_MaHV.DataSource = (danhSachHocVien != null && danhSachHocVien.Count > 0) ? danhSachHocVien : null;
            if (danhSachHocVien != null && danhSachHocVien.Count > 0)
            {
                cboHV_MaHV.DisplayMember = "MaHV";
                cboHV_MaHV.ValueMember = "MaHV";
                cboHV_MaHV.SelectedIndex = -1;
            }
        }
        private void btnHV_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboHV_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtHV_TuKhoa.Text.Trim();

            var result = thamGiaKH_BL.TimKiemThamGiaKH(tieuChi, tuKhoa);
            if (result != null)
            {
                dgvHocVien.DataSource = result.ToList();
                dgvHocVien.Columns["KhoaHoc"].Visible = false;
                dgvHocVien.Columns["HocVien"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHV_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataHocVien();
        }
        private void cboHV_MaPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHV_MaPH.SelectedIndex >= 0 && cboHV_MaKH.SelectedIndex >= 0)
            {
                string maPH = cboHV_MaPH.SelectedItem?.ToString();
                string maKH = cboHV_MaKH.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(maPH) && !string.IsNullOrEmpty(maKH))
                {
                    LoadHocVienTheoDKKH(maKH, maPH);
                    cboHV_MaHV.Enabled = true;
                }
            }
            else
            {
                cboHV_MaHV.Enabled = false;
                cboHV_MaHV.DataSource = null; // Làm trống danh sách học viên
            }
        }
        private void cboHV_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHV_MaKH.Enabled && cboHV_MaKH.SelectedIndex >= 0)
            {
                string maKH = cboHV_MaKH.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(maKH))
                {
                    var danhSachMaPH = dangKyKH_BL.GetDanhSachMaPHtheoMaKH(maKH);
                    lbHV_MaKH.Text = maKH; // Gán MaLH vào Label
                    cboHV_MaPH.Enabled = true;
                    cboHV_MaPH.Items.Clear(); // Xóa cũ trước khi thêm mới
                    cboHV_MaPH.Items.AddRange(danhSachMaPH.ToArray());
                }
            }
            else
            {
                cboHV_MaPH.Enabled = false;
                cboHV_MaPH.Items.Clear(); // Xóa hết các phần tử
                //cboHV_MaHV.Items.Clear();
                cboHV_MaHV.Enabled = false;
                cboHV_MaHV.DataSource = null;
            }
        }
        private void btnHV_CapNhat_Click(object sender, EventArgs e)
        {
            if (dgvHocVien.CurrentRow == null) return;

            string maKH = cboHV_MaKH.Text;
            string maHV = cboHV_MaHV.Text;
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maHV))
            {
                MessageBox.Show("Thiếu thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            // Tạo đối tượng
            var tg = new ThamGiaKH
            {
                MaKH = maKH,
                MaHV = maHV,
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = thamGiaKH_BL.CapNhatThamGiaKH(tg, out string error);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHocVien(); // hoặc cập nhật lại lưới
                ResetFormHocVien();
                dgvHocVien.DataSource = new List<object> { new { tg.MaKH, tg.MaHV } };
                dgvHocVien.Rows[0].Selected = true;
                dgvHocVien.CurrentCell = dgvHocVien.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHV_Delete_Click(object sender, EventArgs e)
        {
            if (dgvHocVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHocVien.SelectedRows[0];

                string maKH = selectedRow.Cells["MaKH"].Value?.ToString();
                string maHV = selectedRow.Cells["MaHV"].Value?.ToString();

                if (!string.IsNullOrEmpty(maKH) && !string.IsNullOrEmpty(maHV))
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa học viên {maHV} khỏi khóa học {maKH}?","Xác nhận xóa",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bool xoaThanhCong = thamGiaKH_BL.XoaThamGiaKH(maHV, maKH);
                        if (xoaThanhCong)
                        {
                            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Tải lại dữ liệu sau khi xóa
                            LoadDataHocVien();
                            ResetFormHocVien();
                        }
                        else
                        {
                            MessageBox.Show("Chỉ được khóa khi chưa đánh giá Khóa học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void tabDoiTac_MouseClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem điểm click có nằm ngoài vùng DataGridView không
            if (!dgvDoiTac.Bounds.Contains(e.Location))
            {
                dgvDoiTac.ClearSelection();
                txtDT_Ten.Text = "";
                txtDT_Email.Text = "";
                cboDT_TrangThai.SelectedIndex = -1;
            }
        }
        private void tabKhoaHoc_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgvKhoaHoc.Bounds.Contains(e.Location))
            {
                dgvKhoaHoc.ClearSelection();
                ResetFormKhoaHoc();
            }
        }
        private void tabDangKy_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgvDangKyKH.Bounds.Contains(e.Location))
            {
                dgvDangKyKH.ClearSelection();
                cboDK_MaKH.SelectedIndex = -1;
                cboDK_MaPH.SelectedIndex = -1;
                txtDK_SoLuong.Text = "";
                dtpDK_NgayDK.Value = DateTime.Now;
                cboDK_MaPH.Enabled = true;
                cboDK_MaKH.Enabled = true;
            }
        }
        private void tabHocVien_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgvHocVien.Bounds.Contains(e.Location))
            {
                dgvHocVien.ClearSelection();
                ResetFormHocVien();
            }
        }

        private void btnDK_Delete_Click(object sender, EventArgs e)
        {
            if (dgvDangKyKH.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDangKyKH.SelectedRows[0];

                string maKH = selectedRow.Cells["MaKH"].Value?.ToString();
                string maPH = selectedRow.Cells["MaPH"].Value?.ToString();
                DateTime ngayDK = Convert.ToDateTime(selectedRow.Cells["NgayDangKy"].Value);

                if (!string.IsNullOrEmpty(maKH) && !string.IsNullOrEmpty(maPH))
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa thông tin?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bool xoaThanhCong = dangKyKH_BL.XoaDangKyKH(maPH, maKH, ngayDK);
                        if (xoaThanhCong)
                        {
                            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Tải lại dữ liệu sau khi xóa
                            LoadDataDangKy();
                        }
                        else
                        {
                            MessageBox.Show("Chỉ xóa khi chưa có học viên Tham gia và Đánh giá khóa học ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabKhoaH_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataDoiTac();
            LoadDataKhoaHoc();
            LoadDataDangKy();
            LoadDataHocVien();
        }
    }
}
