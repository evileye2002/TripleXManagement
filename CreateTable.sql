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
	CCCD varchar(12) Not Null,
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
	RSalary int Null,
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
	TStatus nvarchar(20) Not Null,
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
	BillID varchar(14) Not Null,
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
	select BillID,BDate, SUM(FPrice) as Total,Ts.SName as StaffName,Tc.CName as CustomerName,BIsBank
	from TBill Tb, TFood Tf, TStaff Ts,TCustomer Tc
	where FoodID = Tf.ID 
			and Ts.Id = Tb.StaffID 
			and Tc.ID = Tb.CustomerID
			
	group by BillID, BDate, BIsBank
go
------------------------------------------------------------------------
