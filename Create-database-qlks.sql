
Create database QLKSan
Go
Use QLKSan
GO

Create table Employee 
(
	Employee_ID INT IDENTITY Primary Key,
	Emp_Name nvarchar (100) not null,
	Emp_Phone nvarchar (100),
	Emp_Email nvarchar (100) ,
	Emp_BirthDay date not null,
	Emp_Address nvarchar (1000),
	Emp_CMND nvarchar (100) not null,
	Emp_Detail nvarchar (100)
)
GO

Create table Room_Type
(
	Room_Type_ID nvarchar (100) primary key,
	Room_Type_Name nvarchar (100) not null,
	Room_Prices float not null default 0,
	Number_min int default 0 NOT NULL,
	Number_max int default 0 NOT null
)
GO

Create table Room_status 
(
	Room_stat_ID nvarchar (100) primary Key,
	Room_stat_name nvarchar (100) not null,
)
GO

Create table Room 
(
	Room_ID nvarchar (100) primary key,
	Room_number nvarchar(1000) not null,
	Room_Type_ID nvarchar (100),
	Room_stat_ID nvarchar (100),
	Room_Notes nvarchar (1000)

	Foreign key (Room_Type_ID) references dbo.Room_Type (Room_Type_ID),
	Foreign key (Room_stat_ID) references dbo.Room_status (Room_stat_ID)
)
Go

Create table Account_Type
(
	Account_type_ID nvarchar (100) primary key,
	Account_type_name nvarchar (100) not null
)
GO

Create table Account 
(
	UserName nvarchar (100) primary key,
	Display_name nvarchar (100) not null,
	password nvarchar (100) not NULL DEFAULT 1,
	Account_type_ID nvarchar (100),
	Employee_ID int

	Foreign key (Account_type_ID) references dbo.Account_Type (Account_type_ID),
	FOREIGN KEY (Employee_ID) REFERENCES Employee (Employee_ID)
)
Go

Create table Customer 
(
	Customer_ID INT IDENTITY primary key,
	Cus_name nvarchar (100) not null,
	Cus_Phone nvarchar (20) ,
	Cus_CMND nvarchar (50) ,
	Cus_Email nvarchar (100)  
)
GO

create table Services_Category
(
	Services_category_ID nvarchar (20) primary key,
	Category_name nvarchar (100) not null
)
Go

Create table Services
(
	Services_ID nvarchar (20) primary key,
	Services_name nvarchar (50) not null,
	Prices float not null default 0,
	Unit NVARCHAR(100) NOT NULL,
	Services_category_ID nvarchar (20)

	foreign key (Services_category_ID) references dbo. Services_Category (Services_category_ID)
)
GO

Create table Booking_type
(
	Booking_Type_ID nvarchar (20) primary key,
	Booking_type_name nvarchar (100) not null
)
GO

CREATE TABLE Booking_status 
(
	Booking_status_id INT PRIMARY KEY,
	Name NVARCHAR(100)
)
GO

Create table Booking
(
	Booking_ID INT IDENTITY primary key,
	Date_Book datetime,
	Date_Checkin datetime,
	Date_Checkout datetime,
	Deposit float default 0,
	Booking_Type_ID nvarchar (20) not null,
	UserName nvarchar (100) not null,
	Customer_ID INT not null,
	Room_ID nvarchar (100) not NULL,
    Booking_status_id int DEFAULT 0

	foreign key (UserName) references dbo.Account (UserName),
	Foreign Key (Room_ID) references dbo.Room (Room_ID),
	Foreign Key (Customer_ID) references dbo.Customer (Customer_ID),
	Foreign Key (Booking_Type_ID) references dbo.Booking_type (Booking_Type_ID),
	FOREIGN KEY (Booking_status_id) REFERENCES Booking_status (Booking_status_id)
)
GO

Create table Bill 
(
	Bill_ID INT IDENTITY primary key,
	Date_Chekin datetime,
	Date_Checkout datetime,
	Date_Created datetime default getdate (),
	Deposit float default 0,
	Discount float default 0,
	Bill_Status INT not NULL DEFAULT 0,
	Total FLOAT DEFAULT 0 ,
	UserName nvarchar (100) not null,
	Customer_ID INT not null,
	Room_ID nvarchar (100) not null

	foreign key (UserName) references dbo.Account (UserName),
	Foreign Key (Room_ID) references dbo.Room (Room_ID),
	Foreign Key (Customer_ID) references dbo.Customer (Customer_ID),
)
GO

