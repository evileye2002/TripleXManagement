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