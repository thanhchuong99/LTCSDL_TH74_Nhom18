USE [QL_DIEM]
GO
/****** Object:  Trigger [dbo].[triggerSBD]    Script Date: 4/23/2020 9:40:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[triggerSBD] on [dbo].[ThiSinh]
FOR INSERT,UPDATE
as
Begin
declare @n char(50) = convert(char,(Select SoBaoDanh from inserted ))
if(len(@n) != 8)
begin
	print N'Số Báo Danh gồm 8 chữ số'
	ROLLBACK TRAN
end
END