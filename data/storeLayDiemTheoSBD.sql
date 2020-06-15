-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE themDiemKHTN
	-- Add the parameters for the stored procedure here
	@SoBaoDanh varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	if(@SoBaoDanh not in (select SoBaoDanh from ThiSinh))
	begin
		Print N'Thí Sinh không tồn tại'
	end
	else
	begin
		declare @diemToan float
		declare @diemVan float
		declare @diemNgoaiNgu float
		declare @diemSinh float
		declare @diemSu float
		declare @diemDia float
		declare @diemLy float
		declare @diemHoa float
		declare @diemGDCD float
		select @diemToan = DiemToan from Diem where @SoBaoDanh = SoBaoDanh
		select @diemVan = DiemVan from Diem where @SoBaoDanh = SoBaoDanh
		select @diemNgoaiNgu = DiemNgoaiNgu from Diem where @SoBaoDanh = SoBaoDanh
		select @diemLy = DiemLy from Diem where @SoBaoDanh = SoBaoDanh
		select @diemHoa = DiemHoa from Diem where @SoBaoDanh = SoBaoDanh
		select @diemSinh = DiemSinh from Diem where @SoBaoDanh = SoBaoDanh
		select @diemSu = DiemSu from Diem where @SoBaoDanh = SoBaoDanh
		select @diemDia = DiemDia from Diem where @SoBaoDanh = SoBaoDanh
		select @diemGDCD = DiemGDCD from Diem where @SoBaoDanh = SoBaoDanh
		if(@diemToan = (select DiemToan from Diem where @SoBaoDanh = SoBaoDanh) and @diemVan = (select DiemVan from Diem where @SoBaoDanh = SoBaoDanh) and
		@diemNgoaiNgu = (select DiemNgoaiNgu from Diem where @SoBaoDanh = SoBaoDanh) and @diemHoa = (select DiemHoa from Diem where @SoBaoDanh = SoBaoDanh) and
		@diemLy = (select DiemLy from Diem where @SoBaoDanh = SoBaoDanh) and @diemSinh = (select DiemSinh from Diem where @SoBaoDanh = SoBaoDanh) and
		@diemSu = (select DiemSu from Diem where @SoBaoDanh = SoBaoDanh) and @diemDia = (select DiemDia from Diem where @SoBaoDanh = SoBaoDanh) and
		@diemGDCD = (select DiemGDCD from Diem where @SoBaoDanh = SoBaoDanh))
		begin	
			select @diemToan as DiemToan,@diemVan as DiemVan,@diemNgoaiNgu as DiemNgoaiNgu,@diemHoa as DiemHoa,@diemLy as DiemLy,@diemSinh as DiemSinh,@diemSu as DiemSu,@diemDia as DiemDia,@diemGDCD as DiemGDCD
		end
		else
			print N'Lỗi Hệ Thống'
	END
	END
GO
