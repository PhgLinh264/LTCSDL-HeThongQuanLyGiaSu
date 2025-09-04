namespace Presentation.UserControlFolder
{
    partial class ucKhuyenMai
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
            this.tabKhachHang = new System.Windows.Forms.TabControl();
            this.tabKhuyenMai = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKM_MaKM = new System.Windows.Forms.TextBox();
            this.txtKM_PhanTram = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKM_Add = new System.Windows.Forms.Button();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.tabLopHocKM = new System.Windows.Forms.TabPage();
            this.btnLH_DeleteKM = new System.Windows.Forms.Button();
            this.lbLH_MaLH = new System.Windows.Forms.Label();
            this.lbLH_PhanTram = new System.Windows.Forms.Label();
            this.lbLH_SoTienKM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLH_MaKM = new System.Windows.Forms.ComboBox();
            this.btnLH_HienThi = new System.Windows.Forms.Button();
            this.cboLH_TimKiem = new System.Windows.Forms.ComboBox();
            this.txtLH_TuKhoa = new System.Windows.Forms.TextBox();
            this.btnLH_TimKiem = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnLH_UpdateKM = new System.Windows.Forms.Button();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.tabKhoaHoc = new System.Windows.Forms.TabPage();
            this.btnKH_DeleteKM = new System.Windows.Forms.Button();
            this.lbKH_MaKH = new System.Windows.Forms.Label();
            this.lbKH_PhanTram = new System.Windows.Forms.Label();
            this.lbKH_SoTienKM = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboKH_MaKM = new System.Windows.Forms.ComboBox();
            this.btnKH_HienThi = new System.Windows.Forms.Button();
            this.cboKH_TimKiem = new System.Windows.Forms.ComboBox();
            this.txtKH_TuKhoa = new System.Windows.Forms.TextBox();
            this.btnKH_TimKiem = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnKH_UpdateKM = new System.Windows.Forms.Button();
            this.dgvKhoaHoc = new System.Windows.Forms.DataGridView();
            this.tabKhachHang.SuspendLayout();
            this.tabKhuyenMai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.tabLopHocKM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.tabKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabKhachHang.Controls.Add(this.tabKhuyenMai);
            this.tabKhachHang.Controls.Add(this.tabLopHocKM);
            this.tabKhachHang.Controls.Add(this.tabKhoaHoc);
            this.tabKhachHang.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabKhachHang.Location = new System.Drawing.Point(8, 10);
            this.tabKhachHang.Multiline = true;
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.SelectedIndex = 0;
            this.tabKhachHang.Size = new System.Drawing.Size(1078, 501);
            this.tabKhachHang.TabIndex = 2;
            this.tabKhachHang.SelectedIndexChanged += new System.EventHandler(this.tabKhachHang_SelectedIndexChanged);
            // 
            // tabKhuyenMai
            // 
            this.tabKhuyenMai.Controls.Add(this.label5);
            this.tabKhuyenMai.Controls.Add(this.txtKM_MaKM);
            this.tabKhuyenMai.Controls.Add(this.txtKM_PhanTram);
            this.tabKhuyenMai.Controls.Add(this.label2);
            this.tabKhuyenMai.Controls.Add(this.btnKM_Add);
            this.tabKhuyenMai.Controls.Add(this.dgvKhuyenMai);
            this.tabKhuyenMai.Location = new System.Drawing.Point(4, 27);
            this.tabKhuyenMai.Name = "tabKhuyenMai";
            this.tabKhuyenMai.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhuyenMai.Size = new System.Drawing.Size(1070, 470);
            this.tabKhuyenMai.TabIndex = 0;
            this.tabKhuyenMai.Text = "Quản lý";
            this.tabKhuyenMai.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mã khuyến mãi";
            // 
            // txtKM_MaKM
            // 
            this.txtKM_MaKM.Location = new System.Drawing.Point(461, 274);
            this.txtKM_MaKM.Name = "txtKM_MaKM";
            this.txtKM_MaKM.Size = new System.Drawing.Size(267, 26);
            this.txtKM_MaKM.TabIndex = 13;
            // 
            // txtKM_PhanTram
            // 
            this.txtKM_PhanTram.Location = new System.Drawing.Point(461, 311);
            this.txtKM_PhanTram.Name = "txtKM_PhanTram";
            this.txtKM_PhanTram.Size = new System.Drawing.Size(267, 26);
            this.txtKM_PhanTram.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phần trăm";
            // 
            // btnKM_Add
            // 
            this.btnKM_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnKM_Add.FlatAppearance.BorderSize = 0;
            this.btnKM_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKM_Add.ForeColor = System.Drawing.Color.White;
            this.btnKM_Add.Location = new System.Drawing.Point(617, 375);
            this.btnKM_Add.Name = "btnKM_Add";
            this.btnKM_Add.Size = new System.Drawing.Size(111, 29);
            this.btnKM_Add.TabIndex = 1;
            this.btnKM_Add.Text = "Thêm";
            this.btnKM_Add.UseVisualStyleBackColor = false;
            this.btnKM_Add.Click += new System.EventHandler(this.btnKM_Add_Click);
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvKhuyenMai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuyenMai.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(47, 23);
            this.dgvKhuyenMai.MultiSelect = false;
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.ReadOnly = true;
            this.dgvKhuyenMai.RowHeadersWidth = 45;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(962, 227);
            this.dgvKhuyenMai.TabIndex = 0;
            // 
            // tabLopHocKM
            // 
            this.tabLopHocKM.Controls.Add(this.btnLH_DeleteKM);
            this.tabLopHocKM.Controls.Add(this.lbLH_MaLH);
            this.tabLopHocKM.Controls.Add(this.lbLH_PhanTram);
            this.tabLopHocKM.Controls.Add(this.lbLH_SoTienKM);
            this.tabLopHocKM.Controls.Add(this.label4);
            this.tabLopHocKM.Controls.Add(this.label8);
            this.tabLopHocKM.Controls.Add(this.label3);
            this.tabLopHocKM.Controls.Add(this.cboLH_MaKM);
            this.tabLopHocKM.Controls.Add(this.btnLH_HienThi);
            this.tabLopHocKM.Controls.Add(this.cboLH_TimKiem);
            this.tabLopHocKM.Controls.Add(this.txtLH_TuKhoa);
            this.tabLopHocKM.Controls.Add(this.btnLH_TimKiem);
            this.tabLopHocKM.Controls.Add(this.label11);
            this.tabLopHocKM.Controls.Add(this.label12);
            this.tabLopHocKM.Controls.Add(this.btnLH_UpdateKM);
            this.tabLopHocKM.Controls.Add(this.dgvLopHoc);
            this.tabLopHocKM.Location = new System.Drawing.Point(4, 27);
            this.tabLopHocKM.Name = "tabLopHocKM";
            this.tabLopHocKM.Padding = new System.Windows.Forms.Padding(3);
            this.tabLopHocKM.Size = new System.Drawing.Size(1070, 470);
            this.tabLopHocKM.TabIndex = 1;
            this.tabLopHocKM.Text = "Lớp học";
            this.tabLopHocKM.UseVisualStyleBackColor = true;
            // 
            // btnLH_DeleteKM
            // 
            this.btnLH_DeleteKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLH_DeleteKM.FlatAppearance.BorderSize = 0;
            this.btnLH_DeleteKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLH_DeleteKM.ForeColor = System.Drawing.Color.White;
            this.btnLH_DeleteKM.Location = new System.Drawing.Point(830, 307);
            this.btnLH_DeleteKM.Name = "btnLH_DeleteKM";
            this.btnLH_DeleteKM.Size = new System.Drawing.Size(143, 26);
            this.btnLH_DeleteKM.TabIndex = 58;
            this.btnLH_DeleteKM.Text = "Hủy khuyến mãi";
            this.btnLH_DeleteKM.UseVisualStyleBackColor = false;
            this.btnLH_DeleteKM.Click += new System.EventHandler(this.btnLH_DeleteKM_Click);
            // 
            // lbLH_MaLH
            // 
            this.lbLH_MaLH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.lbLH_MaLH.Location = new System.Drawing.Point(678, 267);
            this.lbLH_MaLH.Name = "lbLH_MaLH";
            this.lbLH_MaLH.Size = new System.Drawing.Size(99, 20);
            this.lbLH_MaLH.TabIndex = 57;
            this.lbLH_MaLH.Text = "Mã lớp học";
            // 
            // lbLH_PhanTram
            // 
            this.lbLH_PhanTram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.lbLH_PhanTram.Location = new System.Drawing.Point(678, 348);
            this.lbLH_PhanTram.Name = "lbLH_PhanTram";
            this.lbLH_PhanTram.Size = new System.Drawing.Size(99, 18);
            this.lbLH_PhanTram.TabIndex = 56;
            this.lbLH_PhanTram.Text = "0%";
            // 
            // lbLH_SoTienKM
            // 
            this.lbLH_SoTienKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.lbLH_SoTienKM.Location = new System.Drawing.Point(678, 392);
            this.lbLH_SoTienKM.Name = "lbLH_SoTienKM";
            this.lbLH_SoTienKM.Size = new System.Drawing.Size(99, 18);
            this.lbLH_SoTienKM.TabIndex = 55;
            this.lbLH_SoTienKM.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 52;
            this.label4.Text = "Phần trăm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(522, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 18);
            this.label8.TabIndex = 50;
            this.label8.Text = "Số tiền khuyến mãi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 49;
            this.label3.Text = "Mã khuyến mãi";
            // 
            // cboLH_MaKM
            // 
            this.cboLH_MaKM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLH_MaKM.FormattingEnabled = true;
            this.cboLH_MaKM.Location = new System.Drawing.Point(678, 305);
            this.cboLH_MaKM.Name = "cboLH_MaKM";
            this.cboLH_MaKM.Size = new System.Drawing.Size(99, 26);
            this.cboLH_MaKM.TabIndex = 48;
            this.cboLH_MaKM.SelectedIndexChanged += new System.EventHandler(this.cboLH_MaKM_SelectedIndexChanged);
            // 
            // btnLH_HienThi
            // 
            this.btnLH_HienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnLH_HienThi.FlatAppearance.BorderSize = 0;
            this.btnLH_HienThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLH_HienThi.ForeColor = System.Drawing.Color.White;
            this.btnLH_HienThi.Location = new System.Drawing.Point(53, 384);
            this.btnLH_HienThi.Name = "btnLH_HienThi";
            this.btnLH_HienThi.Size = new System.Drawing.Size(111, 30);
            this.btnLH_HienThi.TabIndex = 46;
            this.btnLH_HienThi.Text = "Hiện toàn bộ";
            this.btnLH_HienThi.UseVisualStyleBackColor = false;
            this.btnLH_HienThi.Click += new System.EventHandler(this.btnLH_HienThi_Click);
            // 
            // cboLH_TimKiem
            // 
            this.cboLH_TimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLH_TimKiem.FormattingEnabled = true;
            this.cboLH_TimKiem.Location = new System.Drawing.Point(53, 300);
            this.cboLH_TimKiem.Name = "cboLH_TimKiem";
            this.cboLH_TimKiem.Size = new System.Drawing.Size(111, 26);
            this.cboLH_TimKiem.TabIndex = 45;
            // 
            // txtLH_TuKhoa
            // 
            this.txtLH_TuKhoa.Location = new System.Drawing.Point(182, 300);
            this.txtLH_TuKhoa.Name = "txtLH_TuKhoa";
            this.txtLH_TuKhoa.Size = new System.Drawing.Size(127, 26);
            this.txtLH_TuKhoa.TabIndex = 44;
            // 
            // btnLH_TimKiem
            // 
            this.btnLH_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnLH_TimKiem.FlatAppearance.BorderSize = 0;
            this.btnLH_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLH_TimKiem.ForeColor = System.Drawing.Color.White;
            this.btnLH_TimKiem.Location = new System.Drawing.Point(53, 344);
            this.btnLH_TimKiem.Name = "btnLH_TimKiem";
            this.btnLH_TimKiem.Size = new System.Drawing.Size(111, 26);
            this.btnLH_TimKiem.TabIndex = 37;
            this.btnLH_TimKiem.Text = "Tìm kiếm";
            this.btnLH_TimKiem.UseVisualStyleBackColor = false;
            this.btnLH_TimKiem.Click += new System.EventHandler(this.btnLH_TimKiem_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 18);
            this.label11.TabIndex = 35;
            this.label11.Text = "Tìm kiếm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 18);
            this.label12.TabIndex = 34;
            this.label12.Text = "Mã lớp học";
            // 
            // btnLH_UpdateKM
            // 
            this.btnLH_UpdateKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnLH_UpdateKM.FlatAppearance.BorderSize = 0;
            this.btnLH_UpdateKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLH_UpdateKM.ForeColor = System.Drawing.Color.White;
            this.btnLH_UpdateKM.Location = new System.Drawing.Point(830, 267);
            this.btnLH_UpdateKM.Name = "btnLH_UpdateKM";
            this.btnLH_UpdateKM.Size = new System.Drawing.Size(143, 27);
            this.btnLH_UpdateKM.TabIndex = 21;
            this.btnLH_UpdateKM.Text = "Cập nhật";
            this.btnLH_UpdateKM.UseVisualStyleBackColor = false;
            this.btnLH_UpdateKM.Click += new System.EventHandler(this.btnLH_UpdateKM_Click);
            // 
            // dgvLopHoc
            // 
            this.dgvLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHoc.Location = new System.Drawing.Point(47, 23);
            this.dgvLopHoc.MultiSelect = false;
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.RowHeadersWidth = 45;
            this.dgvLopHoc.Size = new System.Drawing.Size(962, 227);
            this.dgvLopHoc.TabIndex = 20;
            this.dgvLopHoc.SelectionChanged += new System.EventHandler(this.dgvLopHoc_SelectionChanged);
            // 
            // tabKhoaHoc
            // 
            this.tabKhoaHoc.Controls.Add(this.btnKH_DeleteKM);
            this.tabKhoaHoc.Controls.Add(this.lbKH_MaKH);
            this.tabKhoaHoc.Controls.Add(this.lbKH_PhanTram);
            this.tabKhoaHoc.Controls.Add(this.lbKH_SoTienKM);
            this.tabKhoaHoc.Controls.Add(this.label9);
            this.tabKhoaHoc.Controls.Add(this.label10);
            this.tabKhoaHoc.Controls.Add(this.label13);
            this.tabKhoaHoc.Controls.Add(this.cboKH_MaKM);
            this.tabKhoaHoc.Controls.Add(this.btnKH_HienThi);
            this.tabKhoaHoc.Controls.Add(this.cboKH_TimKiem);
            this.tabKhoaHoc.Controls.Add(this.txtKH_TuKhoa);
            this.tabKhoaHoc.Controls.Add(this.btnKH_TimKiem);
            this.tabKhoaHoc.Controls.Add(this.label14);
            this.tabKhoaHoc.Controls.Add(this.label15);
            this.tabKhoaHoc.Controls.Add(this.btnKH_UpdateKM);
            this.tabKhoaHoc.Controls.Add(this.dgvKhoaHoc);
            this.tabKhoaHoc.Location = new System.Drawing.Point(4, 27);
            this.tabKhoaHoc.Name = "tabKhoaHoc";
            this.tabKhoaHoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhoaHoc.Size = new System.Drawing.Size(1070, 470);
            this.tabKhoaHoc.TabIndex = 2;
            this.tabKhoaHoc.Text = "Khóa học";
            this.tabKhoaHoc.UseVisualStyleBackColor = true;
            // 
            // btnKH_DeleteKM
            // 
            this.btnKH_DeleteKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnKH_DeleteKM.FlatAppearance.BorderSize = 0;
            this.btnKH_DeleteKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH_DeleteKM.ForeColor = System.Drawing.Color.White;
            this.btnKH_DeleteKM.Location = new System.Drawing.Point(830, 307);
            this.btnKH_DeleteKM.Name = "btnKH_DeleteKM";
            this.btnKH_DeleteKM.Size = new System.Drawing.Size(143, 26);
            this.btnKH_DeleteKM.TabIndex = 74;
            this.btnKH_DeleteKM.Text = "Hủy khuyến mãi";
            this.btnKH_DeleteKM.UseVisualStyleBackColor = false;
            this.btnKH_DeleteKM.Click += new System.EventHandler(this.btnKH_DeleteKM_Click);
            // 
            // lbKH_MaKH
            // 
            this.lbKH_MaKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.lbKH_MaKH.Location = new System.Drawing.Point(678, 267);
            this.lbKH_MaKH.Name = "lbKH_MaKH";
            this.lbKH_MaKH.Size = new System.Drawing.Size(99, 20);
            this.lbKH_MaKH.TabIndex = 73;
            this.lbKH_MaKH.Text = "Mã khóa học";
            // 
            // lbKH_PhanTram
            // 
            this.lbKH_PhanTram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.lbKH_PhanTram.Location = new System.Drawing.Point(678, 348);
            this.lbKH_PhanTram.Name = "lbKH_PhanTram";
            this.lbKH_PhanTram.Size = new System.Drawing.Size(99, 18);
            this.lbKH_PhanTram.TabIndex = 72;
            this.lbKH_PhanTram.Text = "0%";
            // 
            // lbKH_SoTienKM
            // 
            this.lbKH_SoTienKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.lbKH_SoTienKM.Location = new System.Drawing.Point(678, 392);
            this.lbKH_SoTienKM.Name = "lbKH_SoTienKM";
            this.lbKH_SoTienKM.Size = new System.Drawing.Size(99, 18);
            this.lbKH_SoTienKM.TabIndex = 71;
            this.lbKH_SoTienKM.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(522, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 18);
            this.label9.TabIndex = 70;
            this.label9.Text = "Phần trăm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(522, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 18);
            this.label10.TabIndex = 69;
            this.label10.Text = "Số tiền khuyến mãi";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(520, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 18);
            this.label13.TabIndex = 68;
            this.label13.Text = "Mã khuyến mãi";
            // 
            // cboKH_MaKM
            // 
            this.cboKH_MaKM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKH_MaKM.FormattingEnabled = true;
            this.cboKH_MaKM.Location = new System.Drawing.Point(678, 305);
            this.cboKH_MaKM.Name = "cboKH_MaKM";
            this.cboKH_MaKM.Size = new System.Drawing.Size(99, 26);
            this.cboKH_MaKM.TabIndex = 67;
            this.cboKH_MaKM.SelectedIndexChanged += new System.EventHandler(this.cboKH_MaKM_SelectedIndexChanged);
            // 
            // btnKH_HienThi
            // 
            this.btnKH_HienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnKH_HienThi.FlatAppearance.BorderSize = 0;
            this.btnKH_HienThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH_HienThi.ForeColor = System.Drawing.Color.White;
            this.btnKH_HienThi.Location = new System.Drawing.Point(53, 384);
            this.btnKH_HienThi.Name = "btnKH_HienThi";
            this.btnKH_HienThi.Size = new System.Drawing.Size(111, 30);
            this.btnKH_HienThi.TabIndex = 66;
            this.btnKH_HienThi.Text = "Hiện toàn bộ";
            this.btnKH_HienThi.UseVisualStyleBackColor = false;
            this.btnKH_HienThi.Click += new System.EventHandler(this.btnKH_HienThi_Click);
            // 
            // cboKH_TimKiem
            // 
            this.cboKH_TimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKH_TimKiem.FormattingEnabled = true;
            this.cboKH_TimKiem.Location = new System.Drawing.Point(53, 300);
            this.cboKH_TimKiem.Name = "cboKH_TimKiem";
            this.cboKH_TimKiem.Size = new System.Drawing.Size(111, 26);
            this.cboKH_TimKiem.TabIndex = 65;
            // 
            // txtKH_TuKhoa
            // 
            this.txtKH_TuKhoa.Location = new System.Drawing.Point(181, 300);
            this.txtKH_TuKhoa.Name = "txtKH_TuKhoa";
            this.txtKH_TuKhoa.Size = new System.Drawing.Size(127, 26);
            this.txtKH_TuKhoa.TabIndex = 64;
            // 
            // btnKH_TimKiem
            // 
            this.btnKH_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnKH_TimKiem.FlatAppearance.BorderSize = 0;
            this.btnKH_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH_TimKiem.ForeColor = System.Drawing.Color.White;
            this.btnKH_TimKiem.Location = new System.Drawing.Point(53, 344);
            this.btnKH_TimKiem.Name = "btnKH_TimKiem";
            this.btnKH_TimKiem.Size = new System.Drawing.Size(111, 26);
            this.btnKH_TimKiem.TabIndex = 63;
            this.btnKH_TimKiem.Text = "Tìm kiếm";
            this.btnKH_TimKiem.UseVisualStyleBackColor = false;
            this.btnKH_TimKiem.Click += new System.EventHandler(this.btnKH_TimKiem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 18);
            this.label14.TabIndex = 62;
            this.label14.Text = "Tìm kiếm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(520, 267);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 18);
            this.label15.TabIndex = 61;
            this.label15.Text = "Mã khóa học";
            // 
            // btnKH_UpdateKM
            // 
            this.btnKH_UpdateKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(210)))), ((int)(((byte)(206)))));
            this.btnKH_UpdateKM.FlatAppearance.BorderSize = 0;
            this.btnKH_UpdateKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH_UpdateKM.ForeColor = System.Drawing.Color.White;
            this.btnKH_UpdateKM.Location = new System.Drawing.Point(830, 267);
            this.btnKH_UpdateKM.Name = "btnKH_UpdateKM";
            this.btnKH_UpdateKM.Size = new System.Drawing.Size(143, 27);
            this.btnKH_UpdateKM.TabIndex = 60;
            this.btnKH_UpdateKM.Text = "Cập nhật";
            this.btnKH_UpdateKM.UseVisualStyleBackColor = false;
            this.btnKH_UpdateKM.Click += new System.EventHandler(this.btnKH_UpdateKM_Click);
            // 
            // dgvKhoaHoc
            // 
            this.dgvKhoaHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoaHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKhoaHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoaHoc.Location = new System.Drawing.Point(47, 23);
            this.dgvKhoaHoc.MultiSelect = false;
            this.dgvKhoaHoc.Name = "dgvKhoaHoc";
            this.dgvKhoaHoc.RowHeadersWidth = 45;
            this.dgvKhoaHoc.Size = new System.Drawing.Size(962, 227);
            this.dgvKhoaHoc.TabIndex = 59;
            this.dgvKhoaHoc.SelectionChanged += new System.EventHandler(this.dgvKhoaHoc_SelectionChanged);
            // 
            // ucKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabKhachHang);
            this.Name = "ucKhuyenMai";
            this.Size = new System.Drawing.Size(1095, 521);
            this.Load += new System.EventHandler(this.ucKhuyenMai_Load);
            this.tabKhachHang.ResumeLayout(false);
            this.tabKhuyenMai.ResumeLayout(false);
            this.tabKhuyenMai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.tabLopHocKM.ResumeLayout(false);
            this.tabLopHocKM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.tabKhoaHoc.ResumeLayout(false);
            this.tabKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabKhachHang;
        private System.Windows.Forms.TabPage tabKhuyenMai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKM_MaKM;
        private System.Windows.Forms.TextBox txtKM_PhanTram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.TabPage tabLopHocKM;
        private System.Windows.Forms.Button btnLH_DeleteKM;
        private System.Windows.Forms.Label lbLH_MaLH;
        private System.Windows.Forms.Label lbLH_PhanTram;
        private System.Windows.Forms.Label lbLH_SoTienKM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLH_MaKM;
        private System.Windows.Forms.Button btnLH_HienThi;
        private System.Windows.Forms.ComboBox cboLH_TimKiem;
        private System.Windows.Forms.TextBox txtLH_TuKhoa;
        private System.Windows.Forms.Button btnLH_TimKiem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLH_UpdateKM;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.TabPage tabKhoaHoc;
        private System.Windows.Forms.Button btnKH_DeleteKM;
        private System.Windows.Forms.Label lbKH_MaKH;
        private System.Windows.Forms.Label lbKH_PhanTram;
        private System.Windows.Forms.Label lbKH_SoTienKM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboKH_MaKM;
        private System.Windows.Forms.Button btnKH_HienThi;
        private System.Windows.Forms.ComboBox cboKH_TimKiem;
        private System.Windows.Forms.TextBox txtKH_TuKhoa;
        private System.Windows.Forms.Button btnKH_TimKiem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnKH_UpdateKM;
        private System.Windows.Forms.DataGridView dgvKhoaHoc;
        private System.Windows.Forms.Button btnKM_Add;
    }
}
