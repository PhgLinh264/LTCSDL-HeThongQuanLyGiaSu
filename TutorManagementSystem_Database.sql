create database QuanLyGiaSu
go

use QuanLyGiaSu
go
CREATE TABLE GiaSu (
   MaGS VARCHAR(10) PRIMARY KEY,
   HoTen NVARCHAR(100) NOT NULL,
   SDT VARCHAR(10) NOT NULL,
   DiaChi NVARCHAR(250) NOT NULL,
   GioiTinh NVARCHAR(10) NOT NULL,
   NgaySinh DATE NOT NULL,
   DaiHoc NVARCHAR(100) NOT NULL,
   MonDay NVARCHAR(100) NOT NULL,
   TrangThai NVARCHAR(50) NOT NULL,
   XepHang NVARCHAR(50)
);
CREATE TABLE KhuyenMai (
   MaKM VARCHAR(10) PRIMARY KEY,
   PhanTram INT NOT NULL
);
CREATE TABLE PhuHuynh (
   MaPH VARCHAR(10) PRIMARY KEY,
   HoTen NVARCHAR(100) NOT NULL,
   SDT VARCHAR(15) NOT NULL,
   DiaChi NVARCHAR(250) NOT NULL,
   TrangThai NVARCHAR(50) NOT NULL,
   Email VARCHAR(100) NOT NULL
);
CREATE TABLE HocVien (
   MaHV VARCHAR(10) PRIMARY KEY,
   MaPH VARCHAR(10) NOT NULL,
   HoTen NVARCHAR(100) NOT NULL,
   GioiTinh NVARCHAR(10) NOT NULL,
   NgaySinh DATE NOT NULL,
   HocLuc NVARCHAR(50) NOT NULL,
   FOREIGN KEY (MaPH) REFERENCES PhuHuynh(MaPH)
);

CREATE TABLE LopHoc (
   MaLH VARCHAR(10) PRIMARY KEY,
   MonHoc NVARCHAR(100) NOT NULL,
   SoBuoi INT NOT NULL,
   HocPhi INT NOT NULL,
   TrangThai NVARCHAR(50) NOT NULL,
   MaGS VARCHAR(10) NOT NULL,
   NgayNhanLop DATE NOT NULL,
   MaPH VARCHAR(10) NOT NULL,
   SoLuongHV INT NOT NULL,
   NgayDangKy DATE NOT NULL,
   YeuCau NVARCHAR(250) NOT NULL,
   MaKM VARCHAR(10),
   TienKM INT,
   FOREIGN KEY (MaGS) REFERENCES GiaSu(MaGS),
   FOREIGN KEY (MaPH) REFERENCES PhuHuynh(MaPH),
   FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM)
);

CREATE TABLE DoiTac (
   MaDT VARCHAR(10) PRIMARY KEY,
   TenDT NVARCHAR(100) NOT NULL,
   Email VARCHAR(100) NOT NULL,
   TrangThai NVARCHAR(50) NOT NULL
);
CREATE TABLE KhoaHoc (
   MaKH VARCHAR(10) PRIMARY KEY,
   TenKH NVARCHAR(100) NOT NULL,
   LinhVuc NVARCHAR(100) NOT NULL,
   ThoiGian nVARCHAR(50) NOT NULL,
   HocPhi INT NOT NULL,
   TrangThai NVARCHAR(50) NOT NULL,
   MaDT VARCHAR(10) NOT NULL,
   MaKM VARCHAR(10),
   TienKM INT,
   FOREIGN KEY (MaDT) REFERENCES DoiTac(MaDT),
   FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM)
);
CREATE TABLE DanhGiaLH (
   MaPH VARCHAR(10) NOT NULL,
   MaHV VARCHAR(10) NOT NULL,
   MaLH VARCHAR(10) NOT NULL,
   DiemHV FLOAT NOT NULL,
   DiemDGLH FLOAT NOT NULL,
   LoaiDGLH NVARCHAR(50) NOT NULL,
   PRIMARY KEY (MaPH, MaHV, MaLH),
   FOREIGN KEY (MaPH) REFERENCES PhuHuynh(MaPH),
   FOREIGN KEY (MaHV) REFERENCES HocVien(MaHV),
   FOREIGN KEY (MaLH) REFERENCES LopHoc(MaLH)
);


