CREATE TRIGGER ThemSuaDiem ON Diem
FOR  INSERT,UPDATE
AS 
begin
declare @n decimal(4,2)
select @n = inserted.DiemToan from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemVan from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemNgoaiNgu from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemHoa from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemLy from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemSinh from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemDia from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemSu from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
select @n = inserted.DiemGDCD from inserted
if(@n < 0 and @n > 10 and @n%0.2=0)
BEGIN
	print N'Lỗi Nhập Liệu'
	ROLLBACK TRAN
END
END