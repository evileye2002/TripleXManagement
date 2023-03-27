--Món Ăn
create proc addmMonAn
@Name nvarchar(50),@Price int, @Image image as
	insert into MonAn values(@Name,@Price,@Image)
go

create proc getMonAn as
	select Image, Name, Price, ID from MonAn
go

create proc getMonAn2 as
	select * from MonAn
go

create proc getMonAnbyId
@Id int as
	select * from MonAn where ID = @Id
go

create proc delFoodbyId
@Id int as
	delete MonAn
	where ID = @Id
go

create proc editFoodbyId
@Id int,@Name nvarchar(50),@Price int as
	update MonAn 
	set Name = @Name, Price = @Price
	where ID = @Id
go

--Hóa đơn
create proc addBill
@FoodID int, @isBank int as
declare @BillID varchar(50),@BillDate varchar(50)
set @BillID = replace(convert(varchar, getdate(),5),'-','') + replace(convert(varchar, getdate(),8),':','')
set @BillDate = (select convert(varchar, getdate(),105) + ' ' + convert(varchar, getdate(),8))
	insert into Bill values(@BillID,@BillDate,@FoodID,@isBank)
go

create proc getBill as
	select BillID, BillDate, SUM(Price) Total, isBank
	from Bill, MonAn ma
	where FoodID = ma.ID
	group by BillID, BillDate, isBank
	ORDER BY BillID DESC
go

create proc getBillbyId
@BillID varchar(50) as
	select FoodID, ma.Name, ma.Price, COUNT(FoodID) as Quantity, SUM(ma.Price) as Total 
	from Bill, MonAn ma
	where FoodID = ma.ID and BillID like @BillID
	group by FoodID, ma.Name, ma.Price
go

create proc delBillbyId
@BillID varchar(50) as
	delete Bill
	where BillID like @BillID
go

create proc delBillDetailbyId
@Id int, @billID varchar(50) as
	delete Bill
	where FoodID = @Id and BillID = @billID
go

--Nhân viên
create proc addStaff
@Name nvarchar(50),
@CCCD varchar(15),
@Phone varchar(10), 
@Image image,
@Regency nvarchar(50),
@Account varchar(50) as
	declare @RegencyID int
	set @RegencyID = (select ID from Regency where Name like @Regency)
	insert into Staff values(@Name,@CCCD,@Phone,@Image,@RegencyID,@Account)
go

create proc getStaff as
	select s.Id, s.Name,CCCD, Phone,r.Name as 'Regency',Account 
	from Staff s, Regency r
	where r.ID = s.RegencyID
go

create proc getStaffbyID
@ID int as
	select Image, s.Name,CCCD, Phone,r.Name as 'Regency',Account 
	from Staff s, Regency r
	where r.ID = s.RegencyID and s.Id = @ID
go

create proc editStaffbyID
@ID int,
@Name nvarchar(50),
@CCCD varchar(15),
@Phone varchar(10), 
@Regency nvarchar(50),
@Account varchar(50) as
	declare @RegencyID int
	set @RegencyID = (select ID from Regency where Name like @Regency)
	update Staff
	set Name = @Name,CCCD = @CCCD, Phone = @Phone,RegencyID = @RegencyID,Account = @Account
	where Id = @ID
go

create proc delStaffbyID
@ID int as
	delete Staff
	where ID = @ID
go

--Chức vụ
create proc addRegency
@Name nvarchar(50),@Salary int as
	insert into Regency values(@Name,@Salary)
go
--Tài khoản
create proc addAccount
@Username varchar(50),@Password nvarchar(50) as
	insert into Account values(@Username,@Password)
go

create proc getAccount as
	select * from Account
go

--===============================================
exec addBill 4, 0
exec addBill 3, 0
exec getBill
exec getBillbyId '%114'

exec addAccount admin,admin
exec addAccount thungan1,thungan1
exec addRegency N'Bếp trưởng',1500000
exec addRegency N'Bếp phó',10000000
exec addRegency N'Phụ bếp',7000000
exec addRegency N'Pha chế',7000000
exec addRegency N'Phục vụ',5000000
exec addRegency N'Thu ngân',3000000
exec addRegency N'Quản lý',12000000
exec addRegency N'Admin',999

exec addStaff N'Hoàng Dương Khánh','123456789987','0123456789','%16%','admin'
exec addStaff N'Hoàng Thị A','5515426262624','0123456789',14,'thungan1'


select convert(varchar, getdate(), 5)
delete Bill