CREATE TABLE DanhGiaKH (
   MaPH VARCHAR(10) NOT NULL,
   MaHV VARCHAR(10) NOT NULL,
   MaKH VARCHAR(10) NOT NULL,
   DiemKyNangHV FLOAT NOT NULL,
   DiemDGKH FLOAT NOT NULL,
   LoaiDGKH NVARCHAR(50) NOT NULL,
   PRIMARY KEY (MaPH, MaHV, MaKH),
   FOREIGN KEY (MaPH) REFERENCES PhuHuynh(MaPH),
   FOREIGN KEY (MaHV) REFERENCES HocVien(MaHV),
   FOREIGN KEY (MaKH) REFERENCES KhoaHoc(MaKH),
);
CREATE TABLE HopDongPH (
   MaPH VARCHAR(10) PRIMARY KEY,
   NgayKy DATE NOT NULL,
   NgayHuy DATE,
   LyDo NVARCHAR(250),
   FOREIGN KEY (MaPH) REFERENCES PhuHuynh(MaPH)
);
CREATE TABLE HopDongGS (
   MaGS VARCHAR(10) PRIMARY KEY,
   NgayKy DATE NOT NULL,
   NgayHuy DATE,
   LyDo NVARCHAR(250),
   FOREIGN KEY (MaGS) REFERENCES GiaSu(MaGS)
);
CREATE TABLE Hoc (
   MaLH VARCHAR(10) NOT NULL,
   MaHV VARCHAR(10) NOT NULL,
   PRIMARY KEY (MaLH, MaHV),
   FOREIGN KEY (MaLH) REFERENCES LopHoc(MaLH),
   FOREIGN KEY (MaHV) REFERENCES HocVien(MaHV)
);
CREATE TABLE ThamGiaKH (
   MaKH VARCHAR(10) NOT NULL,
   MaHV VARCHAR(10) NOT NULL,
   PRIMARY KEY (MaKH, MaHV),
   FOREIGN KEY (MaKH) REFERENCES KhoaHoc(MaKH),
   FOREIGN KEY (MaHV) REFERENCES HocVien(MaHV)
);


CREATE TABLE DangKyKH (
   MaPH VARCHAR(10) NOT NULL,
   MaKH VARCHAR(10) NOT NULL,
   NgayDangKy DATE NOT NULL,
   SoLuongHV INT NOT NULL,
   PRIMARY KEY (MaPH, MaKH),
   FOREIGN KEY (MaPH) REFERENCES PhuHuynh(MaPH),
   FOREIGN KEY (MaKH) REFERENCES KhoaHoc(MaKH)
);
-- Trigger tự động tạo mã Gia Sư

CREATE TRIGGER trg_auto_id_gs
ON GiaSu
INSTEAD OF INSERT
AS
BEGIN
  DECLARE @max_id INT;
  SELECT @max_id = ISNULL(MAX(CAST(SUBSTRING(MaGS, 3, 3) AS INT)), 0) FROM GiaSu;


  WITH CTE AS (
      SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn FROM inserted
  )
  INSERT INTO GiaSu (MaGS, HoTen, SDT, DiaChi, GioiTinh, NgaySinh, DaiHoc, MonDay, TrangThai, XepHang)
  SELECT
      'GS' + RIGHT('000' + CAST(@max_id + rn AS VARCHAR(3)), 3),
      HoTen, SDT, DiaChi, GioiTinh, NgaySinh, DaiHoc, MonDay, TrangThai, XepHang
  FROM CTE;
END;


