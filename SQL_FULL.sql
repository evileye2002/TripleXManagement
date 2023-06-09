------------------------------------------------------------------------
--TẠO BẢNG
------------------------------------------------------------------------
--MÓN ĂN
------------------------------------------------------------------------
create table TFood
(
	ID int IDENTITY(1,1) Primary Key,
	FName nvarchar(50) Not Null,
	FPrice int Not Null,
	FImage image Not Null,
)
go
------------------------------------------------------------------------
--TÀI KHOẢN
------------------------------------------------------------------------
create table TAccount
(
	AUsername varchar(50) Primary Key,
	APassword varchar(50) Not Null,
)
go
------------------------------------------------------------------------
--KHÁCH HÀNG
------------------------------------------------------------------------
create table TCustomer
(
	ID int IDENTITY(1,1) Primary Key,
	CName nvarchar(50) Not Null,
	CCCD varchar(11) Not Null,
	CBirthday date Not Null,
	CAddress nvarchar(50) Null,
	CPhone varchar(10) Not Null,
)
go
------------------------------------------------------------------------
--CHỨC VỤ
------------------------------------------------------------------------
create table TRegency
(
	ID int IDENTITY(1,1) Primary Key,
	RName nvarchar(50) Not Null,
	RSalary int Not Null,
)
go
------------------------------------------------------------------------
--BÀN
------------------------------------------------------------------------
create table TTable
(
	ID int IDENTITY(1,1) Primary Key,
	TName varchar(10) Not Null,
	TKind nvarchar(10) Not Null,
	TChair int Not Null,
	TStatus varchar(20) Not Null,
)
go
------------------------------------------------------------------------
--ĐẶT BÀN
------------------------------------------------------------------------
create table TOrderTable
(
	ID int IDENTITY(1,1) Primary Key,
	TableID int Not Null,
	CustomerID int Not Null,
	OBook datetime Not Null,
	OTake datetime Not Null,
	OIsTakeOrCancel int Not Null,
	constraint fk_TableID foreign key (TableID) references TTable(ID),
	constraint fk_CustomerID foreign key (CustomerID) references TCustomer(ID),
)
go
------------------------------------------------------------------------
--NHÂN VIÊN
------------------------------------------------------------------------
create table TStaff
(
	ID int IDENTITY(1,1) Primary Key,
	SName nvarchar(50) Not Null,
	CCCD varchar(12) Not Null,
	SPhone varchar(10) Not Null,
	SImage image Not Null,
	RegencyID int Not Null,
	UserName varchar(50) Null,
	constraint fk_RegencyID foreign key (RegencyID) references TRegency(ID),
	constraint fk_UserName foreign key (UserName) references TAccount(AUsername),
)
go
------------------------------------------------------------------------
--HÓA ĐƠN
------------------------------------------------------------------------
create table TBill
(
	DetailID int IDENTITY(1,1) Primary Key,
	BillID int Not Null,
	BDate datetime Not Null,
	BIsBank int Not Null,
	FoodID int Not Null,
	StaffID int Not Null,
	CustomerID int Not Null,
	constraint fk_FoodID foreign key (FoodID) references TFood(ID),
	constraint fk_StaffID foreign key (StaffID) references TStaff(ID),
	constraint fk_CustomerID1 foreign key (CustomerID) references TCustomer(ID),
)
go
------------------------------------------------------------------------
--VIEW
------------------------------------------------------------------------
create view VEmptyTable --BÀN TRỐNG
as 
	select *
	from TTable
	where TStatus = N'Bàn Trống'
go
------------------------------------------------------------------------
create view VOrderedTable --BÀN ĐÃ ĐƯỢC ĐẶT
as
	select Tt.*, Tc.CName as CustomerName,ot.OBook,ot.OTake,ot.OIsTakeOrCancel,ot.ID as OrderID
	from TTable Tt,TOrderTable ot, TCustomer Tc
	where ot.CustomerID = Tc.ID 
			and Tt.ID = TableID 
			and Tt.ID not in (select ID from VEmptyTable) 
			and ot.OIsTakeOrCancel = 1
go
------------------------------------------------------------------------
create view VOrderedTableToday --BÀN ĐÃ ĐƯỢC ĐẶT CÓ NGÀY NHẬN LÀ HÔM NAY
as
	select *
	from VOrderedTable
	where	OIsTakeOrCancel = 1
			and (select '%' + CONVERT(varchar,OTake,105) + '%') like (select '%' + CONVERT(varchar,GETDATE(),105) + '%')
go
------------------------------------------------------------------------
create view VStaff --Xem
as
	select Ts.*,Tr.RName as 'Regency' 
	from TStaff Ts, TRegency Tr
	where Tr.ID = Ts.RegencyID
go
------------------------------------------------------------------------
create view VBill --View
as
	select BillID,BDate, SUM(FPrice) as Total, BIsBank,Ts.SName as StaffName,Tc.CName as CustomerName
	from TBill Tb, TFood Tf, TStaff Ts,TCustomer Tc
	where FoodID = Tf.ID 
			and Ts.Id = Tb.StaffID 
			and Tc.ID = Tb.CustomerID
			
	group by BillID, BDate, BIsBank,Ts.SName,Tc.CName
