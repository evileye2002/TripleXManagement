------------------------------------------------------------------------
--THỦ TỤC
------------------------------------------------------------------------
--ĐẶT BÀN ĂN
------------------------------------------------------------------------
create view EmptyTable --BÀN TRỐNG
as 
	select *
	from TableM
	where StatusID = 1
go
create proc getEmptyTable --Kèm Trạng thái
as  
	select e.*,s.Name as StatusName
	from EmptyTable e, StatusM s
	where s.ID = e.StatusID
	ORDER BY Name ASC
go
create proc getEmptyTablebyKind --Sort theo Loại
@Kind nvarchar(50) as
	select e.*,s.Name as StatusName
	from EmptyTable e,StatusM s
	where s.ID = 1 and Kind = @Kind
	ORDER BY e.Name ASC
go
create proc getEmptyTableSearch --Tìm theo Tên & Loại
@Search nvarchar(50) as
	select e.*,s.Name as StatusName
	from EmptyTable e,StatusM s
	where s.ID = 1 and Kind = @Search or e.Name = @Search
	ORDER BY e.Name ASC
go

create view OrderedTable --BÀN ĐÃ ĐƯỢC ĐẶT
as
	select tb.*, c.Name as CustomerName,BookDate,(convert(varchar, GetDate,105) + ' ' + convert(varchar, GetDate,8)) as 'Get'
	from TableM tb,OrderTable ot, Customer c
	where ot.CustomerID = c.ID and tb.ID = TableID and tb.ID not in (select ID from EmptyTable)
go
create proc getOrderedTable --Kèm Trạng thái
as
	select o.*,s.Name as StatusName
	from OrderedTable o,StatusM s
	where o.StatusID = s.ID
	ORDER BY o.Name ASC
go
create proc getOrderedTablebyKind --Sort theo Loại
@Kind nvarchar(50) as
	select o.*,s.Name as StatusName
	from OrderedTable o,StatusM s
	where s.ID = 2 and Kind like @Kind
	ORDER BY o.Name ASC
go
create proc getOrderedTableSearch --Tìm theo Tên & Loại
@Search nvarchar(50) as
	select o.*,s.Name as StatusName
	from OrderedTable o,StatusM s
	where s.ID = 2	and o.Name like @Search 
					or Kind like @Search 
					or CustomerName like @Search 
					or Get like @Search
	ORDER BY o.Name ASC
go

create view OrderTableInToday --BÀN ĐÃ ĐƯỢC ĐẶT CÓ NGÀY NHẬN LÀ HÔM NAY
as
	select o.*,s.Name as StatusName
	from OrderedTable o,StatusM s
	where	s.ID = 3
			and (select CONVERT(varchar,Get,105)) like (select '%' + CONVERT(varchar,GETDATE(),105) + '%')
go
create proc getOrderTableInToday --Kèm Trạng thái
as
	select *
	from OrderTableInToday
	ORDER BY Name ASC
go
create proc getOrderTableInTodaybyKind --Sort theo Loại
@Kind nvarchar(50) as
	select *
	from OrderTableInToday
	where Kind = @Kind
	ORDER BY Name ASC
go
create proc getOrderTableInTodaySearch --Tìm theo Tên & Loại
@Search nvarchar(50) as
	select *
	from OrderTableInToday
	where Name like @Search or Kind like @Search or CustomerName like @Search or Get like @Search
	ORDER BY Name ASC
go

create proc emptyOrderTable --SỬA TRẠNG THÁI BÀN ĂN
@ID int as
	update TableM
	set StatusID = 1
	where ID = @ID
go
create proc addOrderTable --THÊM ĐẶT BÀN
@TableID int,
@CustomerID int,
@BookDate varchar(20),
@GetDate varchar(20) as
	declare @Date1 datetime,@Date2 datetime
	set @Date1 = (select convert(datetime,@BookDate,105))
	set @Date2 = (select convert(datetime,@GetDate,105))
	
	insert into OrderTable values(@TableID,@CustomerID,@Date1,@Date2)
	update TableM
	set StatusID = 2
	where ID = @TableID
go
------------------------------------------------------------------------
--BÀN ĂN
------------------------------------------------------------------------
create proc addTable --THÊM
@Name nvarchar(50),
@Kind nvarchar(50),
@Chair int as
	insert into TableM values(@Name,@Kind,@Chair,1)	
go
create proc getTable --XEM
as
	select *
	from TableM
	ORDER BY Name ASC
go
create proc getTablebyID --TÌM THEO ID
@ID int as
	select *
	from TableM
	where ID = @ID
	ORDER BY Name ASC
go
------------------------------------------------------------------------
--KHÁCH HÀNG
------------------------------------------------------------------------
create proc addCustomer --Thêm
@Name nvarchar(50),
@CCCD nvarchar(50),
@Birthday nvarchar(50),
@Address nvarchar(50),
@Phone nvarchar(50) as
	declare @Date date
	set @Date = (select convert(date,@Birthday,103))
	insert into Customer values(@Name,@CCCD,@Date,@Address,@Phone)	
