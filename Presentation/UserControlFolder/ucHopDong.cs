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
    public partial class ucHopDong : UserControl
    {
        HopDongPH_BL hopDongPHBL;
        HopDongGS_BL hopDongGSBL;
        DanhGiaLH_BL danhGiaLH_BL;
        DanhGiaKH_BL danhGiaKH_BL;
        public ucHopDong()
        {
            InitializeComponent();
            hopDongPHBL = new HopDongPH_BL();
            hopDongGSBL = new HopDongGS_BL();
            danhGiaLH_BL = new DanhGiaLH_BL();
            danhGiaKH_BL = new DanhGiaKH_BL();
        }
        private void LoadDataHopDongPH()
        {
            List<HopDongPH> dsHD = hopDongPHBL.GetHopDongPH();
            dgvPhuHuynh.DataSource = dsHD;
            dgvPhuHuynh.Columns["PhuHuynh"].Visible = false;
            //Thêm danh sách mã vào combobox
            cboPH_MaPH.Items.Clear();
            var danhSachMaPH = hopDongPHBL.GetMaPH();
            cboPH_MaPH.Items.AddRange(danhSachMaPH.ToArray());
            cboPH_MaPH.SelectedIndex = -1;
            dtpPH_NgayHuy.Enabled = false;
            txtPH_LyDo.Enabled = false;
        }
        private void LoadDataHopDongGS()
        {
            List<HopDongGS> dsHD = hopDongGSBL.GetHopDongGS();
            dgvGiaSu.DataSource = dsHD;
            dgvGiaSu.Columns["GiaSu"].Visible = false;
            //Thêm danh sách mã vào combobox
            cboGS_MaGS.Items.Clear();
            var danhSachMaGS = hopDongGSBL.GetMaGS();
            cboGS_MaGS.Items.AddRange(danhSachMaGS.ToArray());
            cboGS_MaGS.SelectedIndex = -1;

            dtpGS_NgayHuy.Enabled = false;
            txtGS_LyDo.Enabled = false;
        }
        private void LoadDataDanhGiaLH()
        {
            List<DanhGiaLH> dsDGLH = danhGiaLH_BL.GetDanhGiaLH();
            dgvDanhGiaLH.DataSource = dsDGLH;
            dgvDanhGiaLH.Columns["HocVien"].Visible = false;
            dgvDanhGiaLH.Columns["LopHoc"].Visible = false;
            dgvDanhGiaLH.Columns["PhuHuynh"].Visible = false;
            cboDGLH_MaLH.Text = "";
            cboDGLH_MaHV.Enabled = false;
            cboDGLH_MaLH.Enabled = false;

            var danhSachMaPH = danhGiaLH_BL.GetDanhSachMaPH();
            cboDGLH_MaPH.Items.Clear();
            cboDGLH_MaPH.Items.AddRange(danhSachMaPH.ToArray());
            cboDGLH_MaPH.SelectedIndex = -1;
        }
        private void LoadDataDanhGiaKH()
        {
            List<DanhGiaKH> dsDGKH = danhGiaKH_BL.GetDanhGiaKH();
            dgvDanhGiaKH.DataSource = dsDGKH;
            dgvDanhGiaKH.Columns["HocVien"].Visible = false;
            dgvDanhGiaKH.Columns["KhoaHoc"].Visible = false;
            dgvDanhGiaKH.Columns["PhuHuynh"].Visible = false;
            cboDGKH_MaKH.Text = "";
            cboDGKH_MaHV.Enabled = false;
            cboDGKH_MaKH.Enabled = false;

            var danhSachMaPH = danhGiaLH_BL.GetDanhSachMaPH();
            cboDGKH_MaPH.Items.Clear();
            cboDGKH_MaPH.Items.AddRange(danhSachMaPH.ToArray());
            cboDGKH_MaPH.SelectedIndex = -1;
        }
        private void ResetFormDGLH()
        {
            cboDGLH_MaPH.SelectedIndex = -1;
            cboDGLH_MaHV.SelectedIndex = -1;
            txtDGLH_DiemHV.Text = null;
            txtDGLH_DiemDG.Text = null;
            cboDGLH_LoaiDG.SelectedIndex = -1;
            cboDGLH_MaHV.Enabled = false;
            cboDGLH_MaPH.Enabled = true;
            cboDGLH_MaLH.Enabled = false;
        }
        private void ResetFormDGKH()
        {
            cboDGKH_MaPH.SelectedIndex = -1;
            cboDGKH_MaHV.SelectedIndex = -1;
            txtDGKH_DiemHV.Text = null;
            txtDGKH_DiemDG.Text = null;
            cboDGKH_LoaiDG.SelectedIndex = -1;
            cboDGKH_MaHV.Enabled = false;
            cboDGKH_MaPH.Enabled = true;
            cboDGKH_MaKH.Enabled = false;
        }
        private void ucHopDong_Load(object sender, EventArgs e)
        {
            LoadDataHopDongPH();
            LoadDataHopDongGS();
            LoadDataDanhGiaLH();
            LoadDataDanhGiaKH();

            dgvPhuHuynh.ClearSelection();
            dgvPhuHuynh.CurrentCell = null;
            dgvGiaSu.ClearSelection();
            dgvGiaSu.CurrentCell = null;
            dgvDanhGiaLH.ClearSelection();
            dgvDanhGiaLH.CurrentCell = null;
            dgvDanhGiaKH.ClearSelection();
            dgvDanhGiaKH.CurrentCell = null;

            cboDGLH_LoaiDG.Items.Add("Không tốt");
            cboDGLH_LoaiDG.Items.Add("Bình thường");
            cboDGLH_LoaiDG.Items.Add("Tốt");
            cboDGKH_LoaiDG.Items.Add("Không tốt");
            cboDGKH_LoaiDG.Items.Add("Bình thường");
            cboDGKH_LoaiDG.Items.Add("Tốt");

            cboDGKH_TimKiem.Items.Add("Mã phụ huynh");
            cboDGKH_TimKiem.Items.Add("Mã học viên");
            cboDGKH_TimKiem.Items.Add("Mã khóa học");
            cboDGLH_TimKiem.Items.Add("Mã phụ huynh");
            cboDGLH_TimKiem.Items.Add("Mã học viên");
            cboDGLH_TimKiem.Items.Add("Mã lớp học");

            dtpPH_NgayKy.Format = DateTimePickerFormat.Custom;
            dtpPH_NgayKy.CustomFormat = "dd/MM/yyyy";
            dtpGS_NgayKy.Format = DateTimePickerFormat.Custom;
            dtpGS_NgayKy.CustomFormat = "dd/MM/yyyy";

            dtpPH_NgayHuy.Format = DateTimePickerFormat.Custom;
            dtpPH_NgayHuy.CustomFormat = "dd/MM/yyyy";
            dtpGS_NgayHuy.Format = DateTimePickerFormat.Custom;
            dtpGS_NgayHuy.CustomFormat = "dd/MM/yyyy";
        }

        private void btnPH_TimKiem_Click(object sender, EventArgs e)
        {
            var ketQua = hopDongPHBL.TimKiemHopDongPH(txtPH_TuKhoa.Text.Trim());
            if (ketQua != null)
            {
                dgvPhuHuynh.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvPhuHuynh.Columns["PhuHuynh"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnPH_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataHopDongPH();
        }

        private void dgvPhuHuynh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhuHuynh.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPhuHuynh.SelectedRows[0];

                // Gán mã PH
                string maPH = row.Cells["MaPH"].Value?.ToString();
                cboPH_MaPH.Text = maPH;

                // Gán ngày ký
                if (DateTime.TryParse(row.Cells["NgayKy"].Value?.ToString(), out DateTime ngayKy))
                {
                    dtpPH_NgayKy.Value = ngayKy;
                }

                // Kiểm tra NgayHuy có dữ liệu không
                var cellNgayHuy = row.Cells["NgayHuy"].Value;
                if (cellNgayHuy == null || cellNgayHuy == DBNull.Value || string.IsNullOrWhiteSpace(cellNgayHuy.ToString()))
                {
                    rdoPH_ChuaHuy.Checked = true; // sẽ tự disable các control khác trong sự kiện CheckedChanged
                }
                else
                {
                    rdoPH_Huy.Checked = true;
                    dtpPH_NgayHuy.Value = Convert.ToDateTime(cellNgayHuy);
                }

                // Gán lý do (nếu có)
                txtPH_LyDo.Text = row.Cells["LyDo"].Value?.ToString();
            }
        }

        private void rdoPH_ChuaHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPH_ChuaHuy.Checked)
            {
                dtpPH_NgayHuy.Enabled = false;
                txtPH_LyDo.Enabled = false;
                dtpPH_NgayHuy.Value = DateTime.Today;
                txtPH_LyDo.Text = "";
            }
        }

        private void rdoPH_Huy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPH_Huy.Checked)
            {
                dtpPH_NgayHuy.Enabled = true;
                txtPH_LyDo.Enabled = true;
            }
        }

        private void btnPH_CapNhat_Click(object sender, EventArgs e)
        {
            if (dgvPhuHuynh.CurrentRow == null) return;

            string maPH = cboPH_MaPH.Text;
            if (string.IsNullOrWhiteSpace(maPH)) return;

            var hopDong = new HopDongPH
            {
                MaPH = maPH,
                NgayKy = dtpPH_NgayKy.Value.Date,
                NgayHuy = rdoPH_Huy.Checked ? (DateTime?)dtpPH_NgayHuy.Value : null,
                LyDo = rdoPH_Huy.Checked ? txtPH_LyDo.Text.Trim() : null
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = hopDongPHBL.CapNhatHopDongPH(hopDong);
            if (kq)
            {
                MessageBox.Show("Cập nhật hợp đồng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHopDongPH();

                dgvPhuHuynh.DataSource = new List<object> {new { hopDong.MaPH, hopDong.NgayKy, hopDong.NgayHuy, hopDong.LyDo }};
                dgvPhuHuynh.Rows[0].Selected = true;
                dgvPhuHuynh.CurrentCell = dgvPhuHuynh.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGS_TimKiem_Click(object sender, EventArgs e)
        {
            var ketQua = hopDongGSBL.TimKiemHopDongGS(txtGS_TuKhoa.Text.Trim());
            if (ketQua != null)
            {
                dgvGiaSu.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvGiaSu.Columns["GiaSu"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGS_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataHopDongGS();
        }

        private void dgvGiaSu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGiaSu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvGiaSu.SelectedRows[0];

                // Gán mã
                string maGS = row.Cells["MaGS"].Value?.ToString();
                cboGS_MaGS.Text = maGS;

                // Gán ngày ký
                if (DateTime.TryParse(row.Cells["NgayKy"].Value?.ToString(), out DateTime ngayKy))
                {
                    dtpGS_NgayKy.Value = ngayKy;
                }

                // Kiểm tra NgayHuy có dữ liệu không
                var cellNgayHuy = row.Cells["NgayHuy"].Value;
                if (cellNgayHuy == null || cellNgayHuy == DBNull.Value || string.IsNullOrWhiteSpace(cellNgayHuy.ToString()))
                {
                    rdoGS_ChuaHuy.Checked = true; // sẽ tự disable các control khác trong sự kiện CheckedChanged
                }
                else
                {
                    rdoGS_Huy.Checked = true;
                    dtpGS_NgayHuy.Value = Convert.ToDateTime(cellNgayHuy);
                }

                // Gán lý do (nếu có)
                txtGS_LyDo.Text = row.Cells["LyDo"].Value?.ToString();
            }
        }

        private void rdoGS_ChuaHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGS_ChuaHuy.Checked)
            {
                dtpGS_NgayHuy.Enabled = false;
                txtGS_LyDo.Enabled = false;
                dtpGS_NgayHuy.Value = DateTime.Today;
                txtGS_LyDo.Text = "";
            }
        }

        private void rdoGS_Huy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGS_Huy.Checked)
            {
                dtpGS_NgayHuy.Enabled = true;
                txtGS_LyDo.Enabled = true;
            }
        }

        private void btnGS_Update_Click(object sender, EventArgs e)
        {
            if (dgvGiaSu.CurrentRow == null) return;

            string maGS = cboGS_MaGS.Text;
            if (string.IsNullOrWhiteSpace(maGS)) return;

            var hopDong = new HopDongGS
            {
                MaGS = maGS,
                NgayKy = dtpGS_NgayKy.Value.Date,
                NgayHuy = rdoGS_Huy.Checked ? (DateTime?)dtpGS_NgayHuy.Value : null,
                LyDo = rdoGS_Huy.Checked ? txtGS_LyDo.Text.Trim() : null
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = hopDongGSBL.CapNhatHopDongGS(hopDong);
            if (kq)
            {
                MessageBox.Show("Cập nhật hợp đồng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHopDongPH();

                dgvGiaSu.DataSource = new List<object> { new { hopDong.MaGS, hopDong.NgayKy, hopDong.NgayHuy, hopDong.LyDo } };
                dgvGiaSu.Rows[0].Selected = true;
                dgvGiaSu.CurrentCell = dgvGiaSu.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDGLH_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboDGLH_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtDGLH_TuKhoa.Text.Trim();
            var ketQua = danhGiaLH_BL.TimKiemDanhGiaLH(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvDanhGiaLH.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvDanhGiaLH.Columns["HocVien"].Visible = false;
                dgvDanhGiaLH.Columns["LopHoc"].Visible = false;
                dgvDanhGiaLH.Columns["PhuHuynh"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDGLH_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataDanhGiaLH();
            ResetFormDGLH();
        }

        private void cboDGLH_MaPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDGLH_MaPH.SelectedIndex >= 0)
            {
                string maPH = cboDGLH_MaPH.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(maPH))
                {
                    var dsMaHV = danhGiaLH_BL.GetDanhSachMaHVTheoMaPH(maPH);
                    cboDGLH_MaHV.Enabled = true;
                    cboDGLH_MaHV.Items.Clear(); // Xóa danh sách cũ
                    cboDGLH_MaHV.Items.AddRange(dsMaHV.ToArray());
                    cboDGLH_MaHV.SelectedIndex = -1;
                }
            }
            else
            {
                cboDGLH_MaHV.Enabled = false;
                cboDGLH_MaLH.Text = "";
            }
        }

        private void cboDGLH_MaHV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDGLH_MaHV.SelectedIndex >= 0)
            {
                string maHV = cboDGLH_MaHV.SelectedItem?.ToString();
                var maLH = danhGiaLH_BL.GetMaLHTheoMaHV(maHV);

                if (maLH != null)
                {
                    cboDGLH_MaLH.Items.Clear();
                    cboDGLH_MaLH.Enabled = true;
                    cboDGLH_MaLH.Items.AddRange(maLH.ToArray());
                    cboDGLH_MaLH.SelectedIndex = -1;
                }
                else
                    cboDGLH_MaLH.Text = "";
            }
            else
            {
                cboDGLH_MaLH.Text = "";
                cboDGLH_MaLH.Enabled = false;
            }
        }


        //private void dgvDanhGiaLH_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvDanhGiaLH.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = dgvDanhGiaLH.CurrentRow;

        //        // Lấy thông tin từ các cột và gán lên form
        //        string diemHV = row.Cells["DiemHV"].Value?.ToString();
        //        string diemDG = row.Cells["DiemDGLH"].Value?.ToString();
        //        txtDGLH_DiemHV.Text = Math.Round(float.Parse(diemHV), 1).ToString();
        //        txtDGLH_DiemDG.Text = Math.Round(float.Parse(diemDG), 1).ToString();

        //        string trangThai = row.Cells["LoaiDGLH"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(trangThai))
        //            cboDGLH_LoaiDG.SelectedItem = trangThai;

        //        string maPH = row.Cells["MaPH"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(maPH))
        //            cboDGLH_MaPH.SelectedItem = maPH;

        //        string maHV = row.Cells["MaHV"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(maHV))
        //            cboDGLH_MaHV.SelectedItem = maHV;

        //        string maLH = row.Cells["MaLH"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(maLH))
        //            cboDGLH_MaLH.SelectedItem = maLH;

        //        cboDGLH_MaPH.Enabled = false;
        //        cboDGLH_MaHV.Enabled = false;
        //    }
        //}
        //private void btnDGLH_Update_Click(object sender, EventArgs e)
        //{
            //string maPH = cboDGLH_MaPH.Text;
            //string maHV = cboDGLH_MaHV.Text;
            //string maLH = lbDGLH_MaLH.Text;
            //if (maLH == "Chưa đăng ký")
            //{
            //    MessageBox.Show("Học viên chưa tham gia lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return; // Dừng lại không tiếp tục
            //}
            //// Tạo đối tượng
            //var dg = new DanhGiaLH
            //{
            //    MaPH = maPH,
            //    MaHV = maHV,
            //    MaLH = maLH,
            //    DiemHV = Math.Round(float.Parse(txtDGLH_DiemHV.Text.Trim()), 1),
            //    DiemDGLH = Math.Round(float.Parse(txtDGLH_DiemDG.Text.Trim()), 1),
            //    LoaiDGLH = cboDGLH_LoaiDG.SelectedItem.ToString()
            //};
            //bool kq = danhGiaLH_BL.CapNhatDanhGiaLH(dg);
            //if (kq)
            //{
            //    MessageBox.Show("Thêm đánh giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LoadDataDanhGiaLH();
            //    dgvDanhGiaLH.DataSource = new List<object> { new { dg.MaPH, dg.MaHV, dg.MaLH, dg.DiemHV, dg.DiemDGLH, dg.LoaiDGLH } };
            //    dgvDanhGiaLH.Rows[0].Selected = true;
            //    dgvDanhGiaLH.CurrentCell = dgvDanhGiaLH.Rows[0].Cells[0];
            //}
            //else
            //{
            //    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        //}

        private void tabDanhGiaLH_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgvDanhGiaLH.Bounds.Contains(e.Location))
            {
                dgvDanhGiaLH.ClearSelection();
                ResetFormDGLH();
            }
        }

        private void btnDGKH_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboDGKH_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtDGKH_TuKhoa.Text.Trim();
            var ketQua = danhGiaKH_BL.TimKiemDanhGiaKH(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvDanhGiaKH.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvDanhGiaKH.Columns["HocVien"].Visible = false;
                dgvDanhGiaKH.Columns["KhoaHoc"].Visible = false;
                dgvDanhGiaKH.Columns["PhuHuynh"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDGKH_HienThi_Click(object sender, EventArgs e)
        {
            LoadDataDanhGiaKH();
            ResetFormDGKH();
        }

        private void cboDGKH_MaPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDGKH_MaPH.SelectedIndex >= 0)
            {
                string maPH = cboDGKH_MaPH.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(maPH))
                {
                    var dsMaHV = danhGiaKH_BL.GetDanhSachMaHVTheoMaPH(maPH);
                    cboDGKH_MaHV.Enabled = true;
                    cboDGKH_MaHV.Items.Clear(); // Xóa danh sách cũ
                    cboDGKH_MaHV.Items.AddRange(dsMaHV.ToArray());
                    cboDGKH_MaHV.SelectedIndex = -1;
                }
            }
            else
            {
                cboDGKH_MaHV.Enabled = false;
                cboDGKH_MaHV.DataSource = null; // Làm trống danh sách học viên
            }
        }

        private void cboDGKH_MaHV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDGKH_MaHV.SelectedIndex >= 0)
            {
                string maHV = cboDGKH_MaHV.SelectedItem?.ToString();
                var maKH = danhGiaKH_BL.GetMaKHTheoMaHV(maHV);

                if (maKH != null)
                {
                    cboDGKH_MaKH.Items.Clear();
                    cboDGKH_MaKH.Enabled = true;
                    cboDGKH_MaKH.Items.AddRange(maKH.ToArray());
                    cboDGKH_MaKH.SelectedIndex = -1;
                }
                else
                    cboDGKH_MaKH.Text = "";
            }
            else
            {
                cboDGKH_MaKH.Enabled = false;
            }
        }

        //private void btnDGKH_Update_Click(object sender, EventArgs e)
        //{
        //    string maPH = cboDGKH_MaPH.Text;
        //    string maHV = cboDGKH_MaHV.Text;
        //    string maKH = lbDGKH_MaKH.Text;
        //    if (maKH == "Chưa đăng ký")
        //    {
        //        MessageBox.Show("Học viên chưa tham gia khóa học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return; // Dừng lại không tiếp tục
        //    }
        //    // Tạo đối tượng
        //    var dg = new DanhGiaKH
        //    {
        //        MaPH = maPH,
        //        MaHV = maHV,
        //        MaKH = maKH,
        //        DiemKyNangHV = Math.Round(float.Parse(txtDGKH_DiemHV.Text.Trim()), 1),
        //        DiemDGKH = Math.Round(float.Parse(txtDGKH_DiemDG.Text.Trim()), 1),
        //        LoaiDGKH = cboDGKH_LoaiDG.SelectedItem.ToString()
        //    };
        //    bool kq = danhGiaKH_BL.CapNhatDanhGiaKH(dg);
        //    if (kq)
        //    {
        //        MessageBox.Show("Thêm đánh giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        LoadDataDanhGiaKH();
        //        dgvDanhGiaKH.DataSource = new List<object> { new { dg.MaPH, dg.MaHV, dg.MaKH, dg.DiemKyNangHV, dg.DiemDGKH, dg.LoaiDGKH } };
        //        dgvDanhGiaKH.Rows[0].Selected = true;
        //        dgvDanhGiaKH.CurrentCell = dgvDanhGiaKH.Rows[0].Cells[0];
        //    }
        //    else
        //    {
        //        MessageBox.Show("Thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void tabDanhGiaKH_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgvDanhGiaKH.Bounds.Contains(e.Location))
            {
                dgvDanhGiaKH.ClearSelection();
                ResetFormDGKH();
            }
        }

        //private void dgvDanhGiaKH_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvDanhGiaKH.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = dgvDanhGiaKH.CurrentRow;

        //        // Lấy thông tin từ các cột và gán lên form
        //        string diemHV = row.Cells["DiemKyNangHV"].Value?.ToString();
        //        string diemDG = row.Cells["DiemDGKH"].Value?.ToString();
        //        lbDGKH_MaKH.Text = row.Cells["MaKH"].Value?.ToString();
        //        txtDGKH_DiemHV.Text = Math.Round(float.Parse(diemHV), 1).ToString();
        //        txtDGKH_DiemDG.Text = Math.Round(float.Parse(diemDG), 1).ToString();


        //        string trangThai = row.Cells["LoaiDGKH"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(trangThai))
        //            cboDGKH_LoaiDG.SelectedItem = trangThai;

        //        string maPH = row.Cells["MaPH"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(maPH))
        //            cboDGKH_MaPH.SelectedItem = maPH;

        //        string maHV = row.Cells["MaHV"].Value?.ToString();
        //        if (!string.IsNullOrEmpty(maHV))
        //            cboDGKH_MaHV.SelectedItem = maHV;

        //        cboDGKH_MaPH.Enabled = false;
        //        cboDGKH_MaHV.Enabled = false;
        //    }
        //}

        private void tabKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataHopDongPH();
            LoadDataHopDongGS();
            LoadDataDanhGiaKH();
            LoadDataDanhGiaLH();
        }

        private void btnDGKH_Add_Click(object sender, EventArgs e)
        {
            string maPH = cboDGKH_MaPH.Text;
            string maHV = cboDGKH_MaHV.Text;
            string maKH = cboDGKH_MaKH.Text;
            if (maKH == "Chưa đăng ký")
            {
                MessageBox.Show("Học viên chưa tham gia khóa học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại không tiếp tục
            }
            // Tạo đối tượng
            var dg = new DanhGiaKH
            {
                MaPH = maPH,
                MaHV = maHV,
                MaKH = maKH,
                DiemKyNangHV = Math.Round(float.Parse(txtDGKH_DiemHV.Text.Trim()), 1),
                DiemDGKH = Math.Round(float.Parse(txtDGKH_DiemDG.Text.Trim()), 1),
                LoaiDGKH = cboDGKH_LoaiDG.SelectedItem.ToString()
            };
            bool kq = danhGiaKH_BL.ThemDanhGiaKH(dg);
            if (kq)
            {
                MessageBox.Show("Thêm đánh giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhGiaKH();
                dgvDanhGiaKH.DataSource = new List<object> { new { dg.MaPH, dg.MaHV, dg.MaKH, dg.DiemKyNangHV, dg.DiemDGKH, dg.LoaiDGKH } };
                dgvDanhGiaKH.Rows[0].Selected = true;
                dgvDanhGiaKH.CurrentCell = dgvDanhGiaKH.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Thiếu/Đã tồn tại thông tin hoặc học viên chưa tham gia khóa học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDGLH_Add_Click(object sender, EventArgs e)
        {
            string maPH = cboDGLH_MaPH.Text;
            string maHV = cboDGLH_MaHV.Text;
            string maLH = cboDGLH_MaLH.Text;
            // Tạo đối tượng
            var dg = new DanhGiaLH
            {
                MaPH = maPH,
                MaHV = maHV,
                MaLH = maLH,
                DiemHV = Math.Round(float.Parse(txtDGLH_DiemHV.Text.Trim()), 1),
                DiemDGLH = Math.Round(float.Parse(txtDGLH_DiemDG.Text.Trim()), 1),
                LoaiDGLH = cboDGLH_LoaiDG.SelectedItem.ToString()
            };
            bool kq = danhGiaLH_BL.ThemDanhGiaLH(dg);
            if (kq)
            {
                MessageBox.Show("Thêm đánh giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhGiaLH();
                dgvDanhGiaLH.DataSource = new List<object> { new { dg.MaPH, dg.MaHV, dg.MaLH, dg.DiemHV, dg.DiemDGLH, dg.LoaiDGLH } };
                dgvDanhGiaLH.Rows[0].Selected = true;
                dgvDanhGiaLH.CurrentCell = dgvDanhGiaLH.Rows[0].Cells[0];
            }
            else
            {
                MessageBox.Show("Thiếu/Đã tồn tại thông tin hoặc học viên chưa tham gia lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDGLH_Delete_Click(object sender, EventArgs e)
        {
            if (dgvDanhGiaLH.SelectedRows.Count > 0)
            {
                var row = dgvDanhGiaLH.SelectedRows[0];

                string maPH = row.Cells["MaPH"].Value?.ToString();
                string maHV = row.Cells["MaHV"].Value?.ToString();
                string maLH = row.Cells["MaLH"].Value?.ToString();

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa đánh giá này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = danhGiaLH_BL.XoaDanhGiaLH(maPH, maHV, maLH);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataDanhGiaLH();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa. Kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDGKH_Delete_Click(object sender, EventArgs e)
        {
            if (dgvDanhGiaLH.SelectedRows.Count > 0)
            {
                var row = dgvDanhGiaLH.SelectedRows[0];

                string maPH = row.Cells["MaPH"].Value?.ToString();
                string maHV = row.Cells["MaHV"].Value?.ToString();
                string maKH = row.Cells["MaKH"].Value?.ToString();

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa đánh giá này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = danhGiaLH_BL.XoaDanhGiaLH(maPH, maHV, maKH);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataDanhGiaLH();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa. Kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