-- Trigger tự động tạo mã Phụ Huynh
Create TRIGGER trg_auto_id_ph
ON PhuHuynh
INSTEAD OF INSERT
AS
BEGIN
  DECLARE @max_id INT;
  SELECT @max_id = ISNULL(MAX(CAST(SUBSTRING(MaPH, 3, 3) AS INT)), 0) FROM PhuHuynh;


  WITH CTE AS (
      SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn FROM inserted
  )
  INSERT INTO PhuHuynh (MaPH, HoTen, SDT, DiaChi, TrangThai, Email)
  SELECT
      'PH' + RIGHT('000' + CAST(@max_id + rn AS VARCHAR(3)), 3),
      HoTen, SDT, DiaChi, TrangThai, Email
  FROM CTE;
END;


-- Trigger tự động tạo mã Học Viên
CREATE TRIGGER trg_auto_id_hv
ON HocVien
INSTEAD OF INSERT
AS
BEGIN
   DECLARE @count_hv INT, @new_id VARCHAR(10), @MaPH VARCHAR(6);
   SELECT @MaPH = MaPH FROM inserted;
   SELECT @count_hv = ISNULL(COUNT(*), 0) + 1 FROM HocVien WHERE MaPH = @MaPH;
   SET @new_id = 'HV' + RIGHT(@MaPH, 3) + RIGHT('00' + CAST(@count_hv AS VARCHAR(2)), 2);
   INSERT INTO HocVien (MaHV, MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
   SELECT @new_id, MaPH, HoTen, GioiTinh, NgaySinh, HocLuc FROM inserted;
END;

-- Trigger tự động tạo mã Đối Tác
CREATE TRIGGER trg_auto_id_dt
ON DoiTac
INSTEAD OF INSERT
AS
BEGIN
  DECLARE @max_id INT;
  SELECT @max_id = ISNULL(MAX(CAST(SUBSTRING(MaDT, 3, 3) AS INT)), 0) FROM DoiTac;


  WITH CTE AS (
      SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn FROM inserted
  )
  INSERT INTO DoiTac (MaDT, TenDT, Email, TrangThai)
  SELECT
      'DT' + RIGHT('000' + CAST(@max_id + rn AS VARCHAR(3)), 3),
      TenDT, Email, TrangThai
  FROM CTE;
END;


-- Trigger tự động tạo mã Lớp Học
CREATE TRIGGER trg_auto_id_lh
ON LopHoc
INSTEAD OF INSERT
AS
BEGIN
   DECLARE @max_id INT;
   SELECT @max_id = ISNULL(MAX(CAST(SUBSTRING(MaLH, 3, 3) AS INT)), 0) FROM LopHoc;


   INSERT INTO LopHoc (MaLH, MonHoc, SoBuoi, HocPhi, TrangThai, MaGS, NgayNhanLop, MaPH, SoLuongHV, NgayDangKy, YeuCau, MaKM, TienKM)
   SELECT
       'LH' + RIGHT('000' + CAST(@max_id + ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(3)), 3),
       MonHoc, SoBuoi, HocPhi, TrangThai, MaGS, NgayNhanLop, MaPH, SoLuongHV, NgayDangKy, YeuCau, MaKM, TienKM
   FROM inserted;
END;


-- Trigger tự động tạo mã Khóa Học
CREATE TRIGGER trg_auto_id_kh
ON KhoaHoc
INSTEAD OF INSERT
AS
BEGIN
  DECLARE @max_id INT;
  SELECT @max_id = ISNULL(MAX(CAST(SUBSTRING(MaKH, 3, 3) AS INT)), 0) FROM KhoaHoc;

  WITH CTE AS (
      SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn FROM inserted
  )
  INSERT INTO KhoaHoc (MaKH, TenKH, LinhVuc, ThoiGian, HocPhi, TrangThai, MaDT, MaKM, TienKM)
  SELECT
      'KH' + RIGHT('000' + CAST(@max_id + rn AS VARCHAR(3)), 3),
      TenKH, LinhVuc, ThoiGian, HocPhi, TrangThai, MaDT, MaKM, TienKM
  FROM CTE;
END;

-----------------------------------

use QuanLyGiaSu
go

-- Thêm dữ liệu vào bảng GiaSu
INSERT INTO GiaSu (HoTen, SDT, DiaChi, GioiTinh, NgaySinh, DaiHoc, MonDay, TrangThai, XepHang)
VALUES
(N'Nguyễn Văn A', '0912345678', N'Quận 1, TP.HCM', N'Nam', '2002-05-15', N'ĐH KHTN', N'Toán, Vật lý', N'Hoạt động', N'Hạng A'),
(N'Trần Thị B', '0923456789', N'Quận 2, TP.HCM', N'Nữ', '2003-08-20', N'ĐH Kinh Tế', N'Ngữ văn, Tiếng Anh', N'Hoạt động', N'Hạng B'),
(N'Phạm Văn C', '0934567890', N'Quận 3, TP.HCM', N'Nam', '2001-03-10', N'ĐH BK', N'KHTN', N'Hoạt động', N'Hạng A'),
(N'Lê Thị D', '0945678901', N'Quận 4, TP.HCM', N'Nữ', '2004-07-12', N'ĐH KHXH&NV', N'Tiếng Anh', N'Hoạt động', NULL),
(N'Hoàng Văn E', '0956789012', N'Quận 5, TP.HCM', N'Nam', '2000-12-30', N'ĐH KHTN', N'Hóa học , Sinh học', N'Hoạt động', N'Hạng B'),
(N'Võ Thị F', '0967890123', N'Quận 6, TP.HCM', N'Nữ', '2005-11-22', N'ĐH Kinh Tế', N'Toán', N'Hoạt động', N'Hạng A'),
(N'Đặng Văn G', '0978901234', N'Quận 7, TP.HCM', N'Nam', '2006-04-05', N'ĐH KHTN', N'Toán, KHTN', N'Hoạt động', N'Hạng B'),
(N'Bùi Thị H', '0989012345', N'Quận 8, TP.HCM', N'Nữ', '2002-09-18', N'ĐH BK', N'Toán', N'Huỷ HD', N'Hạng C'),
(N'Ngô Văn I', '0990123456', N'Quận 9, TP.HCM', N'Nam', '2003-02-28', N'ĐH Ngoại Thương', N'Tiếng Anh', N'Hoạt động', N'Hạng A'),
(N'Vũ Thị K', '0901234567', N'Quận 10, TP.HCM', N'Nữ', '2000-06-21', N'ĐH Kinh Tế', N'Ngữ văn', N'Hoạt động', N'Hạng B');


-- Thêm dữ liệu vào bảng HopDongGS
INSERT INTO HopDongGS (MaGS, NgayKy, NgayHuy, LyDo)
VALUES
('GS001', '2023-01-10', NULL, NULL), -- Hạng A, ký lâu nhất
('GS002', '2024-07-05', NULL, NULL), -- Hạng B
('GS003', '2023-05-18', NULL, NULL), -- Hạng A
('GS004', '2024-01-10', NULL, NULL), -- Không có hạng, ký mới
('GS005', '2023-11-02', NULL, NULL), -- Hạng B
('GS006', '2023-03-30', NULL, NULL), -- Hạng A
('GS007', '2024-01-15', NULL, NULL), -- Hạng B
('GS008', '2024-06-12', '2024-10-20', N'Không phù hợp công việc'), -- Hạng C, đã hủy
('GS009', '2023-04-22', NULL, NULL), -- Hạng A
('GS010', '2024-06-25', NULL, NULL); -- Hạng B


-- Thêm dữ liệu vào bảng PhuHuynh
INSERT INTO PhuHuynh (HoTen, SDT, DiaChi, TrangThai, Email)
VALUES
(N'Nguyễn Văn M', '0911223344', N'Bình Thạnh, TP.HCM', N'Hoạt động','PH001@example.com'),
(N'Trần Thị N', '0922334455', N'Tân Bình, TP.HCM', N'Hoạt động','PH002@example.com'),
(N'Phạm Văn O', '0933445566', N'Quận 12, TP.HCM', N'Hoạt động','PH003@example.com'),
(N'Lê Thị P', '0944556677', N'Gò Vấp, TP.HCM', N'Huỷ HD','PH004@example.com'),
(N'Hoàng Văn Q', '0955667788', N'Bình Chánh, TP.HCM', N'Hoạt động','PH005@example.com'),
(N'Võ Thị R', '0966778899', N'Thủ Đức, TP.HCM', N'Hoạt động','PH006@example.com'),
(N'Đặng Văn S', '0977889900', N'Quận 2, TP.HCM', N'Hoạt động','PH007@example.com'),
(N'Bùi Thị T', '0988990011', N'Quận 3, TP.HCM', N'Hoạt động','PH008@example.com'),
(N'Ngô Văn U', '0999001122', N'Quận 4, TP.HCM', N'Huỷ HD','PH009@example.com'),
(N'Vũ Thị V', '0900112233', N'Quận 5, TP.HCM', N'Hoạt động','PH010@example.com');


-- Thêm dữ liệu vào bảng HopDongPhuHuynh
INSERT INTO HopDongPH (MaPH, NgayKy, NgayHuy, LyDo)
VALUES
('PH001', '2024-03-12', NULL, NULL),
('PH002', '2023-10-25', NULL, NULL),
('PH003', '2024-05-14', NULL, NULL),
('PH004', '2024-08-30', '2024-12-05', N'Không còn nhu cầu'),
('PH005', '2023-12-08', NULL, NULL),
('PH006', '2023-11-20', NULL, NULL),
('PH007', '2024-02-10', NULL, NULL),
('PH008', '2024-06-18', NULL, NULL),
('PH009', '2024-10-05', '2025-02-22', N'Chuyển nơi ở'),
('PH010', '2024-07-30', NULL, NULL);


-- Thêm dữ liệu vào bảng HocVien
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH001', N'Nguyễn Thị A', N'Nữ', '2010-05-10', N'Giỏi');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH001', N'Nguyễn Văn B', N'Nam', '2012-08-25', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH001', N'Nguyễn Thị C', N'Nữ', '2014-11-15', N'Trung Bình');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH002', N'Trần Thiện D', N'Nam', '2009-04-18', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH002', N'Trần Thị E', N'Nữ', '2009-04-18', N'Yếu');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH003', N'Phạm Minh F', N'Nam', '2015-03-22', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH004', N'Lê Minh G', N'Nam', '2008-02-14', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH005', N'Hoàng Minh H', N'Nam', '2010-10-19', N'Giỏi');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH005', N'Hoàng Thị I', N'Nữ', '2012-07-01', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH006', N'Võ Thị J', N'Nữ', '2010-09-03', N'Trung Bình');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH007', N'Đặng Văn K', N'Nam', '2009-11-12', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH008', N'Bùi Thị L', N'Nữ', '2011-02-06', N'Giỏi');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH008', N'Bùi Thị M', N'Nữ', '2013-03-12', N'Trung Bình');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH009', N'Nguyễn Thị N', N'Nữ', '2011-07-01', N'Khá');
INSERT INTO HocVien (MaPH, HoTen, GioiTinh, NgaySinh, HocLuc)
VALUES
('PH010', N'Vũ Thị O', N'Nữ', '2010-05-15', N'Giỏi');



