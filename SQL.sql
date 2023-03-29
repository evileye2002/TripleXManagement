------------------------------------------------------------------------
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
insert into StatusM values(N'0')
select * from StatusM

select convert(varchar, getdate(), 5)
delete Bill

exec addTable 'B201',N'Vừa',8
exec addTable 'B202',N'Vừa',8
exec addTable 'B101',N'Thường',6
exec addTable 'B102',N'Thường',6
exec addOrderTable 1,1,N'28/3/2023 18:03:03',N'29/3/2023 19:03:03'
exec addOrderTable 2,N'Khanh',N'26/3/2023 19:03:03','28/3/2023 19:03:03'
exec addOrderTable 1,N'Huong',N'26/3/2023 19:03:03','29/3/2023 19:03:03'

exec addCustomer 'Khanh',N'12345678910',N'20/3/2023',N'Thái Nguyên','0123456789'
exec addCustomer 'Huong',N'12345678910',N'20/3/2023',N'Thái Nguyên','0123456789'

(select convert(datetime,GETDATE(),103))
select CONVERT(datetime,(select convert(varchar, getdate(),105) + ' ' + convert(varchar, getdate(),8)), 20)
(select convert(datetime, getdate(),5) + ' ' + convert(varchar, getdate(),8))
select * from TableM

getOrderedTablebyKind N'Vừa'
getOrderTableInTodaybyKind N'Trung'
getEmptyTablebyKind N'Vừa'

getEmptyTableSearch N'%202%'
getOrderedTableSearch '%uo%'
getOrderTableInTodaySearch N'%uo%'
exec getStaffbyID 2

select Image, Name, ID from Staff where ID = 13
de

getFoodbyID '2'

emptyOrderTable 