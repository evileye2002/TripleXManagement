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
--Bàn ăn
create proc addTable
@Name nvarchar(50),
@Kind nvarchar(50),
@Chair int as
	insert into TableM values(@Name,@Kind,@Chair)	
go
create proc getTable as
	select *
	from TableM
	ORDER BY Name ASC
go
--Đặt bàn
create proc addOrderTable
@TableID int,
@CustomerName varchar(20),
@BookDate varchar(20),
@GetDate varchar(20) as
	declare @Date1 datetime,@Date2 datetime, @Date3 datetime,@CustomerID int
	set @Date1 = (select convert(datetime,@BookDate,105))
	set @Date2 = (select convert(datetime,@GetDate,105))
	set @CustomerID = (select ID from Customer where Name = @CustomerName)
	insert into OrderTable(TableID,CustomerID,BookDate,GetDate) values(@TableID,@CustomerID,@Date1,@Date2)	
go

create proc getEmptyTable as
	declare @Now datetime
	set @Now = (select convert(datetime,GETDATE()))
	select tb.*, stt.Name as StatusName
	from TableM tb,StatusM stt
	where stt.ID = 1 and tb.ID not in (select TableID from OrderTable where GETDATE >= @Now or GiveBackDate <= @Now)
	ORDER BY tb.Name ASC
go
create proc getOrderedTable as
	declare @Now datetime
	set @Now = (select convert(datetime,GETDATE()))
	select tb.*, c.Name as CustomerName,BookDate,(convert(varchar, GetDate,105) + ' ' + convert(varchar, GetDate,8)) as 'Get',GiveBackDate,stt.Name as StatusName
	from TableM tb,OrderTable ot, Customer c,StatusM stt
	where ot.CustomerID = c.ID and tb.ID = TableID and stt.ID = 2 and GetDate >= @Now or GiveBackDate = Null
	ORDER BY tb.Name ASC
go

create proc getOrderTableInToday as
	declare @Now datetime
	set @Now = (select convert(date,GETDATE()))
	select tb.*, c.Name as CustomerName,BookDate,(convert(varchar, GetDate,105) + ' ' + convert(varchar, GetDate,8)) as 'Get',GiveBackDate,stt.Name as StatusName
	from TableM tb,OrderTable ot, Customer c,StatusM stt
	where ot.CustomerID = c.ID and tb.ID = TableID and stt.ID = 2 and CONVERT(date,GetDate) = @Now or GiveBackDate = Null
	ORDER BY tb.Name ASC
go
--Status
create proc getStatus as
	select * from StatusM
go

--Khách hàng
create proc addCustomer
@Name nvarchar(50),
@CCCD nvarchar(50),
@Birthday nvarchar(50),
@Address nvarchar(50),
@Phone nvarchar(50) as
	declare @Date date
	set @Date = (select convert(date,@Birthday,103))
	insert into Customer values(@Name,@CCCD,@Date,@Address,@Phone)	
go
create proc getCustomer as
	select * from Customer
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

insert into StatusM values(N'Bàn Trống')
insert into StatusM values(N'Đã Đặt')
insert into StatusM values(N'Hôm Nay Nhận Bàn')
select * from StatusM

select convert(varchar, getdate(), 5)
delete Bill

exec addTable 'B201',N'Trung',8
exec addTable 'B202',N'Trung',8
exec addTable 'B101',N'Thường',6
exec addTable 'B102',N'Thường',6
exec addOrderTable 1,N'Khanh','20/3/2023 18:03:03','21/3/2023 19:03:03','21/3/2023 21:03:03'
exec addOrderTable 2,N'Khanh',N'26/3/2023 19:03:03','28/3/2023 19:03:03'
exec addOrderTable 1,N'Huong',N'26/3/2023 19:03:03','29/3/2023 19:03:03'

exec addCustomer 'Khanh',N'12345678910',N'20/3/2023',N'Thái Nguyên','0123456789'
exec addCustomer 'Huong',N'12345678910',N'20/3/2023',N'Thái Nguyên','0123456789'

(select convert(datetime,GETDATE(),103))
select CONVERT(datetime,(select convert(varchar, getdate(),105) + ' ' + convert(varchar, getdate(),8)), 20)
(select convert(datetime, getdate,5) + ' ' + convert(varchar, getdate,8))
select * from TableM