-- Thêm dữ liệu vào bảng KhuyenMai
INSERT INTO KhuyenMai (MaKM, PhanTram)
VALUES
('KM010', 10),
('KM020', 20),
('KM030', 30);


-- Thêm dữ liệu vào bảng DoiTac
INSERT INTO DoiTac (TenDT, Email, TrangThai)
VALUES
(N'Trung tâm Kỹ năng Việt', 'contact@kynangviet.vn', N'Hoạt động'),
(N'Học Viện Phát Triển Bản Thân', 'info@hocvienptbt.com', N'Hoạt động'),
(N'Trung Tâm FutureSkills', 'support@futureskills.vn', N'Hoạt động');


-- Thêm dữ liệu vào bảng KhoaHoc
INSERT INTO KhoaHoc (TenKH, LinhVuc, ThoiGian, HocPhi, TrangThai, MaDT, MaKM, TienKM)
VALUES
(N'Kỹ năng quản lý thời gian', N'Kỹ năng mềm', N'2 tuần', 800000, N'Hoạt động', 'DT001', 'KM010', 80000),
(N'Giao tiếp tự tin trước đám đông', N'Kỹ năng mềm', N'3 tuần', 1200000, N'Hoạt động', 'DT002', 'KM020', 240000),
(N'Tư duy sáng tạo và giải quyết vấn đề', N'Phát triển bản thân', N'4 tuần', 1500000, N'Hoạt động', 'DT003', 'KM030', 450000),
(N'Kỹ năng làm việc nhóm hiệu quả', N'Kỹ năng mềm', N'2 tuần', 900000, N'Hoạt động', 'DT001', NULL, 0),
(N'Rèn luyện tư duy phản biện', N'Tư duy logic', N'3 tuần', 1000000, N'Hoạt động', 'DT002', NULL, 0);


