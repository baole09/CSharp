-- Lab06: chỉ tạo hai CSDL thực hành mới, không xóa CSDL đang có.
USE master;
GO
IF DB_ID(N'QLSinhVien') IS NULL CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO
IF OBJECT_ID('Khoa') IS NULL
BEGIN
CREATE TABLE Khoa(MaKhoa varchar(20) PRIMARY KEY, TenKhoa nvarchar(100) NOT NULL);
CREATE TABLE Lop(MaLop varchar(20) PRIMARY KEY, TenLop nvarchar(100) NOT NULL,
 MaKhoa varchar(20) NOT NULL REFERENCES Khoa(MaKhoa));
CREATE TABLE SinhVien(MaSinhVien varchar(20) PRIMARY KEY, HoTen nvarchar(100) NOT NULL,
 NgaySinh date NOT NULL, MaLop varchar(20) NOT NULL REFERENCES Lop(MaLop));
CREATE TABLE MonHoc(MaMonHoc varchar(20) PRIMARY KEY, TenMonHoc nvarchar(100) NOT NULL);
CREATE TABLE Diem(MaSinhVien varchar(20) REFERENCES SinhVien(MaSinhVien),
 MaMonHoc varchar(20) REFERENCES MonHoc(MaMonHoc), Diem decimal(4,2) NOT NULL CHECK(Diem BETWEEN 0 AND 10),
 PRIMARY KEY(MaSinhVien,MaMonHoc));
INSERT Khoa VALUES('CNTT',N'Công nghệ thông tin'),('KT',N'Kinh tế'),('NN',N'Ngoại ngữ'),('DL',N'Du lịch'),('CK',N'Cơ khí');
INSERT Lop VALUES('DCT124C3',N'Công nghệ thông tin C3','CNTT'),('DCT124C1',N'Công nghệ thông tin C1','CNTT'),('DKT124A',N'Kinh tế A','KT'),('DNN124A',N'Ngoại ngữ A','NN'),('DDL124A',N'Du lịch A','DL');
INSERT SinhVien VALUES('3124411026',N'Lê Nguyễn Anh Bảo','2006-01-15','DCT124C3'),('SV02',N'Nguyễn Văn An','2005-02-20','DCT124C1'),('SV03',N'Trần Thị Bình','2006-03-12','DKT124A'),('SV04',N'Lê Minh Châu','2005-04-18','DNN124A'),('SV05',N'Phạm Gia Duy','2006-05-22','DDL124A');
INSERT MonHoc VALUES('CS',N'Lập trình C sharp'),('CSDL',N'Cơ sở dữ liệu'),('TOAN',N'Toán cao cấp'),('ANH',N'Tiếng Anh'),('CTDL',N'Cấu trúc dữ liệu');
INSERT Diem VALUES('3124411026','CS',9),('SV02','CS',8),('SV03','CSDL',7.5),('SV04','ANH',8.5),('SV05','TOAN',7);
END;
GO