Create table Bill_Detail
(
	Bill_detail_ID INT IDENTITY primary key,
	Quantity_Services int not NULL DEFAULT 0,
	Services_ID nvarchar (20) not null,
	Bill_ID INT not null

	Foreign Key (Bill_ID) references dbo.Bill (Bill_ID),
	Foreign Key (Services_ID) references dbo.Services (Services_ID)
)
GO


--Thêm Nhân viên
INSERT dbo.Employee( Emp_Name ,Emp_Phone , Emp_Email ,Emp_BirthDay ,Emp_Address ,Emp_CMND ,Emp_Detail)
VALUES  ( N'Nguyễn Vương Minh Hiếu',N'123456789' ,N'',GETDATE() ,N'', N'079098000312', N'')
INSERT dbo.Employee( Emp_Name ,Emp_Phone , Emp_Email ,Emp_BirthDay ,Emp_Address ,Emp_CMND ,Emp_Detail)
VALUES  ( N'Đỗ Duy Thiện',N'123456789' ,N'',GETDATE() ,N'', N'079098000712', N'')
INSERT dbo.Employee( Emp_Name ,Emp_Phone , Emp_Email ,Emp_BirthDay ,Emp_Address ,Emp_CMND ,Emp_Detail)
VALUES  ( N'Nguyễn Thị Hạnh Tiên',N'123456789' ,N'',GETDATE() ,N'', N'079098000712', N'')

--Thêm vào loại tài khoản--
INSERT dbo.Account_Type ( Account_type_ID , Account_type_name)
VALUES  ( N'01' , N'User')
INSERT dbo.Account_Type ( Account_type_ID ,Account_type_name)
VALUES  ( N'00' ,N'Admin')
GO

--Thêm vào danh sách người dùng--
INSERT dbo.Account( UserName , Display_name , password ,  Account_type_ID , Employee_ID)
VALUES  ( N'Admin' , N'Admin' , N'1' , N'00', 1)
INSERT dbo.Account( UserName , Display_name , password ,  Account_type_ID , Employee_ID)
VALUES  (N'DuyThien' , N'Do Duy Thien' , N'2498' , N'01' , 2)
GO


--Thêm trạng thái phòng sách phòng--
INSERT dbo.Room_status ( Room_stat_ID, Room_stat_name )
VALUES  ( N'00',N'Trống')
INSERT dbo.Room_status ( Room_stat_ID, Room_stat_name )
VALUES  ( N'01',N'Đã Đặt')
INSERT dbo.Room_status ( Room_stat_ID, Room_stat_name )
VALUES  ( N'02',N'Có Khách')
INSERT dbo.Room_status ( Room_stat_ID, Room_stat_name )
VALUES  ( N'03',N'Bảo trì')
GO
--Thêm kiểu phòng--
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT00' , N'Thường Giường Đơn' ,  80000.0, 0 , 02 )
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT01' , N'Thường Giường Đôi' ,  120000.0, 0 , 02 )
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT02' , N'Thường Hai Giường Đơn' ,  140000.0, 0 , 04 )
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT03' , N'Thường Ba Giường Đơn' ,  160000.0, 0 , 06)
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT04' , N'VIP Giường Đơn' ,  200000.0, 0 , 01 )
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT05' , N'VIP Giường Đôi' ,  250000.0, 0 , 02 )
INSERT dbo.Room_Type( Room_Type_ID ,Room_Type_Name ,Room_Prices , Number_min , Number_max)
VALUES  ( N'RT06' , N'VIP Giường Đơn Lớn' ,  300000.0, 0 , 01 )
GO
--Thêm Danh sách phòng--
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R101' , N'101' ,  N'RT00' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R102' , N'102' ,  N'RT01' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R103' , N'103' ,  N'RT02' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R104' , N'104' ,  N'RT03' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R105' , N'105' ,  N'RT00' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R106' , N'106' ,  N'RT02' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R107' , N'107' ,  N'RT04' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R108' , N'108' ,  N'RT05' ,  N'00' , N''  )
INSERT dbo.Room( Room_ID ,Room_number ,Room_Type_ID , Room_stat_ID , Room_Notes )
VALUES  ( N'R109' , N'109' ,  N'RT06' ,  N'00' , N''  )
GO