-- Thêm dữ liệu bảng LopHoc
INSERT INTO LopHoc (MonHoc, SoBuoi, HocPhi, TrangThai, MaGS, NgayNhanLop, MaPH, SoLuongHV, NgayDangKy, YeuCau, MaKM, TienKM)
VALUES
(N'Vật lý', 8, 2000000, N'Ngưng', 'GS003', '2023-11-20', 'PH004', 1, '2023-11-18', N'Luyện thi cuối kỳ', 'KM030', 600000),
(N'Hóa học', 12, 3000000, N'Hoạt động', 'GS005', '2023-12-05', 'PH010', 1, '2023-12-02', N'Luyện thi học sinh giỏi', NULL, 0),
(N'Toán', 12, 3000000, N'Hoạt động', 'GS006', '2024-02-14', 'PH006', 1, '2024-02-12', N'Nâng cao', NULL, 0),
(N'Toán', 12, 3000000, N'Hoạt động', 'GS001', '2024-03-20', 'PH001', 1, '2024-03-17', N'Gia sư nam', 'KM010', 300000),
(N'Toán', 12, 3000000, N'Hoạt động', 'GS007', '2024-04-18', 'PH008', 1, '2024-04-15', N'Cơ bản', NULL, 0),
(N'Sinh học', 12, 3000000, N'Hoạt động', 'GS005', '2024-04-22', 'PH008', 1, '2024-04-19', N'Ôn tập', 'KM010', 300000),
(N'Toán', 12, 3000000, N'Hoạt động', 'GS007', '2024-05-20', 'PH003', 1, '2024-05-17', N'Nâng cao', NULL, 0),
(N'KHTN', 8, 2000000, N'Hoạt động', 'GS003', '2024-06-30', 'PH005', 1, '2024-06-27', N'Cơ bản', 'KM020', 400000),
(N'Tiếng Anh', 8, 2000000, N'Hoạt động', 'GS002', '2024-07-15', 'PH001', 1, '2024-07-13', N'Gia sư nữ', 'KM010', 200000),
(N'Tiếng Anh', 8, 2000000, N'Hoạt động', 'GS009', '2024-07-25', 'PH007', 1, '2024-07-22', N'Học giao tiếp', 'KM010', 200000),
(N'Toán', 12, 3000000, N'Hoạt động', 'GS007', '2024-08-02', 'PH002', 2, '2024-07-30', N'Gia sư nam', 'KM020', 600000),
(N'Tiếng Anh', 8, 2000000, N'Hoạt động', 'GS004', '2024-08-01', 'PH002', 2, '2024-07-30', N'Gia sư nữ', 'KM010', 200000),
(N'Ngữ văn', 8, 2000000, N'Ngưng', 'GS010', '2024-08-10', 'PH009', 1, '2024-08-07', N'Luyện văn nghị luận', 'KM020', 400000),
(N'Toán', 12, 3000000, N'Ngưng', 'GS008', '2024-09-05', 'PH001', 1, '2024-09-02', N'Gia sư nữ', 'KM010', 300000),
(N'Tiếng Anh', 8, 2000000, N'Hoạt động', 'GS009', '2024-09-12', 'PH008', 1, '2024-09-10', N'Luyện nghe nói', 'KM030', 600000),
(N'Toán', 12, 3000000, N'Hoạt động', 'GS001', '2024-10-15', 'PH005', 1, '2024-10-12', N'Nâng cao', 'KM010', 300000);

