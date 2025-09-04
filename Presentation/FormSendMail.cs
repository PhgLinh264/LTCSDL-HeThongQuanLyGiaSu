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

namespace Presentation
{
    public partial class FormSendMail : Form
    {
        EmailBL emailBL;
        public FormSendMail()
        {
            InitializeComponent();
            emailBL = new EmailBL();
        }
        
        private List<string> _emails;
        public FormSendMail(List<string> emails)
        {
            InitializeComponent();
            _emails = emails;
            emailBL = new EmailBL();
        }
        private void btnMail_SendMail_Click(object sender, EventArgs e)
        {
            string subject = txtMail_TieuDe.Text;
            string body = rtxtMail_NoiDung.Text;
            string pass = txtMail_MatKhau.Text;
            if (pass != "kpl12345")
            {
                MessageBox.Show("Sai mật khẩu", "Lỗi");
                return;
            }
            else
            {
                bool success = emailBL.GuiEmailNhieuNguoi(_emails, subject, body);

                MessageBox.Show(success ? "Gửi email thành công!" : "Gửi email thất bại.", "Thông báo");
            }
        }

        private void FormSendMail_Load(object sender, EventArgs e)
        {
            LoadDataKhoaHoc();
        }
        private void LoadDataKhoaHoc()
        {
            var danhSachKhoaHoc = emailBL.GetKhoaHoc();

            chboxMail_MaKH.DataSource = danhSachKhoaHoc;
            chboxMail_MaKH.DisplayMember = "TenKH"; // Hiển thị tên khóa học
            chboxMail_MaKH.ValueMember = "MaKH";    // Giá trị thực (mã khóa học)
        }
        private void btnMail_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CapNhatNoiDungKhoaHoc()
        {
            var danhSachTenKhoaHoc = chboxMail_MaKH.CheckedItems
        .Cast<KhoaHoc>()
        .Select(kh => "- " + kh.TenKH); // Thêm định dạng gạch đầu dòng

            if (danhSachTenKhoaHoc.Any())
            {
                rtxtMail_NoiDung.Text = "Xin thông báo đến quý phụ huynh, hiện nay trung tâm đang có các khóa học kỹ năng ngắn hạn như khóa học:\r\n"
                                 + string.Join("\r\n", danhSachTenKhoaHoc)
                                 + "\r\nThông tin chi tiết xin vui lòng liên hệ qua HOTLINE: 09123434567"
                                 + "\r\n\r\n--\r\n"
                                 + "Trung tâm Gia sư KPL\r\n"
                                 + "Địa chỉ: 123 Đường Lê Lợi, TP.HCM\r\n"
                                 + "Website: www.giasukpl.com\r\n"
                                 + "Nơi kết nối tri thức – Chắp cánh tương lai!"; ;
            }
            else
            {
                rtxtMail_NoiDung.Clear();
            }
        }
        private void chboxMail_DsKhoaHoc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Sử dụng BeginInvoke để đảm bảo trạng thái check mới đã được cập nhật
            this.BeginInvoke(new Action(() =>{CapNhatNoiDungKhoaHoc();}));
        }
    }
}
