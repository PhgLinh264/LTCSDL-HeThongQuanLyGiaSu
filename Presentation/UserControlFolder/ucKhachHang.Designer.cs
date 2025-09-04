namespace Presentation.UserControlFolder
{
    partial class ucKhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKhachHang));
            this.tabKhachHang = new System.Windows.Forms.TabControl();
            this.tabPhuHuynh = new System.Windows.Forms.TabPage();
            this.txtPH_Email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPH_GuiMail = new System.Windows.Forms.Button();
            this.pbxLuuY = new System.Windows.Forms.PictureBox();
            this.btnPH_HienThi = new System.Windows.Forms.Button();
            this.btnPH_TimKiem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPH_Hoten = new System.Windows.Forms.TextBox();
            this.txtPH_TimKiem = new System.Windows.Forms.TextBox();
            this.txtPH_DiaChi = new System.Windows.Forms.TextBox();
            this.txtPH_DienThoai = new System.Windows.Forms.TextBox();
            this.btnPH_Update = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPH_Add = new System.Windows.Forms.Button();
            this.dgvPhuHuynh = new System.Windows.Forms.DataGridView();
            this.SendMail = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabHocVien = new System.Windows.Forms.TabPage();
            this.cboHV_MaPH = new System.Windows.Forms.ComboBox();
            this.cboHV_GioiTinh = new System.Windows.Forms.ComboBox();
            this.btnHV_HienThi = new System.Windows.Forms.Button();
            this.btnHV_TimKiem = new System.Windows.Forms.Button();
            this.cboHV_TimKiem = new System.Windows.Forms.ComboBox();
            this.txtHV_TuKhoa = new System.Windows.Forms.TextBox();
            this.txtHV_HoTen = new System.Windows.Forms.TextBox();
            this.cboHV_HocLuc = new System.Windows.Forms.ComboBox();
            this.dtpHV_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnHV_Update = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnHV_Add = new System.Windows.Forms.Button();
            this.dgvHocVien = new System.Windows.Forms.DataGridView();
            this.toolTip_TrangThai = new System.Windows.Forms.ToolTip(this.components);
            this.tabKhachHang.SuspendLayout();
            this.tabPhuHuynh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLuuY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuHuynh)).BeginInit();
            this.tabHocVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabKhachHang.Controls.Add(this.tabPhuHuynh);
            this.tabKhachHang.Controls.Add(this.tabHocVien);
            this.tabKhachHang.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabKhachHang.Location = new System.Drawing.Point(8, 10);
            this.tabKhachHang.Multiline = true;
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.SelectedIndex = 0;
            this.tabKhachHang.Size = new System.Drawing.Size(1078, 501);
            this.tabKhachHang.TabIndex = 1;
            this.tabKhachHang.SelectedIndexChanged += new System.EventHandler(this.tabKhachHang_SelectedIndexChanged);
            // 
            // tabPhuHuynh
            // 
            this.tabPhuHuynh.Controls.Add(this.txtPH_Email);
            this.tabPhuHuynh.Controls.Add(this.label3);
            this.tabPhuHuynh.Controls.Add(this.btnPH_GuiMail);
            this.tabPhuHuynh.Controls.Add(this.pbxLuuY);
            this.tabPhuHuynh.Controls.Add(this.btnPH_HienThi);
            this.tabPhuHuynh.Controls.Add(this.btnPH_TimKiem);
            this.tabPhuHuynh.Controls.Add(this.label7);
            this.tabPhuHuynh.Controls.Add(this.label5);
            this.tabPhuHuynh.Controls.Add(this.txtPH_Hoten);
            this.tabPhuHuynh.Controls.Add(this.txtPH_TimKiem);
            this.tabPhuHuynh.Controls.Add(this.txtPH_DiaChi);
            this.tabPhuHuynh.Controls.Add(this.txtPH_DienThoai);
            this.tabPhuHuynh.Controls.Add(this.btnPH_Update);
            this.tabPhuHuynh.Controls.Add(this.label2);
            this.tabPhuHuynh.Controls.Add(this.label1);
            this.tabPhuHuynh.Controls.Add(this.btnPH_Add);
            this.tabPhuHuynh.Controls.Add(this.dgvPhuHuynh);
            this.tabPhuHuynh.Location = new System.Drawing.Point(4, 27);
            this.tabPhuHuynh.Name = "tabPhuHuynh";
            this.tabPhuHuynh.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhuHuynh.Size = new System.Drawing.Size(1070, 470);
            this.tabPhuHuynh.TabIndex = 0;
            this.tabPhuHuynh.Text = "Phụ Huynh";
            this.tabPhuHuynh.UseVisualStyleBackColor = true;
            this.tabPhuHuynh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabPhuHuynh_MouseClick_1);
            // 
            // txtPH_Email
            // 
            this.txtPH_Email.Location = new System.Drawing.Point(138, 420);
            this.txtPH_Email.Name = "txtPH_Email";
            this.txtPH_Email.Size = new System.Drawing.Size(267, 26);
            this.txtPH_Email.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 51;
            this.label3.Text = "Email";
            // 
            // btnPH_GuiMail
            // 
            this.btnPH_GuiMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnPH_GuiMail.FlatAppearance.BorderSize = 0;
            this.btnPH_GuiMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPH_GuiMail.ForeColor = System.Drawing.Color.White;
            this.btnPH_GuiMail.Location = new System.Drawing.Point(898, 396);
            this.btnPH_GuiMail.Name = "btnPH_GuiMail";
            this.btnPH_GuiMail.Size = new System.Drawing.Size(111, 29);
            this.btnPH_GuiMail.TabIndex = 50;
            this.btnPH_GuiMail.Text = "Gửi mail";
            this.btnPH_GuiMail.UseVisualStyleBackColor = false;
            this.btnPH_GuiMail.Click += new System.EventHandler(this.btnPH_GuiMail_Click);
            // 
            // pbxLuuY
            // 
            this.pbxLuuY.Image = ((System.Drawing.Image)(resources.GetObject("pbxLuuY.Image")));
            this.pbxLuuY.Location = new System.Drawing.Point(718, 54);
            this.pbxLuuY.Name = "pbxLuuY";
            this.pbxLuuY.Size = new System.Drawing.Size(22, 22);
            this.pbxLuuY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLuuY.TabIndex = 49;
            this.pbxLuuY.TabStop = false;
            // 
            // btnPH_HienThi
            // 
            this.btnPH_HienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnPH_HienThi.FlatAppearance.BorderSize = 0;
            this.btnPH_HienThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPH_HienThi.ForeColor = System.Drawing.Color.White;
            this.btnPH_HienThi.Location = new System.Drawing.Point(524, 9);
            this.btnPH_HienThi.Name = "btnPH_HienThi";
            this.btnPH_HienThi.Size = new System.Drawing.Size(121, 30);
            this.btnPH_HienThi.TabIndex = 47;
            this.btnPH_HienThi.Text = "Hiện toàn bộ";
            this.btnPH_HienThi.UseVisualStyleBackColor = false;
            this.btnPH_HienThi.Click += new System.EventHandler(this.btnPH_HienThi_Click);
            // 
            // btnPH_TimKiem
            // 
            this.btnPH_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnPH_TimKiem.FlatAppearance.BorderSize = 0;
            this.btnPH_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPH_TimKiem.ForeColor = System.Drawing.Color.White;
            this.btnPH_TimKiem.Location = new System.Drawing.Point(370, 10);
            this.btnPH_TimKiem.Name = "btnPH_TimKiem";
            this.btnPH_TimKiem.Size = new System.Drawing.Size(121, 29);
            this.btnPH_TimKiem.TabIndex = 17;
            this.btnPH_TimKiem.Text = "Tìm kiếm";
            this.btnPH_TimKiem.UseVisualStyleBackColor = false;
            this.btnPH_TimKiem.Click += new System.EventHandler(this.btnPH_TimKiem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Mã phụ huynh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Họ tên";
            // 
            // txtPH_Hoten
            // 
            this.txtPH_Hoten.Location = new System.Drawing.Point(138, 300);
            this.txtPH_Hoten.Name = "txtPH_Hoten";
            this.txtPH_Hoten.Size = new System.Drawing.Size(267, 26);
            this.txtPH_Hoten.TabIndex = 13;
            // 
            // txtPH_TimKiem
            // 
            this.txtPH_TimKiem.Location = new System.Drawing.Point(160, 12);
            this.txtPH_TimKiem.Name = "txtPH_TimKiem";
            this.txtPH_TimKiem.Size = new System.Drawing.Size(181, 26);
            this.txtPH_TimKiem.TabIndex = 12;
            // 
            // txtPH_DiaChi
            // 
            this.txtPH_DiaChi.Location = new System.Drawing.Point(138, 378);
            this.txtPH_DiaChi.Name = "txtPH_DiaChi";
            this.txtPH_DiaChi.Size = new System.Drawing.Size(267, 26);
            this.txtPH_DiaChi.TabIndex = 7;
            // 
            // txtPH_DienThoai
            // 
            this.txtPH_DienThoai.Location = new System.Drawing.Point(138, 337);
            this.txtPH_DienThoai.Name = "txtPH_DienThoai";
            this.txtPH_DienThoai.Size = new System.Drawing.Size(267, 26);
            this.txtPH_DienThoai.TabIndex = 3;
            // 
            // btnPH_Update
            // 
            this.btnPH_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnPH_Update.FlatAppearance.BorderSize = 0;
            this.btnPH_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPH_Update.ForeColor = System.Drawing.Color.White;
            this.btnPH_Update.Location = new System.Drawing.Point(898, 339);
            this.btnPH_Update.Name = "btnPH_Update";
            this.btnPH_Update.Size = new System.Drawing.Size(111, 29);
            this.btnPH_Update.TabIndex = 10;
            this.btnPH_Update.Text = "Cập nhật";
            this.btnPH_Update.UseVisualStyleBackColor = false;
            this.btnPH_Update.Click += new System.EventHandler(this.btnPH_Update_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Điện thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Địa chỉ";
            // 
            // btnPH_Add
            // 
            this.btnPH_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnPH_Add.FlatAppearance.BorderSize = 0;
            this.btnPH_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPH_Add.ForeColor = System.Drawing.Color.White;
            this.btnPH_Add.Location = new System.Drawing.Point(898, 299);
            this.btnPH_Add.Name = "btnPH_Add";
            this.btnPH_Add.Size = new System.Drawing.Size(111, 29);
            this.btnPH_Add.TabIndex = 1;
            this.btnPH_Add.Text = "Thêm";
            this.btnPH_Add.UseVisualStyleBackColor = false;
            this.btnPH_Add.Click += new System.EventHandler(this.btnPH_Add_Click);
            // 
            // dgvPhuHuynh
            // 
            this.dgvPhuHuynh.AllowUserToAddRows = false;
            this.dgvPhuHuynh.AllowUserToDeleteRows = false;
            this.dgvPhuHuynh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhuHuynh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPhuHuynh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhuHuynh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SendMail});
            this.dgvPhuHuynh.Location = new System.Drawing.Point(47, 50);
            this.dgvPhuHuynh.Name = "dgvPhuHuynh";
            this.dgvPhuHuynh.ReadOnly = true;
            this.dgvPhuHuynh.RowHeadersWidth = 45;
            this.dgvPhuHuynh.Size = new System.Drawing.Size(962, 227);
            this.dgvPhuHuynh.TabIndex = 0;
            this.dgvPhuHuynh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhuHuynh_CellClick);
            this.dgvPhuHuynh.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPhuHuynh_ColumnHeaderMouseClick);
            this.dgvPhuHuynh.SelectionChanged += new System.EventHandler(this.dgvPhuHuynh_SelectionChanged_1);
            // 
            // SendMail
            // 
            this.SendMail.HeaderText = "SendMail";
            this.SendMail.Image = ((System.Drawing.Image)(resources.GetObject("SendMail.Image")));
            this.SendMail.MinimumWidth = 6;
            this.SendMail.Name = "SendMail";
            this.SendMail.ReadOnly = true;
            this.SendMail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabHocVien
            // 
            this.tabHocVien.Controls.Add(this.cboHV_MaPH);
            this.tabHocVien.Controls.Add(this.cboHV_GioiTinh);
            this.tabHocVien.Controls.Add(this.btnHV_HienThi);
            this.tabHocVien.Controls.Add(this.btnHV_TimKiem);
            this.tabHocVien.Controls.Add(this.cboHV_TimKiem);
            this.tabHocVien.Controls.Add(this.txtHV_TuKhoa);
            this.tabHocVien.Controls.Add(this.txtHV_HoTen);
            this.tabHocVien.Controls.Add(this.cboHV_HocLuc);
            this.tabHocVien.Controls.Add(this.dtpHV_NgaySinh);
            this.tabHocVien.Controls.Add(this.label10);
            this.tabHocVien.Controls.Add(this.label13);
            this.tabHocVien.Controls.Add(this.label12);
            this.tabHocVien.Controls.Add(this.btnHV_Update);
            this.tabHocVien.Controls.Add(this.label15);
            this.tabHocVien.Controls.Add(this.label16);
            this.tabHocVien.Controls.Add(this.btnHV_Add);
            this.tabHocVien.Controls.Add(this.dgvHocVien);
            this.tabHocVien.Location = new System.Drawing.Point(4, 27);
            this.tabHocVien.Name = "tabHocVien";
            this.tabHocVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabHocVien.Size = new System.Drawing.Size(1070, 470);
            this.tabHocVien.TabIndex = 1;
            this.tabHocVien.Text = "Học Viên";
            this.tabHocVien.UseVisualStyleBackColor = true;
            this.tabHocVien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabHocVien_MouseClick_1);
            // 
            // cboHV_MaPH
            // 
            this.cboHV_MaPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHV_MaPH.FormattingEnabled = true;
            this.cboHV_MaPH.Location = new System.Drawing.Point(160, 300);
            this.cboHV_MaPH.Name = "cboHV_MaPH";
            this.cboHV_MaPH.Size = new System.Drawing.Size(267, 26);
            this.cboHV_MaPH.TabIndex = 52;
            // 
            // cboHV_GioiTinh
            // 
            this.cboHV_GioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHV_GioiTinh.FormattingEnabled = true;
            this.cboHV_GioiTinh.Location = new System.Drawing.Point(160, 385);
            this.cboHV_GioiTinh.Name = "cboHV_GioiTinh";
            this.cboHV_GioiTinh.Size = new System.Drawing.Size(121, 26);
            this.cboHV_GioiTinh.TabIndex = 51;
            // 
            // btnHV_HienThi
            // 
            this.btnHV_HienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnHV_HienThi.FlatAppearance.BorderSize = 0;
            this.btnHV_HienThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHV_HienThi.ForeColor = System.Drawing.Color.White;
            this.btnHV_HienThi.Location = new System.Drawing.Point(524, 9);
            this.btnHV_HienThi.Name = "btnHV_HienThi";
            this.btnHV_HienThi.Size = new System.Drawing.Size(121, 30);
            this.btnHV_HienThi.TabIndex = 50;
            this.btnHV_HienThi.Text = "Hiện toàn bộ";
            this.btnHV_HienThi.UseVisualStyleBackColor = false;
            this.btnHV_HienThi.Click += new System.EventHandler(this.btnHV_HienThi_Click);
            // 
            // btnHV_TimKiem
            // 
            this.btnHV_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnHV_TimKiem.FlatAppearance.BorderSize = 0;
            this.btnHV_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHV_TimKiem.ForeColor = System.Drawing.Color.White;
            this.btnHV_TimKiem.Location = new System.Drawing.Point(370, 10);
            this.btnHV_TimKiem.Name = "btnHV_TimKiem";
            this.btnHV_TimKiem.Size = new System.Drawing.Size(121, 29);
            this.btnHV_TimKiem.TabIndex = 49;
            this.btnHV_TimKiem.Text = "Tìm kiếm";
            this.btnHV_TimKiem.UseVisualStyleBackColor = false;
            this.btnHV_TimKiem.Click += new System.EventHandler(this.btnHV_TimKiem_Click);
            // 
            // cboHV_TimKiem
            // 
            this.cboHV_TimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHV_TimKiem.FormattingEnabled = true;
            this.cboHV_TimKiem.Location = new System.Drawing.Point(49, 12);
            this.cboHV_TimKiem.Name = "cboHV_TimKiem";
            this.cboHV_TimKiem.Size = new System.Drawing.Size(105, 26);
            this.cboHV_TimKiem.TabIndex = 48;
            // 
            // txtHV_TuKhoa
            // 
            this.txtHV_TuKhoa.Location = new System.Drawing.Point(160, 12);
            this.txtHV_TuKhoa.Name = "txtHV_TuKhoa";
            this.txtHV_TuKhoa.Size = new System.Drawing.Size(181, 26);
            this.txtHV_TuKhoa.TabIndex = 44;
            // 
            // txtHV_HoTen
            // 
            this.txtHV_HoTen.Location = new System.Drawing.Point(160, 341);
            this.txtHV_HoTen.Name = "txtHV_HoTen";
            this.txtHV_HoTen.Size = new System.Drawing.Size(267, 26);
            this.txtHV_HoTen.TabIndex = 23;
            // 
            // cboHV_HocLuc
            // 
            this.cboHV_HocLuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHV_HocLuc.FormattingEnabled = true;
            this.cboHV_HocLuc.Location = new System.Drawing.Point(600, 343);
            this.cboHV_HocLuc.Name = "cboHV_HocLuc";
            this.cboHV_HocLuc.Size = new System.Drawing.Size(121, 26);
            this.cboHV_HocLuc.TabIndex = 43;
            // 
            // dtpHV_NgaySinh
            // 
            this.dtpHV_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHV_NgaySinh.Location = new System.Drawing.Point(600, 299);
            this.dtpHV_NgaySinh.Name = "dtpHV_NgaySinh";
            this.dtpHV_NgaySinh.Size = new System.Drawing.Size(200, 26);
            this.dtpHV_NgaySinh.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(483, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 18);
            this.label10.TabIndex = 41;
            this.label10.Text = "Học lực";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(483, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 18);
            this.label13.TabIndex = 40;
            this.label13.Text = "Ngày sinh";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 18);
            this.label12.TabIndex = 34;
            this.label12.Text = "Mã phụ huynh";
            // 
            // btnHV_Update
            // 
            this.btnHV_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnHV_Update.FlatAppearance.BorderSize = 0;
            this.btnHV_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHV_Update.ForeColor = System.Drawing.Color.White;
            this.btnHV_Update.Location = new System.Drawing.Point(898, 339);
            this.btnHV_Update.Name = "btnHV_Update";
            this.btnHV_Update.Size = new System.Drawing.Size(111, 29);
            this.btnHV_Update.TabIndex = 30;
            this.btnHV_Update.Text = "Cập nhật";
            this.btnHV_Update.UseVisualStyleBackColor = false;
            this.btnHV_Update.Click += new System.EventHandler(this.btnHV_Update_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(43, 343);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 18);
            this.label15.TabIndex = 24;
            this.label15.Text = "Họ tên";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(43, 388);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 18);
            this.label16.TabIndex = 22;
            this.label16.Text = "Giới tính";
            // 
            // btnHV_Add
            // 
            this.btnHV_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnHV_Add.FlatAppearance.BorderSize = 0;
            this.btnHV_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHV_Add.ForeColor = System.Drawing.Color.White;
            this.btnHV_Add.Location = new System.Drawing.Point(898, 299);
            this.btnHV_Add.Name = "btnHV_Add";
            this.btnHV_Add.Size = new System.Drawing.Size(111, 29);
            this.btnHV_Add.TabIndex = 21;
            this.btnHV_Add.Text = "Thêm";
            this.btnHV_Add.UseVisualStyleBackColor = false;
            this.btnHV_Add.Click += new System.EventHandler(this.btnHV_Add_Click);
            // 
            // dgvHocVien
            // 
            this.dgvHocVien.AllowUserToDeleteRows = false;
            this.dgvHocVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHocVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHocVien.Location = new System.Drawing.Point(47, 50);
            this.dgvHocVien.Name = "dgvHocVien";
            this.dgvHocVien.ReadOnly = true;
            this.dgvHocVien.RowHeadersWidth = 45;
            this.dgvHocVien.Size = new System.Drawing.Size(962, 227);
            this.dgvHocVien.TabIndex = 20;
            this.dgvHocVien.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvHocVien_DataError);
            this.dgvHocVien.SelectionChanged += new System.EventHandler(this.dgvHocVien_SelectionChanged);
            // 
            // ucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabKhachHang);
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(1095, 521);
            this.Load += new System.EventHandler(this.ucKhachHang_Load);
            this.tabKhachHang.ResumeLayout(false);
            this.tabPhuHuynh.ResumeLayout(false);
            this.tabPhuHuynh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLuuY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuHuynh)).EndInit();
            this.tabHocVien.ResumeLayout(false);
            this.tabHocVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabKhachHang;
        private System.Windows.Forms.TabPage tabPhuHuynh;
        private System.Windows.Forms.Button btnPH_HienThi;
        private System.Windows.Forms.Button btnPH_TimKiem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPH_Hoten;
        private System.Windows.Forms.TextBox txtPH_TimKiem;
        private System.Windows.Forms.TextBox txtPH_DiaChi;
        private System.Windows.Forms.TextBox txtPH_DienThoai;
        private System.Windows.Forms.Button btnPH_Update;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPH_Add;
        private System.Windows.Forms.DataGridView dgvPhuHuynh;
        private System.Windows.Forms.TabPage tabHocVien;
        private System.Windows.Forms.ComboBox cboHV_MaPH;
        private System.Windows.Forms.ComboBox cboHV_GioiTinh;
        private System.Windows.Forms.Button btnHV_HienThi;
        private System.Windows.Forms.Button btnHV_TimKiem;
        private System.Windows.Forms.ComboBox cboHV_TimKiem;
        private System.Windows.Forms.TextBox txtHV_TuKhoa;
        private System.Windows.Forms.TextBox txtHV_HoTen;
        private System.Windows.Forms.ComboBox cboHV_HocLuc;
        private System.Windows.Forms.DateTimePicker dtpHV_NgaySinh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnHV_Update;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnHV_Add;
        private System.Windows.Forms.DataGridView dgvHocVien;
        private System.Windows.Forms.ToolTip toolTip_TrangThai;
        private System.Windows.Forms.PictureBox pbxLuuY;
        private System.Windows.Forms.Button btnPH_GuiMail;
        private System.Windows.Forms.DataGridViewImageColumn SendMail;
        private System.Windows.Forms.TextBox txtPH_Email;
        private System.Windows.Forms.Label label3;
    }
}