-- Thêm dữ liệu vào bảng Hoc
INSERT INTO Hoc (MaLH, MaHV)
VALUES
('LH001', 'HV00401'),
('LH002', 'HV01001'),
('LH003', 'HV00601'),
('LH004', 'HV00101'),
('LH005', 'HV00801'),
('LH006', 'HV00802'),
('LH007', 'HV00301'),
('LH008', 'HV00501'),
('LH009', 'HV00102'),
('LH010', 'HV00701'),
('LH011', 'HV00201'),
('LH011', 'HV00202'),
('LH012', 'HV00201'),
('LH012', 'HV00202'),
('LH013', 'HV00901'),
('LH014', 'HV00103'),
('LH015', 'HV00802'),
('LH016', 'HV00502');
INSERT INTO DanhGiaLH (MaPH, MaHV, MaLH, DiemHV, DiemDGLH, LoaiDGLH)
VALUES 
('PH004', 'HV00401', 'LH001', 7.5, 8.2, N'Tốt'),
('PH010', 'HV01001', 'LH002', 6.8, 7.0, N'Bình thường'),
('PH006', 'HV00601', 'LH003', 8.2, 8.5, N'Tốt'),
('PH001', 'HV00101', 'LH004', 5.9, 5.8, N'Không tốt'),
('PH008', 'HV00801', 'LH005', 6.5, 6.8, N'Bình thường'),
('PH008', 'HV00802', 'LH006', 8.5, 8.7, N'Tốt'),
('PH003', 'HV00301', 'LH007', 6.0, 6.5, N'Bình thường'),
('PH005', 'HV00501', 'LH008', 7.8, 8.0, N'Tốt'),
('PH001', 'HV00102', 'LH009', 7.5, 7.8, N'Bình thường'),
('PH007', 'HV00701', 'LH010', 5.7, 5.9, N'Không tốt'),
('PH002', 'HV00201', 'LH011', 8.0, 8.0, N'Tốt'),
('PH002', 'HV00202', 'LH011', 8.5, 8.0, N'Tốt'),
('PH002', 'HV00201', 'LH012', 6.2, 6.5, N'Bình thường'),
('PH002', 'HV00202', 'LH012', 6.5, 6.5, N'Bình thường'),
('PH009', 'HV00901', 'LH013', 8.3, 8.5, N'Tốt'),
('PH001', 'HV00103', 'LH014', 6.3, 6.7, N'Bình thường'),
('PH008', 'HV00802', 'LH015', 8.1, 8.4, N'Tốt'),
('PH005', 'HV00502', 'LH016', 7.5, 7.8, N'Bình thường');