--Thêm khách hàng---
INSERT dbo.Customer( Cus_name ,Cus_Phone ,Cus_CMND ,Cus_Email)
VALUES  ( N'Bùi Kim Quyên' ,  N'0345676648' , N'079190000257' ,  N'kimquyen90@gmail.com'  )
INSERT dbo.Customer( Cus_name ,Cus_Phone ,Cus_CMND ,Cus_Email)
VALUES  ( N'Võ An Phước Thiện' ,  N'0965908980' , N'079087000224' ,  N'phuocthien24@gmail.com'  )
INSERT dbo.Customer( Cus_name ,Cus_Phone ,Cus_CMND ,Cus_Email)
VALUES  ( N'Dương Hoài Phương' ,  N'0987202992' , N'079194000023' ,  N''  )
INSERT dbo.Customer( Cus_name ,Cus_Phone ,Cus_CMND ,Cus_Email)
VALUES  ( N'Phan Huỳnh Ngọc Dung' ,  N'0867727123' , N'079185000592' ,  N''  )
INSERT dbo.Customer( Cus_name ,Cus_Phone ,Cus_CMND ,Cus_Email)
VALUES  ( N'Đỗ Duy Thiện' ,  N'0867258423' , N'079098000712' ,  N''  )
GO
--Thêm loại dịch vụ--
INSERT dbo.Services_Category ( Services_category_ID ,Category_name )
VALUES  ( N'SC01' ,  N'Nước uống'  )
INSERT dbo.Services_Category ( Services_category_ID ,Category_name )
VALUES  ( N'SC02' ,  N'Thức Ăn'  )
INSERT dbo.Services_Category ( Services_category_ID ,Category_name )
VALUES  ( N'SC03' ,  N'Phòng'  )
GO
--Thêm dịch vụ--
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S01' ,  N'Bia 333' ,  30000.0 , N'Lon'  , N'SC01'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S02' ,  N'Heineken' ,  40000.0 , N'Chai' , N'SC01'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S03' ,  N'7 UP' ,  25000.0 , N'Chai' , N'SC01'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S04' ,  N'Coca' ,  25000.0 , N'Lon' , N'SC01'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S05' ,  N'Nước suối' ,  20000.0 , N'Chai' , N'SC01'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S06' ,  N'Cafe' ,  40000.0 , N'Ly', N'SC01'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S07' ,  N'Cơm Tấm' ,  55000.0 , N'Phần', N'SC02'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S08' ,  N'Phở' , 70000.0 , N'Tô', N'SC02'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S09' ,  N'Bún Bò' ,  70000.0 , N'Tô', N'SC02'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S10' ,  N'Beefsteak' ,  100000.0 , N'Phần', N'SC02'  )
INSERT dbo.Services( Services_ID ,Services_name , Prices , Unit ,Services_category_ID)
VALUES  ( N'S11' ,  N'Giặt ủi' ,  50000.0 , N'Bộ', N'SC03'  )
GO
-- Thêm booking type ---
INSERT dbo.Booking_type ( Booking_Type_ID ,Booking_type_name)
VALUES  ( N'BT00' ,  N'Đảm bảo' )
INSERT dbo.Booking_type ( Booking_Type_ID ,Booking_type_name)
VALUES  ( N'BT01' ,  N'Không đảm bảo' )
GO

-- thêm booking-status---
INSERT dbo.Booking_status ( Booking_status_id, Name )
VALUES  ( 0,  N'Đang Đặt' )
INSERT dbo.Booking_status ( Booking_status_id, Name )
VALUES  ( 1,  N'Đã Đặt' )
INSERT dbo.Booking_status ( Booking_status_id, Name )
VALUES  ( 2,  N'Đã Hủy' )
GO



--Tạo Proce Login cho chức năng đăng nhập--
CREATE PROC	USP_Login
@userName nvarchar (100) , @passWord nvarchar (100) 
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE	UserName = @userName AND password = @passWord
END

EXECUTE dbo.USP_Login @userName = N'admin', @passWord = N'1'
GO

-- Tạo Proce lấy danh sách phòng--
CREATE PROC USP_LoadRoomList
AS SELECT * 
FROM dbo.Room r , dbo.Room_status rs , dbo.Room_Type rt 
WHERE r.Room_stat_ID = rs.Room_stat_ID AND r.Room_Type_ID = rt.Room_Type_ID

EXECUTE dbo.USP_LoadRoomList
GO

