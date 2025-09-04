namespace Presentation
{
    partial class FormSendMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.txtMail_TieuDe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtMail_NoiDung = new System.Windows.Forms.RichTextBox();
            this.chboxMail_MaKH = new System.Windows.Forms.CheckedListBox();
            this.btnMail_SendMail = new System.Windows.Forms.Button();
            this.btnMail_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMail_MatKhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tiêu đề";
            // 
            // txtMail_TieuDe
            // 
            this.txtMail_TieuDe.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail_TieuDe.Location = new System.Drawing.Point(105, 21);
            this.txtMail_TieuDe.Name = "txtMail_TieuDe";
            this.txtMail_TieuDe.Size = new System.Drawing.Size(371, 26);
            this.txtMail_TieuDe.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nội dung";
            // 
            // rtxtMail_NoiDung
            // 
            this.rtxtMail_NoiDung.Location = new System.Drawing.Point(105, 105);
            this.rtxtMail_NoiDung.Name = "rtxtMail_NoiDung";
            this.rtxtMail_NoiDung.ReadOnly = true;
            this.rtxtMail_NoiDung.Size = new System.Drawing.Size(371, 142);
            this.rtxtMail_NoiDung.TabIndex = 21;
            this.rtxtMail_NoiDung.Text = "";
            // 
            // chboxMail_MaKH
            // 
            this.chboxMail_MaKH.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxMail_MaKH.FormattingEnabled = true;
            this.chboxMail_MaKH.Location = new System.Drawing.Point(500, 21);
            this.chboxMail_MaKH.Name = "chboxMail_MaKH";
            this.chboxMail_MaKH.Size = new System.Drawing.Size(288, 235);
            this.chboxMail_MaKH.TabIndex = 22;
            this.chboxMail_MaKH.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chboxMail_DsKhoaHoc_ItemCheck);
            // 
            // btnMail_SendMail
            // 
            this.btnMail_SendMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnMail_SendMail.FlatAppearance.BorderSize = 0;
            this.btnMail_SendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail_SendMail.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMail_SendMail.ForeColor = System.Drawing.Color.White;
            this.btnMail_SendMail.Location = new System.Drawing.Point(365, 273);
            this.btnMail_SendMail.Name = "btnMail_SendMail";
            this.btnMail_SendMail.Size = new System.Drawing.Size(111, 29);
            this.btnMail_SendMail.TabIndex = 23;
            this.btnMail_SendMail.Text = "Send";
            this.btnMail_SendMail.UseVisualStyleBackColor = false;
            this.btnMail_SendMail.Click += new System.EventHandler(this.btnMail_SendMail_Click);
            // 
            // btnMail_Cancel
            // 
            this.btnMail_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnMail_Cancel.FlatAppearance.BorderSize = 0;
            this.btnMail_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail_Cancel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMail_Cancel.ForeColor = System.Drawing.Color.White;
            this.btnMail_Cancel.Location = new System.Drawing.Point(105, 273);
            this.btnMail_Cancel.Name = "btnMail_Cancel";
            this.btnMail_Cancel.Size = new System.Drawing.Size(111, 29);
            this.btnMail_Cancel.TabIndex = 51;
            this.btnMail_Cancel.Text = "Cancel";
            this.btnMail_Cancel.UseVisualStyleBackColor = false;
            this.btnMail_Cancel.Click += new System.EventHandler(this.btnMail_Cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Mật khẩu";
            // 
            // txtMail_MatKhau
            // 
            this.txtMail_MatKhau.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail_MatKhau.Location = new System.Drawing.Point(105, 53);
            this.txtMail_MatKhau.Name = "txtMail_MatKhau";
            this.txtMail_MatKhau.Size = new System.Drawing.Size(371, 26);
            this.txtMail_MatKhau.TabIndex = 52;
            // 
            // FormSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 327);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMail_MatKhau);
            this.Controls.Add(this.btnMail_Cancel);
            this.Controls.Add(this.btnMail_SendMail);
            this.Controls.Add(this.chboxMail_MaKH);
            this.Controls.Add(this.rtxtMail_NoiDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMail_TieuDe);
            this.Name = "FormSendMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSendMail";
            this.Load += new System.EventHandler(this.FormSendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMail_TieuDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtMail_NoiDung;
        private System.Windows.Forms.CheckedListBox chboxMail_MaKH;
        private System.Windows.Forms.Button btnMail_SendMail;
        private System.Windows.Forms.Button btnMail_Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMail_MatKhau;
    }
}