--🔹 Giả định về các Khoá học (KhoaHoc)
--Giả sử có 5 Khoá học mở vào các thời điểm khác nhau:
--KH001: Mở ngày 2024-02-15


--KH002: Mở ngày 2024-05-10


--KH003: Mở ngày 2024-07-20


--KH004: Mở ngày 2024-09-25


--KH005: Mở ngày 2024-11-15
-- Thêm dữ liệu vào bảng DangKyKH
INSERT INTO DangKyKH (MaPH, MaKH, NgayDangKy, SoLuongHV)
VALUES
('PH008', 'KH001', '2024-02-07', 2), 
('PH001', 'KH001', '2024-02-08', 2), 
('PH004', 'KH001', '2024-02-09', 1), 
('PH010', 'KH002', '2024-05-03', 1), 
('PH004', 'KH002', '2024-05-03', 1), 
('PH002', 'KH002', '2024-05-04', 2), 
('PH006', 'KH002', '2024-05-05', 1), 
('PH001', 'KH003', '2024-07-13', 3), 
('PH007', 'KH003', '2024-07-14', 1), 
('PH009', 'KH003', '2024-07-15', 1),  
('PH007', 'KH004', '2024-09-19', 1),
('PH010', 'KH004', '2024-09-20', 1),
('PH005', 'KH005', '2024-11-09', 2), 
('PH008', 'KH005', '2024-11-10', 2), 
('PH002', 'KH005', '2024-11-08', 2); 
-- Thêm dữ liệu vào bảng ThamGiaKH
INSERT INTO ThamGiaKH (MaKH, MaHV) VALUES 
('KH001', 'HV00801'), 
('KH001', 'HV00802'), 
('KH001', 'HV00101'), 
('KH001', 'HV00102'), 
('KH001', 'HV00401'), 
('KH002', 'HV01001'), 
('KH002', 'HV00401'), 
('KH002', 'HV00201'), 
('KH002', 'HV00202'), 
('KH002', 'HV00601'), 
('KH003', 'HV00101'), 
('KH003', 'HV00102'), 
('KH003', 'HV00103'), 
('KH003', 'HV00701'), 
('KH003', 'HV00901'), 
('KH004', 'HV00701'), 
('KH004', 'HV01001'), 
('KH005', 'HV00501'), 
('KH005', 'HV00502'), 
('KH005', 'HV00801'), 
('KH005', 'HV00802'), 
('KH005', 'HV00201'),
('KH005', 'HV00202'); 
-- Thêm dữ liệu vào bảng DanhGiaKH
INSERT INTO DanhGiaKH (MaPH, MaHV, MaKH, DiemKyNangHV, DiemDGKH, LoaiDGKH)
VALUES 
('PH008', 'HV00801', 'KH001', 7.5, 8.2, N'Tốt'),
('PH008', 'HV00802', 'KH001', 6.8, 8.0, N'Tốt'),
('PH001', 'HV00101', 'KH001', 8.2, 8.5, N'Tốt'),
('PH001', 'HV00102', 'KH001', 8.0, 8.6, N'Tốt'),
('PH004', 'HV00401', 'KH001', 6.5, 6.8, N'Bình thường'),
('PH010', 'HV01001', 'KH002', 8.5, 8.7, N'Tốt'),
('PH004', 'HV00401', 'KH002', 6.0, 6.5, N'Bình thường'),
('PH002', 'HV00201', 'KH002', 7.8, 8.0, N'Tốt'),
('PH002', 'HV00202', 'KH002', 7.5, 8.0, N'Tốt'),
('PH006', 'HV00601', 'KH002', 5.7, 5.9, N'Không tốt'),
('PH001', 'HV00101', 'KH003', 7.0, 7.0, N'Bình thường'),
('PH001', 'HV00102', 'KH003', 6.9, 7.0, N'Bình thường'),
('PH001', 'HV00103', 'KH003', 6.2, 7.0, N'Bình thường'),
('PH007', 'HV00701', 'KH003', 5.5, 5.7, N'Không tốt'),
('PH009', 'HV00901', 'KH003', 8.3, 8.5, N'Tốt'),
('PH007', 'HV00701', 'KH004', 6.3, 6.7, N'Bình thường'),
('PH010', 'HV01001', 'KH004', 8.1, 8.4, N'Tốt'),
('PH005', 'HV00501', 'KH005', 7.5, 8.3, N'Tốt'),
('PH005', 'HV00502', 'KH005', 8.0, 8.2, N'Tốt'),
('PH008', 'HV00801', 'KH005', 6.5, 6.9, N'Bình thường'),
('PH008', 'HV00802', 'KH005', 7.0, 7.0, N'Bình thường'),
('PH002', 'HV00201', 'KH005', 7.2, 8.5, N'Tốt'),
('PH002', 'HV00202', 'KH005', 8.3, 8.5, N'Tốt');

