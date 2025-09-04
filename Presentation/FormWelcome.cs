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
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            picboxLoading.Visible = true;
            timerLoading.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Stop();
            this.Hide();
            FormMain mainForm = new FormMain();
            mainForm.ShowDialog();
            this.Close();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            picboxLoading.Visible = false;
            timerLoading.Enabled = false;
        }
    }
}
