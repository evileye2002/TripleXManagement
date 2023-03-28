------------------------------------------------------------------------
--TẠO BẢNG
------------------------------------------------------------------------

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
	where s.ID = s.ID
	ORDER BY Name ASC
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
	where	s.ID = s.ID
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
	declare @Date datetime
	set @Date = (select CONVERT(datetime, GETDATE()))
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