go

------------------------------------------------------------------------
--THỦ TỤC
------------------------------------------------------------------------
create proc PLogin --Đăng nhập
@u varchar(50),
@p varchar(50) as

	select * from TAccount
	where AUsername = @u and APassword = @p
go
------------------------------------------------------------------------
--MÓN ĂN
------------------------------------------------------------------------
create proc PFoodAdd --Thêm
@Name nvarchar(50),
@Price int, 
@Image image as

	insert into TFood values(@Name,@Price,@Image)
go
create proc PFoodShowWithImage --Xem
as
	select FImage, FName, FPrice, ID 
	from TFood
go
create proc PFoodFineByID --Tìm theo ID
@Id int as

	select FImage,FName,FPrice,ID 
	from TFood 
	where ID = @Id
go
create proc PFoodDelByID --Xóa
@Id int as

	delete TFood
	where ID = @Id
go
create proc PFoodEditByID --Sửa
@Id int,
@Name nvarchar(50),
@Price int,
@Img image as

	update TFood 
	set FName = @Name, FPrice = @Price,FImage = @Img
	where ID = @Id
go
------------------------------------------------------------------------
--TÀI KHOẢN
------------------------------------------------------------------------
create proc PAccountAdd -- Thêm
@u varchar(50),
@p nvarchar(50) as

	insert into TAccount values(@u,@p)
go
create proc PAccountEdit -- Sửa
@u varchar(50),
@p nvarchar(50) as

	update TAccount
	set APassword = @p
	where AUsername = @u
go
create proc PAccountShow --Xem
as
	select * 
	from TAccount
go

create proc PAccountDel --Xóa
@u varchar(50) as

	delete TAccount
	where AUsername = @u
go
------------------------------------------------------------------------
--KHÁCH HÀNG
------------------------------------------------------------------------
create proc PCustomerAdd --Thêm
@Name nvarchar(50),
@CCCD nvarchar(50),
@Address nvarchar(50),
@Phone nvarchar(50) as

	insert into TCustomer values(@Name,@CCCD,@Address,@Phone)	
go
create proc PCustomerEdit --Sửa
@ID int,
@Name nvarchar(50),
@CCCD nvarchar(50),
@Address nvarchar(50),
@Phone nvarchar(50) as

	update TCustomer
	set CName = @Name, CCCD = @CCCD, CAddress = @Address, CPhone = @Phone
	where ID = @ID
go
create proc PCustomerShow --Xem
as
	select * 
	from TCustomer
	where ID <> 1
go
create proc PCustomerDelByID --Xóa
@ID int as

	delete TCustomer
	where ID = @ID
go
------------------------------------------------------------------------
--CHỨC VỤ
------------------------------------------------------------------------
create proc PRegencyAdd --Thêm
@Name nvarchar(50),
@Salary int as

	insert into TRegency values(@Name,@Salary)
go
------------------------------------------------------------------------
--BÀN ĂN
------------------------------------------------------------------------
create proc PTableAdd --THÊM
@Name nvarchar(50),
@Kind nvarchar(50),
@Chair int as

	insert into TTable values(@Name,@Kind,@Chair,N'Bàn Trống')	
go
create proc PTableShow --XEM
as
	select *
	from TTable
	ORDER BY TName ASC
go
create proc PTableFindByID --TÌM THEO ID
@ID int as

	select *
	from TTable
	where ID = @ID
	ORDER BY TName ASC
go
create proc PTableDel --XÓA THEO ID
@ID int as

	delete TTable
	where ID = @ID
go
------------------------------------------------------------------------
--ĐẶT BÀN ĂN
------------------------------------------------------------------------
create proc PEmptyTableShow --Kèm Trạng thái
as  
	select *
	from VEmptyTable
	where TStatus <> N'Bàn Trống'
	ORDER BY TName ASC
go
create proc PEmptyTableFindByKind --Sort theo Loại
@Kind nvarchar(50) as

	select *
	from VEmptyTable
	where  TKind = @Kind
	ORDER BY TName ASC
go
create proc PEmptyTableSearch --Tìm theo Tên & Loại
@Search nvarchar(50) as

	select *
	from VEmptyTable
	where TKind like @Search or TName like @Search
	ORDER BY TName ASC
go

create proc POrderedTableShow --Kèm Trạng thái
as
	select *
	from VOrderedTable
	ORDER BY TName ASC
go
create proc POrderedTableSearchFindByKind --Sort theo Loại
@Kind nvarchar(50) as

	select *
	from VOrderedTable
	where TKind like @Kind
	ORDER BY TName ASC
go
create proc POrderedTableSearch --Tìm kiếm
@Search nvarchar(50) as

	select *
	from VOrderedTable
	where TName like @Search 
			or TKind like @Search 
			or CustomerName like @Search 
			or (select '%' + convert(varchar,OTake,105) + ' ' + convert(varchar,OTake,8) + '%') like @Search
	ORDER BY TName ASC
go

create proc POrderedTableTodayShow --Kèm Trạng thái
as
	select *
	from VOrderedTableToday
	ORDER BY TName ASC