--Tạo Proce thêm chi tiết hóa đơn---
CREATE PROC USP_InsertBillInfo
@bill_id INT , @quantity int, @services_id NVARCHAR(20)
AS	
BEGIN
	DECLARE @IsExistBillInfo INT
	DECLARE @servquantity int =1 

	SELECT @IsExistBillInfo = a.Bill_detail_ID , @servquantity = a.Quantity_Services
	FROM dbo.Bill_Detail a
	WHERE a.Bill_ID = @bill_id AND a.Services_ID = @services_id
	IF (@IsExistBillInfo > 0)
		BEGIN
			DECLARE @NewServQuantity INT = @servquantity + @quantity
			IF (@NewServQuantity >0)
				UPDATE dbo.Bill_Detail SET Quantity_Services = @quantity + @servquantity
				WHERE  Services_ID = @services_id 
			ELSE 
				DELETE dbo.Bill_Detail WHERE Bill_ID = @bill_id AND Services_ID = @services_id
		END
	ELSE
	BEGIN
		INSERT dbo.Bill_Detail (Quantity_Services , Services_ID , Bill_ID )
		VALUES  (  @quantity , @services_id ,@bill_id )
		DECLARE @ConfirmQuantity INT = @quantity 
		IF (@ConfirmQuantity <0)
			BEGIN
				DELETE dbo.Bill_Detail WHERE Bill_ID = @bill_id AND Services_ID = @services_id
			END
	END 
END
GO

--Tạo proce trả phòng ---
CREATE PROC USP_CheckOut
@bill_id INT , @room_id NVARCHAR(100) , @deposit FLOAT , @discount FLOAT , @total FLOAT	
AS
BEGIN
	UPDATE dbo.Bill SET Bill_Status = 1, Deposit = @deposit , Discount = @discount, Total = @total WHERE Bill_ID = @bill_id
	UPDATE dbo.Room SET Room_stat_ID = N'00' WHERE Room_ID = @room_id
END
GO

--Tạo proce thêm hoá đơn--
CREATE PROC USP_InsertBill
@username NVARCHAR(100), @customer_id INT , @room_id NVARCHAR (100)
AS 
BEGIN
	INSERT dbo.Bill (Date_Chekin , Date_Checkout ,  Date_Created , Deposit ,Discount , Bill_Status , Total ,UserName , Customer_ID ,Room_ID)
	VALUES  (GETDATE() , NULL, GETDATE(), 0.0 , 0.0 , 0 , 0.0 , @username , @customer_id, @room_id)
	UPDATE dbo.Room SET Room_stat_ID = N'02' WHERE Room_ID = @room_id 
END
GO


-- Tạo proc lấy danh sách phòng trống ---
Create PROC USP_LoadRoomSwitchedList
AS
BEGIN
	SELECT *
	FROM Room r INNER JOIN dbo.Room_Type rt ON r.Room_Type_ID = rt.Room_Type_ID , dbo.Room_status rs
	WHERE r.Room_stat_ID = N'00' AND r.Room_stat_ID = rs.Room_stat_ID
END
GO

--Tạo Proce thêm Booking--
CREATE PROC USP_InsertBooking
@datecheckin DATETIME, @deposit FLOAT, @bookingtype NVARCHAR(100), @username NVARCHAR(100), @customerid INT , @roomid NVARCHAR(100)
AS
BEGIN
	SET @datecheckin = DATEADD(hour,12,@datecheckin)
	INSERT dbo.Booking ( Date_Book , Date_Checkin ,  Date_Checkout , Deposit , Booking_Type_ID ,  UserName ,  Customer_ID ,  Room_ID , Booking_status_id)
	VALUES  ( GETDATE() ,  @datecheckin , NULL ,  @deposit ,   @bookingtype , @username ,  @customerid , @roomid, 0  )
	UPDATE Room SET Room_stat_ID = N'01' WHERE Room_ID = @roomid
	
END
GO

--Tạo proce chuyển từ phòng đặt sang phòng thuê---
CREATE PROC USP_ChangeBookingToBill
@booking_id INT ,@datecheckin DATETIME , @deposit FLOAT , @username NVARCHAR(100), @customer_id INT , @room_id NVARCHAR(100)
AS
BEGIN
	INSERT dbo.Bill (Date_Chekin , Date_Checkout ,  Date_Created , Deposit ,Discount , Bill_Status , Total ,UserName , Customer_ID ,Room_ID)
	VALUES  (@datecheckin , NULL, GETDATE(), @deposit , 0.0 , 0 , 0.0 , @username , @customer_id, @room_id)
	UPDATE dbo.Room SET Room_stat_ID = N'02' WHERE Room_ID = @room_id
	UPDATE dbo.Booking SET Booking_status_id = 1 WHERE Booking_ID =@booking_id
