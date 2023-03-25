--Món Ăn
create proc addmMonAn
@Name nvarchar(50),@Price int, @Image image as
	insert into MonAn values(@Name,@Price,@Image)
go

create proc getMonAn as
	select Image, Name, Price, ID from MonAn
go

create proc getMonAn2 as
	select ID, Name, Price from MonAn
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
@Id int as
	delete Bill
	where FoodID = @Id
go

--===============================================
exec addBill 4, 0
exec addBill 3, 0
exec getBill
exec getBillbyId '%114'

select convert(varchar, getdate(), 5)
delete Bill