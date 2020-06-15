
	Create Table UserInfo(
		UserId Int Identity(1,1) Not null Primary Key,
		FirstName Varchar(30) Not null,
		LastName Varchar(30) Not null,
		UserName Varchar(30) Not null,
		Email Varchar(50) Not null,
		Password Varchar(20) Not null,
		CreatedDate DateTime Default(GetDate()) Not Null)
GO
CREATE TABLE SoGD
(
	MaSoGD varchar(2) primary key,
	TenSoGD nvarchar(500) not null
)
go
CREATE TABLE ThiSinh
(
	SoBaoDanh varchar(8) primary key,
	Ho nvarchar(500) not null,
	Ten Nvarchar(500) not null,
	NgaySinh date not null,
	QueQuan Nvarchar(500) not null,
	GioiTinh Nvarchar(500) check (GioiTinh = 'Nam' OR GioiTinh = N'Nữ') not null,
	KhoiThi Nvarchar(500) check (KhoiThi ='KHXH' or KhoiThi = 'KHTN') not null,
)
go
create TABLE Diem
(
	MaDiem int identity(1,1) ,
	MaSoGD varchar(2) not null,
	SoBaoDanh varchar(8) not null,
	DiemToan DECIMAL(4,2) ,
	DiemVan DECIMAL(4,2) ,
	DiemNgoaiNgu DECIMAL(4,2) ,
	DiemHoa DECIMAL(4,2) ,
	DiemLy DECIMAL(4,2) ,
	DiemSinh DECIMAL(4,2) ,
	DiemDia DECIMAL(4,2) ,
	DiemSu DECIMAL(4,2) ,
	DiemGDCD DECIMAL(4,2) ,
	primary key(MaDiem,SoBaoDanh),
	foreign key (SoBaoDanh) references ThiSinh(SoBaoDanh) ON DELETE CASCADE ON UPDATE CASCADE,
	foreign key (MaSoGD) references SoGD(MaSoGD) ON DELETE CASCADE ON UPDATE CASCADE,
)
go
CREATE TABLE AnhThiSinh
( 
	ID int identity(1,1) primary key,
	SoBaoDanh varchar(8) not null,
	URL text not null,
	foreign key (SoBaoDanh)  references ThiSinh(SoBaoDanh) ON DELETE CASCADE ON UPDATE CASCADE
)
go