END
GO

--Tạo Proc hủy booking--
CREATE PROC USP_CancelBooking
@booking_id INT , @room_id NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Room SET Room_stat_ID = N'00' WHERE Room_ID = @room_id
	UPDATE dbo.Booking SET Booking_status_id = 2 WHERE Booking_ID = @booking_id
END
GO	

--Tạo Proc đổi phòng--
CREATE PROC USP_SwitchRoom
@roomidold NVARCHAR(100), @roomidnew nvarchar(100) ,@billID int
AS
BEGIN
	UPDATE Bill SET Room_ID = @roomidnew WHERE Bill_ID = @billID
	UPDATE Room SET Room_stat_ID = N'00' WHERE Room_ID = @roomidold
	UPDATE Room SET Room_stat_ID = N'02' WHERE Room_ID = @roomidnew
END
GO
--Tạo proc load danh sách hóa đơn--
CREATE PROC USP_LoadBillList
@datefromdate DATETIME , @datetodate DATETIME
AS
BEGIN
	SET @datefromdate = DATEADD(hour,00,@datefromdate)
	SET @datetodate = DATEADD(HOUR,24,@datetodate)
	SELECT * FROM Bill b , dbo.Room r 
	WHERE b.Room_ID = r.Room_ID AND b.Date_Chekin >= @datefromdate AND b.Date_Checkout <= @datetodate AND b.Bill_Status =1
END
GO	
--Tạo Proce cập nhật thông tin tài khoản--
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100) , @passWord NVARCHAR(100) , @newPassWord NVARCHAR(100)
AS
BEGIN
	DECLARE @isrightpass int = 0
	SELECT @isrightpass = count (*) FROM dbo.Account WHERE @userName = UserName AND @passWord = password
	IF (@isrightpass =1)
	BEGIN
		IF (@newPassWord IS NULL OR @newPassWord = '')
		BEGIN
			UPDATE dbo.Account SET Display_name = @displayName WHERE UserName = @userName
		END
		ELSE 
			UPDATE dbo.Account SET Display_name = @displayName , password = @newPassWord WHERE UserName = @userName
	END
END
GO

-- Tạo proce tải báo cáo doanh thu--
CREATE PROCEDURE USP_LoadReport
 AS
 BEGIN
 	SELECT b.Bill_ID, r.Room_number, b.Date_Chekin,b.Date_Checkout, DATEDIFF(HOUR,b.Date_Chekin,b.Date_Checkout) AS Hour_Rent ,b.Total
	FROM Bill b JOIN dbo.Room r on b.Room_ID = r.Room_ID
	WHERE b.Bill_Status = 1
 END
GO
 EXECUTE dbo.USP_LoadReport
 GO


--Load DashBoard biểu đồ tròn, & loại phòng được sử dụng--
CREATE PROC USP_RoomTypeNameQuantityRent
@month INT , @year int
AS
BEGIN
	SELECT COUNT (b.Bill_ID) AS Count_Quantity, (rt.Room_Type_Name) AS  Room_Type
	FROM dbo.Bill b JOIN dbo.Room r ON r.Room_ID = b.Room_ID
					JOIN dbo.Room_Type rt ON rt.Room_Type_ID = r.Room_Type_ID
	WHERE b.Bill_Status = 1 AND MONTH(Date_Checkout) = @month AND Year(Date_Checkout) = @year
	GROUP BY rt.Room_Type_Name
END
GO

--Load DashBoard biểu đồ ADR (Giá bán phòng trung bình một ngày trong tháng ) ---
CREATE PROC USP_DashBoardChartADR
@month int , @year int
as 
BEGIN
	SELECT SUM(DATEDIFF(HOUR,b.Date_Chekin,b.Date_Checkout) * rt.Room_Prices) AS Room_Rent_Total , CONVERT (DATE,b.Date_Checkout) AS Day
	FROM dbo.Bill b join Room r  ON r.Room_ID = b.Room_ID
			JOIN dbo.Room_Type rt ON rt.Room_Type_ID = r.Room_Type_ID
	WHERE MONTH(CONVERT (DATE,b.Date_Checkout)) = @month AND year(CONVERT (DATE,b.Date_Checkout)) = @year	
	GROUP BY CONVERT (DATE,b.Date_Checkout)
END
GO	
