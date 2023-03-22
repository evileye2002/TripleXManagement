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

create proc delMonAnbyId
@Id int as
	delete MonAn from MonAn where ID = @Id
go

create proc editMonAnbyId
@Id int,@Name nvarchar(50),@Price int, @Image image as
	update MonAn 
	set Name = @Name, Price = @Price, Image = @Image
	where ID = @Id
go

exec getMonAn2