go
create proc editCustomer --Sửa
@ID int,
@Name nvarchar(50),
@CCCD nvarchar(50),
@Birthday nvarchar(50),
@Address nvarchar(50),
@Phone nvarchar(50) as
	declare @Date date
	set @Date = (select convert(date,@Birthday,103))
	update Customer
	set Name = @Name, CCCD = @CCCD, Birthday = @Date, Address = @Address, Phone = @Phone
	where ID = @ID
go
create proc getCustomer --Xem
as
	select * from Customer
go
create proc delCustomer --Xóa
@ID int as
	delete Customer
	where ID = @ID
go
------------------------------------------------------------------------
--TÀI KHOẢN
------------------------------------------------------------------------
create proc addAccount -- Thêm
@Username varchar(50),@Password nvarchar(50) as
	insert into Account values(@Username,@Password)
go
create proc editAccount -- Sửa
@Username varchar(50),@Password nvarchar(50) as
	update Account
	set Password = @Password
	where Username = @Username
go
create proc getAccount --Xem
as
	select * from Account
go
create proc delAccount --Xóa
@Username varchar(50) as
	delete Account
	where Username = @Username
go
------------------------------------------------------------------------
--CHỨC VỤ
------------------------------------------------------------------------
create proc addRegency --Thêm
@Name nvarchar(50),@Salary int as
	insert into Regency values(@Name,@Salary)
go
------------------------------------------------------------------------
--NHÂN VIÊN
------------------------------------------------------------------------
create proc addStaff --Thêm
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
create proc getStaff --Xem
as
	select s.Id, s.Name,CCCD, Phone,r.Name as 'Regency',Account 
	from Staff s, Regency r
	where r.ID = s.RegencyID
go
create proc getStaffbyID --Tìm theo ID
@ID int as
	select Image, s.Name,CCCD, Phone,r.Name as 'Regency',Account 
	from Staff s, Regency r
	where r.ID = s.RegencyID and s.Id = @ID
go
create proc editStaffbyID --Sửa
@ID int,
@Name nvarchar(50),
@CCCD varchar(15),
@Phone varchar(10), 
@Regency nvarchar(50),
@Account varchar(50),
@Img image as
	declare @RegencyID int
	set @RegencyID = (select ID from Regency where Name like @Regency)
	update Staff
	set Name = @Name,CCCD = @CCCD, Phone = @Phone,RegencyID = @RegencyID,Account = @Account,Image = @Img
	where Id = @ID
go
create proc delStaffbyID --Xóa
@ID int as
	delete Staff
	where ID = @ID
go
------------------------------------------------------------------------
--HÓA ĐƠN
------------------------------------------------------------------------
create proc addBill -- Thêm
@FoodID int, @isBank int as
declare @BillID varchar(50),@BillDate varchar(50)
set @BillID = replace(convert(varchar, getdate(),5),'-','') + replace(convert(varchar, getdate(),8),':','')
set @BillDate = (select convert(varchar, getdate(),105) + ' ' + convert(varchar, getdate(),8))
	insert into Bill values(@BillID,@BillDate,@FoodID,@isBank)
go
create proc getBill --Xem
as
	select BillID, BillDate, SUM(Price) Total, isBank
	from Bill, MonAn ma
	where FoodID = ma.ID
	group by BillID, BillDate, isBank
	ORDER BY BillID DESC
go
create proc getBillbyId --Tìm theo ID
@BillID varchar(50) as
	select FoodID, ma.Name, ma.Price, COUNT(FoodID) as Quantity, SUM(ma.Price) as Total 
	from Bill, MonAn ma
	where FoodID = ma.ID and BillID like @BillID
	group by FoodID, ma.Name, ma.Price
go
create proc delBillbyId --Xóa
@BillID varchar(50) as
	delete Bill
	where BillID like @BillID
go
create proc delBillDetailbyId --Xóa chi tiết hóa đơn theo ID
@Id int, @billID varchar(50) as
	delete Bill
	where FoodID = @Id and BillID = @billID
go
------------------------------------------------------------------------
--MÓN ĂN
------------------------------------------------------------------------
create proc addmMonAn --Thêm
@Name nvarchar(50),@Price int, @Image image as
	insert into MonAn values(@Name,@Price,@Image)
go
create proc getMonAn --Xem
as
	select Image, Name, Price, ID from MonAn
go
create proc getMonAn2 -- Xem2
as
	select * from MonAn
go
create proc getFoodbyID --Tìm theo ID
@Id int as
	select Image,Name,Price,ID from MonAn where ID = @Id
go
create proc delFoodbyId --Xóa
@Id int as
	delete MonAn
	where ID = @Id
go
create proc editFoodbyId --Sửa
@Id int,
@Name nvarchar(50),
@Price int,
@Img image as
	update MonAn 
	set Name = @Name, Price = @Price,Image = @Img
	where ID = @Id
go
------------------------------------------------------------------------