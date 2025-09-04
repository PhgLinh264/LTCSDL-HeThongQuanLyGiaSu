using Presentation.UserControlFolder;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private List<Button> buttonList;
        private void MovePanel(Control btn)
        {
            pnlSide.Top = btn.Top;
            pnlSide.Height = btn.Height;
            btn.BackColor = Color.FromArgb(179, 240, 238);
            btn.ForeColor = Color.FromArgb(102, 210, 206);
            pnlSide.Visible = true;
        }
        private void ResetColor()
        {
            foreach (var btn in buttonList)
            {
                btn.BackColor = Color.FromArgb(102, 210, 206);
                btn.ForeColor = Color.White; // hoặc màu chữ mặc định
            }
        }
        private void ShowUserControl(UserControl uc)
        {
            pnlUserControl.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlUserControl.Controls.Add(uc);
            uc.BringToFront();
            pnInfo.BringToFront();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timerDateTime.Start();
            pnlSide.Visible = false;
            buttonList = new List<Button> { btnKhachHang, btnLopHoc, btnKhoaHoc, btnHopDong, btnKhuyenMai };
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ResetColor();
            MovePanel(btnKhachHang);
            ucKhachHang uc = new ucKhachHang();
            ShowUserControl(uc);
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            ResetColor();
            MovePanel(btnLopHoc);
            ucLopHoc uc = new ucLopHoc();
            ShowUserControl(uc);
        }

        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            ResetColor();
            MovePanel(btnKhoaHoc);
            ucKhoaHoc uc = new ucKhoaHoc();
            ShowUserControl(uc);
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            ResetColor();
            MovePanel(btnHopDong);
            ucHopDong uc = new ucHopDong();
            ShowUserControl(uc);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ResetColor();
            MovePanel(btnKhuyenMai);
            ucKhuyenMai uc = new ucKhuyenMai();
            ShowUserControl(uc);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            timerDateTime.Stop();
            Application.Exit();
        }

        private void timerDateTime_Tick_1(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy    HH:mm:ss");
        }
    }
}