go
create proc POrderedTableTodayFindByKind --Sort theo Loại
@Kind nvarchar(50) as

	select *
	from OrderTableInToday
	where Kind = @Kind
	ORDER BY Name ASC
go
create proc POrderedTableTodaySearch --Tìm theo Tên & Loại
@Search nvarchar(50) as

	select *
	from VOrderedTableToday
	where TName like @Search 
			or TKind like @Search 
			or CustomerName like @Search 
			or (select '%' + convert(varchar,OTake,105) + ' ' + convert(varchar,OTake,8) + '%') like @Search
	ORDER BY TName ASC
go

create proc PEmptyAOrderedTable --SỬA TRẠNG THÁI BÀN ĂN
@TableID int,
@OrderID int as

	update TOrderTable
	set OIsTakeOrCancel = 2
	where ID = @OrderID
	
	update TTable
	set TStatus = 1
	where ID = @TableID
go
create proc POrederTableAdd --THÊM ĐẶT BÀN
@TableID int,
@CustomerID int,
@Book varchar(20),
@Take varchar(20) as

	declare @Date1 datetime,@Date2 datetime
	set @Date1 = (select convert(datetime,@Book,105))
	set @Date2 = (select convert(datetime,@Take,105))
	
	insert into TOrderTable values(@TableID,@CustomerID,@Date1,@Date2,1)
	update TTable
	set TStatus = N'Đã Đặt'
	where ID = @TableID
go
------------------------------------------------------------------------
--NHÂN VIÊN
------------------------------------------------------------------------
create proc PStaffAdd --Thêm
@Name nvarchar(50),
@CCCD varchar(12),
@Phone varchar(10), 
@Image image,
@Regency varchar(10),
@Account varchar(50) as

	declare @RegencyID int
	set @RegencyID = (select ID from TRegency where RName like @Regency)
	
	insert into TStaff values(@Name,@CCCD,@Phone,@Image,@RegencyID,@Account)
go

create proc PStaffShow --Xem
as
	select *
	from VStaff
go
create proc PStaffFindByUsername --Tìm theo tên tài khoản
@u varchar(50) as

	select ID
	from VStaff
	where UserName = @u
go
create proc PStaffFindByID --Tìm theo ID
@ID int as

	select SImage, SName,CCCD, SPhone,UserName,RName as 'Regency' 
	from TStaff Ts, TRegency Tr
	where Tr.ID = Ts.RegencyID and Ts.ID = @ID
go
create proc PStaffEdit --Sửa
@ID int,
@Name nvarchar(50),
@CCCD varchar(15),
@Phone varchar(10), 
@Regency nvarchar(50),
@Account varchar(50),
@Img image as

	declare @RegencyID int
	set @RegencyID = (select ID from TRegency where RName like @Regency)
	
	update TStaff
	set SName = @Name,CCCD = @CCCD, sPhone = @Phone,RegencyID = @RegencyID,UserName = @Account,SImage = @Img
	where ID = @ID
go
create proc PStaffDel --Xóa
@ID int as

	delete TStaff
	where ID = @ID
go
------------------------------------------------------------------------
--HÓA ĐƠN
------------------------------------------------------------------------
create proc PBillAdd -- Thêm
@FoodID int, 
@isBank int,
@StaffID int,
@CustomerID int as

	declare @BillID varchar(50),@BillDate varchar(50)
	set @BillID = (select replace(convert(varchar, getdate(),5),'-','') + replace(convert(varchar, getdate(),8),':','') )
	set @BillDate = (select convert(varchar, getdate(),105) + ' ' + convert(varchar, getdate(),8))

	insert into TBill values(@BillID,@BillDate,@FoodID,@isBank,@StaffID,@CustomerID)
go

create proc PBillShow --Xem
as
	select *
	from VBill
	ORDER BY BillID DESC
go
create proc PBillDel --Xóa
@BillID varchar(50) as

	delete TBill
	where BillID like @BillID
go
create proc PBillDetailFindByID --Tìm theo ID
@BillID varchar(50) as

	select FoodID, FName, FPrice, COUNT(FoodID) as Quantity, SUM(FPrice) as Total 
	from TBill Tt, TFood Tf
	where FoodID = Tf.ID and BillID like @BillID
	group by FoodID, FName, FPrice
go
create proc PBillDetailDel --Xóa chi tiết hóa đơn theo ID
@Id int, @billID varchar(50) as

	delete TBill
	where FoodID = @Id and BillID = @billID
go
------------------------------------------------------------------------
--TEST
------------------------------------------------------------------------
exec PAccountAdd 'admin','admin'
exec PAccountAdd 'thungan01','1'
exec PAccountAdd '','alkjqaldj2'

exec PRegencyAdd N'Thu Ngân',3000000
exec PRegencyAdd N'Phục Vụ',3000000
exec PRegencyAdd N'Nhân Viên Pha Chế',0
exec PRegencyAdd N'Bếp Trưởng',0
exec PRegencyAdd N'Bếp Phó',0
exec PRegencyAdd N'Quản Lý',3000000
exec PRegencyAdd N'Admin',9999



