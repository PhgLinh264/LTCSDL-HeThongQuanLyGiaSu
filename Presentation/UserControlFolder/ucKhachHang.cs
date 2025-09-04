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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Net.Mail;

namespace Presentation.UserControlFolder
{
    public partial class ucKhachHang : UserControl
    {
        PhuHuynhBL phuHuynhBL;
        HocVienBL hocVienBL;
        public ucKhachHang()
        {
            InitializeComponent();
            phuHuynhBL = new PhuHuynhBL();
            hocVienBL = new HocVienBL();
        }
        private void LoadDataPhuHuynh()
        {
            List<PhuHuynh> dsPhuHuynh = phuHuynhBL.GetPhuHuynh();
            dgvPhuHuynh.DataSource = dsPhuHuynh;
            
            //Ẩn cột không cần hiển thị 
            dgvPhuHuynh.Columns["HocViens"].Visible = false;
            dgvPhuHuynh.Columns["LopHocs"].Visible = false;
            dgvPhuHuynh.Columns["DangKyKHs"].Visible = false;
            dgvPhuHuynh.Columns["HopDongPH"].Visible = false;
            dgvPhuHuynh.Columns["DanhGiaLHs"].Visible = false;
            dgvPhuHuynh.Columns["DanhGiaKHs"].Visible = false;

            dgvPhuHuynh.Columns["SendMail"].DisplayIndex = dgvPhuHuynh.Columns["Email"].DisplayIndex + 1;
            dgvPhuHuynh.Columns["SendMail"].Width = 85;
        }
        private void LoadDataHocVien()
        {
            List<HocVien> dshocvien = hocVienBL.GetHocVien();
            dgvHocVien.DataSource = dshocvien;
            //Ẩn cột không cần hiển thị 
            dgvHocVien.Columns["KhoaHocs"].Visible = false;
            dgvHocVien.Columns["PhuHuynh"].Visible = false;
            dgvHocVien.Columns["Hocs"].Visible = false;
            dgvHocVien.Columns["ThamGiaKHs"].Visible = false;
            dgvHocVien.Columns["DanhGiaLHs"].Visible = false;
            dgvHocVien.Columns["DanhGiaKHs"].Visible = false;
            //Thêm danh sách mã PH vào combobox
            cboHV_MaPH.Items.Clear();
            var danhSachMaPH = phuHuynhBL.GetDanhSachMaPH();
            cboHV_MaPH.Items.AddRange(danhSachMaPH.ToArray());
            cboHV_MaPH.SelectedIndex = -1;

            toolTip_TrangThai.SetToolTip(pbxLuuY, "Trạng thái được cập nhật từ mục Hợp Đồng. Không thể chỉnh sửa.");

        }
        private void ResetFormPhuHuynh()
        {
            txtPH_Hoten.Text = "";
            txtPH_DienThoai.Text = "";
            txtPH_DiaChi.Text = "";
            txtPH_Email.Text = "";
            //cboPH_TrangThai.SelectedIndex = -1;
        }
        private void ResetFormHocVien()
        {
            cboHV_MaPH.SelectedIndex = -1;
            txtHV_HoTen.Text = "";
            cboHV_GioiTinh.SelectedIndex = -1;
            dtpHV_NgaySinh.Value = DateTime.Now;
            cboHV_HocLuc.SelectedIndex = -1;
        }
        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataPhuHuynh();
            LoadDataHocVien();
            //cboPH_TrangThai.SelectedIndex = -1;
            cboHV_TimKiem.Items.Add("Mã học viên");
            cboHV_TimKiem.Items.Add("Mã phụ huynh");
            cboHV_TimKiem.SelectedIndex = -1;
            cboHV_HocLuc.Items.Add("Yếu");
            cboHV_HocLuc.Items.Add("Trung Bình");
            cboHV_HocLuc.Items.Add("Khá");
            cboHV_HocLuc.Items.Add("Giỏi");
            cboHV_HocLuc.SelectedIndex = -1;
            cboHV_GioiTinh.Items.Add("Nam");
            cboHV_GioiTinh.Items.Add("Nữ");
            cboHV_GioiTinh.SelectedIndex = -1;

            
        }

        private void btnPH_TimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPH_TimKiem.Text))
            {
                var ketQua = phuHuynhBL.TimKiemTheoMaPH(txtPH_TimKiem.Text.Trim());
                dgvPhuHuynh.DataSource = ketQua.ToList();

                //// Ẩn các cột 
                dgvPhuHuynh.Columns["HocViens"].Visible = false;
                dgvPhuHuynh.Columns["LopHocs"].Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã Phụ Huynh hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPH_HienThi_Click(object sender, EventArgs e)
        {
            dgvPhuHuynh.DataSource = null;
            LoadDataPhuHuynh();
            ResetFormPhuHuynh();
        }

        private void btnHV_TimKiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cboHV_TimKiem.SelectedItem?.ToString() ?? "";
            string tuKhoa = txtHV_TuKhoa.Text.Trim();
            var ketQua = hocVienBL.TimKiemHocVien(tieuChi, tuKhoa);
            if (ketQua != null)
            {
                dgvHocVien.DataSource = ketQua.ToList();
                //// Ẩn các cột 
                dgvHocVien.Columns["KhoaHocs"].Visible = false;
                dgvHocVien.Columns["PhuHuynh"].Visible = false;
                dgvHocVien.Columns["Hocs"].Visible = false;
                dgvHocVien.Columns["ThamGiaKHs"].Visible = false;
                dgvHocVien.Columns["DanhGiaLHs"].Visible = false;
                dgvHocVien.Columns["DanhGiaKHs"].Visible = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvHocVien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false; // Ngăn lỗi lan ra ngoài
        }

        private void btnHV_HienThi_Click(object sender, EventArgs e)
        {
            dgvHocVien.DataSource = null;
            LoadDataHocVien();
            ResetFormHocVien();
        }


        private void dgvHocVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocVien.CurrentRow != null && dgvHocVien.CurrentRow.Index >= 0)
            {
                txtHV_HoTen.Text = dgvHocVien.CurrentRow.Cells["HoTen"].Value?.ToString();

                string maPH = dgvHocVien.CurrentRow.Cells["MaPH"].Value?.ToString();
                if (cboHV_MaPH.Items.Contains(maPH))
                    cboHV_MaPH.SelectedItem = maPH;
                else
                    cboHV_MaPH.SelectedIndex = -1;

                string gioiTinh = dgvHocVien.CurrentRow.Cells["GioiTinh"].Value?.ToString();
                if (cboHV_GioiTinh.Items.Contains(gioiTinh))
                    cboHV_GioiTinh.SelectedItem = gioiTinh;
                else
                    cboHV_GioiTinh.SelectedIndex = -1;

                string hocLuc = dgvHocVien.CurrentRow.Cells["HocLuc"].Value?.ToString();
                if (cboHV_HocLuc.Items.Contains(hocLuc))
                    cboHV_HocLuc.SelectedItem = hocLuc;
                else
                    cboHV_HocLuc.SelectedIndex = -1;

                if (DateTime.TryParse(dgvHocVien.CurrentRow.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                {
                    dtpHV_NgaySinh.Value = ngaySinh.Date;
                }
                else
                {
                    dtpHV_NgaySinh.Value = DateTime.Now;
                }
            }
        }

        private void btnPH_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Tạo đối tượng PhuHuynh
            var ph = new PhuHuynh
            {
                MaPH = "0", // Giữ lại vì SQL đã tự sinh qua trigger
                HoTen = txtPH_Hoten.Text.Trim(),
                SDT = txtPH_DienThoai.Text.Trim(),
                DiaChi = txtPH_DiaChi.Text.Trim(),
                Email = txtPH_Email.Text.Trim()
                //TrangThai = cboPH_TrangThai.SelectedItem.ToString()
            };
            bool kq = phuHuynhBL.ThemPhuHuynh(ph);
            if (kq)
            {
                MessageBox.Show("Thêm phụ huynh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhuHuynh();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHV_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            var hv = new HocVien
            {
                MaHV = "0", // EF cần có giá trị (trigger SQL sẽ tự tạo mã thật)
                MaPH = cboHV_MaPH.SelectedItem.ToString(),
                HoTen = txtHV_HoTen.Text.Trim(),
                GioiTinh = cboHV_GioiTinh.SelectedItem.ToString(),
                NgaySinh = dtpHV_NgaySinh.Value.Date,
                HocLuc = cboHV_HocLuc.SelectedItem.ToString()
            };

            bool kq = hocVienBL.ThemHocVien(hv);
            if (kq)
            {
                MessageBox.Show("Thêm học viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHocVien(); // hoặc cập nhật lại lưới
                dgvHocVien.DataSource = new List<object> { new { hv.MaPH, hv.HoTen, hv.GioiTinh, hv.NgaySinh, hv.HocLuc } };
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPH_Update_Click(object sender, EventArgs e)
        {
            if (dgvPhuHuynh.CurrentRow == null) return;

            string maPH = dgvPhuHuynh.CurrentRow.Cells["MaPH"].Value?.ToString();
            var ph = new PhuHuynh
            {
                MaPH = maPH,
                HoTen = txtPH_Hoten.Text.Trim(),
                SDT = txtPH_DienThoai.Text.Trim(),
                DiaChi = txtPH_DiaChi.Text.Trim(),
                Email = txtPH_Email.Text.Trim()
                //TrangThai = cboPH_TrangThai.SelectedItem.ToString()
            };

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            bool kq = phuHuynhBL.CapNhatPhuHuynh(ph);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhuHuynh(); // hoặc cập nhật lại lưới
                ResetFormPhuHuynh();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHV_Update_Click(object sender, EventArgs e)
        {
            if (dgvHocVien.CurrentRow == null) return;

            string maHV = dgvHocVien.CurrentRow.Cells["MaHV"].Value?.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            var hv = new HocVien
            {
                MaHV = maHV,
                MaPH = cboHV_MaPH.SelectedItem.ToString(),
                HoTen = txtHV_HoTen.Text.Trim(),
                GioiTinh = cboHV_GioiTinh.SelectedItem.ToString(),
                NgaySinh = dtpHV_NgaySinh.Value,
                HocLuc = cboHV_HocLuc.SelectedItem.ToString()
            };

            bool kq = hocVienBL.CapNhatHocVien(hv);
            if (kq)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHocVien(); // hoặc cập nhật lại lưới
                dgvHocVien.DataSource = new List<object> { new { hv.MaPH, hv.MaHV, hv.HoTen, hv.GioiTinh, hv.NgaySinh, hv.HocLuc } };
                ResetFormHocVien();
            }
            else
            {
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Khi ấn vào chỗ trống trên form thì các textbox tự động null để user nhập thông tin mới
        private void tabPhuHuynh_MouseClick_1(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem điểm click có nằm ngoài vùng DataGridView không
            if (!dgvPhuHuynh.Bounds.Contains(e.Location))
            {
                dgvPhuHuynh.ClearSelection();
                ResetFormPhuHuynh();
            }
        }

        private void tabHocVien_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (!dgvHocVien.Bounds.Contains(e.Location))
            {
                dgvHocVien.ClearSelection();
                ResetFormHocVien();
            }
        }


        private void tabKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataHocVien();
            LoadDataPhuHuynh();
        }
        private int firstSelectedRowIndex = -1;

        private void dgvPhuHuynh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var clickedColumn = dgvPhuHuynh.Columns[e.ColumnIndex];
                if (clickedColumn != null && clickedColumn.Name == "SendMail")
                {
                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && firstSelectedRowIndex != -1)
                    {
                        // Người dùng giữ Shift => chọn tất cả dòng giữa 2 vị trí
                        int from = Math.Min(firstSelectedRowIndex, e.RowIndex);
                        int to = Math.Max(firstSelectedRowIndex, e.RowIndex);
                        dgvPhuHuynh.ClearSelection();
                        for (int i = from; i <= to; i++)
                        {
                            dgvPhuHuynh.Rows[i].Selected = true;
                        }
                    }
                    else
                    {
                        // Chọn một dòng mới, không giữ Shift
                        dgvPhuHuynh.ClearSelection();
                        dgvPhuHuynh.Rows[e.RowIndex].Selected = true;
                        firstSelectedRowIndex = e.RowIndex;
                    }

                    dgvPhuHuynh.CurrentCell = dgvPhuHuynh.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
        }

        private void dgvPhuHuynh_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0) // cột đầu tiên
            {
                foreach (DataGridViewRow row in dgvPhuHuynh.Rows)
                {
                    row.Selected = true;
                }
            }
        }

        private void dgvPhuHuynh_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvPhuHuynh.CurrentRow != null && dgvPhuHuynh.CurrentRow.Index >= 0)
            {
                txtPH_Hoten.Text = dgvPhuHuynh.CurrentRow.Cells["HoTen"].Value?.ToString();
                txtPH_DienThoai.Text = dgvPhuHuynh.CurrentRow.Cells["SDT"].Value?.ToString();
                txtPH_DiaChi.Text = dgvPhuHuynh.CurrentRow.Cells["DiaChi"].Value?.ToString();
                txtPH_Email.Text = dgvPhuHuynh.CurrentRow.Cells["Email"].Value?.ToString();

            }
        }

        private void btnPH_GuiMail_Click(object sender, EventArgs e)
        {
            if (dgvPhuHuynh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phụ huynh để gửi mail.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedEmails = dgvPhuHuynh.SelectedRows
                                .Cast<DataGridViewRow>()
                                .Select(r => r.Cells["Email"].Value?.ToString())
                                .Where(email => !string.IsNullOrEmpty(email)).ToList();

            FormSendMail f = new FormSendMail(selectedEmails);
            f.ShowDialog();
        }
    }
}
