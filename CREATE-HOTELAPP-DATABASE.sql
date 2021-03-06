USE [QLKSan]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[Display_name] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL DEFAULT ((1)),
	[Account_type_ID] [nvarchar](100) NULL,
	[Employee_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account_Type]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Type](
	[Account_type_ID] [nvarchar](100) NOT NULL,
	[Account_type_name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Account_type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Bill_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date_Chekin] [datetime] NULL,
	[Date_Checkout] [datetime] NULL,
	[Date_Created] [datetime] NULL DEFAULT (getdate()),
	[Deposit] [float] NULL DEFAULT ((0)),
	[Discount] [float] NULL DEFAULT ((0)),
	[Bill_Status] [int] NOT NULL DEFAULT ((0)),
	[Total] [float] NULL DEFAULT ((0)),
	[UserName] [nvarchar](100) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Room_ID] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Bill_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill_Detail]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill_Detail](
	[Bill_detail_ID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity_Services] [int] NOT NULL DEFAULT ((0)),
	[Services_ID] [nvarchar](20) NOT NULL,
	[Bill_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Bill_detail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Booking_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date_Book] [datetime] NULL,
	[Date_Checkin] [datetime] NULL,
	[Date_Checkout] [datetime] NULL,
	[Deposit] [float] NULL DEFAULT ((0)),
	[Booking_Type_ID] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Room_ID] [nvarchar](100) NOT NULL,
	[Booking_status_id] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Booking_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking_status]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_status](
	[Booking_status_id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Booking_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking_type]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_type](
	[Booking_Type_ID] [nvarchar](20) NOT NULL,
	[Booking_type_name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Booking_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus_name] [nvarchar](100) NOT NULL,
	[Cus_Phone] [nvarchar](20) NULL,
	[Cus_CMND] [nvarchar](50) NULL,
	[Cus_Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Employee_ID] [int] IDENTITY(1,1) NOT NULL,
	[Emp_Name] [nvarchar](100) NOT NULL,
	[Emp_Phone] [nvarchar](100) NULL,
	[Emp_Email] [nvarchar](100) NULL,
	[Emp_BirthDay] [date] NOT NULL,
	[Emp_Address] [nvarchar](1000) NULL,
	[Emp_CMND] [nvarchar](100) NOT NULL,
	[Emp_Detail] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Room_ID] [nvarchar](100) NOT NULL,
	[Room_number] [nvarchar](1000) NOT NULL,
	[Room_Type_ID] [nvarchar](100) NULL,
	[Room_stat_ID] [nvarchar](100) NULL,
	[Room_Notes] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Room_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room_status]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_status](
	[Room_stat_ID] [nvarchar](100) NOT NULL,
	[Room_stat_name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Room_stat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room_Type]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Type](
	[Room_Type_ID] [nvarchar](100) NOT NULL,
	[Room_Type_Name] [nvarchar](100) NOT NULL,
	[Room_Prices] [float] NOT NULL DEFAULT ((0)),
	[Number_min] [int] NOT NULL DEFAULT ((0)),
	[Number_max] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Room_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Services_ID] [nvarchar](20) NOT NULL,
	[Services_name] [nvarchar](50) NOT NULL,
	[Prices] [float] NOT NULL DEFAULT ((0)),
	[Unit] [nvarchar](100) NOT NULL,
	[Services_category_ID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Services_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services_Category]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services_Category](
	[Services_category_ID] [nvarchar](20) NOT NULL,
	[Category_name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Services_category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([UserName], [Display_name], [password], [Account_type_ID], [Employee_ID]) VALUES (N'Admin', N'Admin', N'1', N'00', 1)
INSERT [dbo].[Account] ([UserName], [Display_name], [password], [Account_type_ID], [Employee_ID]) VALUES (N'DuyThien', N'Do Duy Thien', N'2498', N'01', 2)
INSERT [dbo].[Account_Type] ([Account_type_ID], [Account_type_name]) VALUES (N'00', N'Admin')
INSERT [dbo].[Account_Type] ([Account_type_ID], [Account_type_name]) VALUES (N'01', N'User')
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (1, CAST(N'2020-02-27 10:49:54.293' AS DateTime), CAST(N'2020-02-28 10:50:34.313' AS DateTime), CAST(N'2020-02-27 10:49:54.293' AS DateTime), 0, 0, 1, 3555000, N'Admin', 1, N'R106')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (2, CAST(N'2020-02-27 12:21:49.577' AS DateTime), CAST(N'2020-02-27 15:23:16.900' AS DateTime), CAST(N'2020-02-27 12:21:49.577' AS DateTime), 0, 0, 1, 240000, N'Admin', 1, N'R101')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (3, CAST(N'2020-02-27 12:21:56.883' AS DateTime), CAST(N'2020-02-27 15:23:21.350' AS DateTime), CAST(N'2020-02-27 12:21:56.883' AS DateTime), 0, 0, 1, 360000, N'Admin', 2, N'R102')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (4, CAST(N'2020-02-27 12:22:01.880' AS DateTime), CAST(N'2020-02-29 15:23:34.447' AS DateTime), CAST(N'2020-02-27 12:22:01.880' AS DateTime), 0, 0, 1, 7140000, N'Admin', 3, N'R103')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (5, CAST(N'2020-02-27 12:22:07.107' AS DateTime), CAST(N'2020-02-29 15:23:38.873' AS DateTime), CAST(N'2020-02-27 12:22:07.107' AS DateTime), 0, 0, 1, 8160000, N'Admin', 4, N'R104')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (6, CAST(N'2020-02-27 12:22:11.973' AS DateTime), CAST(N'2020-02-27 23:24:24.493' AS DateTime), CAST(N'2020-02-27 12:22:11.973' AS DateTime), 0, 0, 1, 880000, N'Admin', 5, N'R105')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (7, CAST(N'2020-02-29 19:58:39.180' AS DateTime), CAST(N'2020-02-29 22:01:46.750' AS DateTime), CAST(N'2020-02-29 19:58:39.180' AS DateTime), 0, 0, 1, 630000, N'Admin', 1, N'R106')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (8, CAST(N'2020-02-29 19:58:43.827' AS DateTime), CAST(N'2020-02-29 23:02:02.560' AS DateTime), CAST(N'2020-02-29 19:58:43.827' AS DateTime), 0, 0, 1, 920000, N'Admin', 2, N'R107')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (9, CAST(N'2020-02-29 19:58:56.810' AS DateTime), CAST(N'2020-02-29 22:01:54.097' AS DateTime), CAST(N'2020-02-29 19:58:56.810' AS DateTime), 0, 0, 1, 930000, N'Admin', 4, N'R108')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (10, CAST(N'2020-02-29 19:59:01.757' AS DateTime), CAST(N'2020-02-29 23:02:07.517' AS DateTime), CAST(N'2020-02-29 19:59:01.757' AS DateTime), 0, 0, 1, 1200000, N'Admin', 5, N'R109')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (11, CAST(N'2020-03-01 20:03:07.640' AS DateTime), CAST(N'2020-03-02 08:04:55.153' AS DateTime), CAST(N'2020-03-01 20:03:07.640' AS DateTime), 0, 0, 1, 980000, N'Admin', 1, N'R105')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (12, CAST(N'2020-03-01 20:03:22.277' AS DateTime), CAST(N'2020-03-01 23:04:20.377' AS DateTime), CAST(N'2020-03-01 20:03:22.277' AS DateTime), 0, 0, 1, 270000, N'Admin', 2, N'R101')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (13, CAST(N'2020-03-01 20:03:27.447' AS DateTime), CAST(N'2020-03-01 23:04:35.940' AS DateTime), CAST(N'2020-03-01 20:03:27.447' AS DateTime), 0, 0, 1, 620000, N'Admin', 3, N'R103')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (14, CAST(N'2020-03-01 20:03:31.913' AS DateTime), CAST(N'2020-03-02 08:04:59.020' AS DateTime), CAST(N'2020-03-01 20:03:31.913' AS DateTime), 0, 0, 1, 2450000, N'Admin', 4, N'R107')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (15, CAST(N'2020-03-01 20:03:36.843' AS DateTime), CAST(N'2020-03-02 08:05:02.657' AS DateTime), CAST(N'2020-03-01 20:03:36.843' AS DateTime), 0, 0, 1, 3650000, N'Admin', 5, N'R109')
INSERT [dbo].[Bill] ([Bill_ID], [Date_Chekin], [Date_Checkout], [Date_Created], [Deposit], [Discount], [Bill_Status], [Total], [UserName], [Customer_ID], [Room_ID]) VALUES (16, CAST(N'2020-02-29 21:20:49.830' AS DateTime), NULL, CAST(N'2020-02-29 21:20:49.830' AS DateTime), 0, 0, 0, 0, N'Admin', 2, N'R105')
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[Bill_Detail] ON 

INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (1, 1, N'S01', 1)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (2, 1, N'S03', 1)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (3, 2, N'S08', 1)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (4, 1, N'S11', 7)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (5, 1, N'S10', 7)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (6, 2, N'S01', 7)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (7, 2, N'S03', 8)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (8, 1, N'S08', 8)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (9, 2, N'S05', 9)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (10, 2, N'S09', 9)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (11, 1, N'S01', 12)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (12, 4, N'S03', 13)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (13, 1, N'S05', 11)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (14, 2, N'S03', 14)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (15, 1, N'S11', 15)
INSERT [dbo].[Bill_Detail] ([Bill_detail_ID], [Quantity_Services], [Services_ID], [Bill_ID]) VALUES (16, 2, N'S11', 13)
SET IDENTITY_INSERT [dbo].[Bill_Detail] OFF
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Booking_ID], [Date_Book], [Date_Checkin], [Date_Checkout], [Deposit], [Booking_Type_ID], [UserName], [Customer_ID], [Room_ID], [Booking_status_id]) VALUES (1, CAST(N'2020-02-29 21:23:10.257' AS DateTime), CAST(N'2020-03-01 12:00:00.000' AS DateTime), NULL, 0, N'BT00', N'Admin', 2, N'R107', 2)
INSERT [dbo].[Booking] ([Booking_ID], [Date_Book], [Date_Checkin], [Date_Checkout], [Deposit], [Booking_Type_ID], [UserName], [Customer_ID], [Room_ID], [Booking_status_id]) VALUES (2, CAST(N'2020-02-29 21:23:51.663' AS DateTime), CAST(N'2020-03-01 12:00:00.000' AS DateTime), NULL, 0, N'BT00', N'Admin', 1, N'R109', 0)
INSERT [dbo].[Booking] ([Booking_ID], [Date_Book], [Date_Checkin], [Date_Checkout], [Deposit], [Booking_Type_ID], [UserName], [Customer_ID], [Room_ID], [Booking_status_id]) VALUES (3, CAST(N'2020-02-29 21:24:44.143' AS DateTime), CAST(N'2020-03-01 12:00:00.000' AS DateTime), NULL, 200000, N'BT00', N'Admin', 2, N'R101', 2)
SET IDENTITY_INSERT [dbo].[Booking] OFF
INSERT [dbo].[Booking_status] ([Booking_status_id], [Name]) VALUES (0, N'Đang Đặt')
INSERT [dbo].[Booking_status] ([Booking_status_id], [Name]) VALUES (1, N'Đã Đặt')
INSERT [dbo].[Booking_status] ([Booking_status_id], [Name]) VALUES (2, N'Đã Hủy')
INSERT [dbo].[Booking_type] ([Booking_Type_ID], [Booking_type_name]) VALUES (N'BT00', N'Đảm bảo')
INSERT [dbo].[Booking_type] ([Booking_Type_ID], [Booking_type_name]) VALUES (N'BT01', N'Không đảm bảo')
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Customer_ID], [Cus_name], [Cus_Phone], [Cus_CMND], [Cus_Email]) VALUES (1, N'Bùi Kim Quyên', N'0345676648', N'079190000257', N'kimquyen90@gmail.com')
INSERT [dbo].[Customer] ([Customer_ID], [Cus_name], [Cus_Phone], [Cus_CMND], [Cus_Email]) VALUES (2, N'Võ An Phước Thiện', N'0965908980', N'079087000224', N'phuocthien24@gmail.com')
INSERT [dbo].[Customer] ([Customer_ID], [Cus_name], [Cus_Phone], [Cus_CMND], [Cus_Email]) VALUES (3, N'Dương Hoài Phương', N'0987202992', N'079194000023', N'')
INSERT [dbo].[Customer] ([Customer_ID], [Cus_name], [Cus_Phone], [Cus_CMND], [Cus_Email]) VALUES (4, N'Phan Huỳnh Ngọc Dung', N'0867727123', N'079185000592', N'')
INSERT [dbo].[Customer] ([Customer_ID], [Cus_name], [Cus_Phone], [Cus_CMND], [Cus_Email]) VALUES (5, N'Đỗ Duy Thiện', N'0867258423', N'079098000712', N'')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Employee_ID], [Emp_Name], [Emp_Phone], [Emp_Email], [Emp_BirthDay], [Emp_Address], [Emp_CMND], [Emp_Detail]) VALUES (1, N'Nguyễn Vương Minh Hiếu', N'123456789', N'', CAST(N'2020-02-27' AS Date), N'', N'079098000312', N'')
INSERT [dbo].[Employee] ([Employee_ID], [Emp_Name], [Emp_Phone], [Emp_Email], [Emp_BirthDay], [Emp_Address], [Emp_CMND], [Emp_Detail]) VALUES (2, N'Đỗ Duy Thiện', N'123456789', N'', CAST(N'2020-02-27' AS Date), N'', N'079098000712', N'')
INSERT [dbo].[Employee] ([Employee_ID], [Emp_Name], [Emp_Phone], [Emp_Email], [Emp_BirthDay], [Emp_Address], [Emp_CMND], [Emp_Detail]) VALUES (3, N'Nguyễn Thị Hạnh Tiên', N'123456789', N'', CAST(N'2020-02-29' AS Date), N'', N'079098000712', N'')
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R101', N'101', N'RT00', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R102', N'102', N'RT01', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R103', N'103', N'RT02', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R104', N'104', N'RT03', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R105', N'105', N'RT00', N'02', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R106', N'106', N'RT02', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R107', N'107', N'RT04', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R108', N'108', N'RT05', N'00', N'')
INSERT [dbo].[Room] ([Room_ID], [Room_number], [Room_Type_ID], [Room_stat_ID], [Room_Notes]) VALUES (N'R109', N'109', N'RT06', N'01', N'')
INSERT [dbo].[Room_status] ([Room_stat_ID], [Room_stat_name]) VALUES (N'00', N'Trống')
INSERT [dbo].[Room_status] ([Room_stat_ID], [Room_stat_name]) VALUES (N'01', N'Đã Đặt')
INSERT [dbo].[Room_status] ([Room_stat_ID], [Room_stat_name]) VALUES (N'02', N'Có Khách')
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT00', N'Thường Giường Đơn', 80000, 0, 2)
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT01', N'Thường Giường Đôi', 120000, 0, 2)
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT02', N'Thường Hai Giường Đơn', 140000, 0, 4)
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT03', N'Thường Ba Giường Đơn', 160000, 0, 6)
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT04', N'VIP Giường Đơn', 200000, 0, 1)
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT05', N'VIP Giường Đôi', 250000, 0, 2)
INSERT [dbo].[Room_Type] ([Room_Type_ID], [Room_Type_Name], [Room_Prices], [Number_min], [Number_max]) VALUES (N'RT06', N'VIP Giường Đơn Lớn', 300000, 0, 1)
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S01', N'Bia 333', 30000, N'Lon', N'SC01')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S02', N'Heineken', 40000, N'Chai', N'SC01')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S03', N'7 UP', 25000, N'Chai', N'SC01')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S04', N'Coca', 25000, N'Lon', N'SC01')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S05', N'Nước suối', 20000, N'Chai', N'SC01')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S06', N'Cafe', 40000, N'Ly', N'SC01')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S07', N'Cơm Tấm', 55000, N'Phần', N'SC02')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S08', N'Phở', 70000, N'Tô', N'SC02')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S09', N'Bún Bò', 70000, N'Tô', N'SC02')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S10', N'Beefsteak', 100000, N'Phần', N'SC02')
INSERT [dbo].[Services] ([Services_ID], [Services_name], [Prices], [Unit], [Services_category_ID]) VALUES (N'S11', N'Giặt ủi', 50000, N'Bộ', N'SC03')
INSERT [dbo].[Services_Category] ([Services_category_ID], [Category_name]) VALUES (N'SC01', N'Nước uống')
INSERT [dbo].[Services_Category] ([Services_category_ID], [Category_name]) VALUES (N'SC02', N'Thức Ăn')
INSERT [dbo].[Services_Category] ([Services_category_ID], [Category_name]) VALUES (N'SC03', N'Phòng')
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([Account_type_ID])
REFERENCES [dbo].[Account_Type] ([Account_type_ID])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employee] ([Employee_ID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([Room_ID])
REFERENCES [dbo].[Room] ([Room_ID])
GO
ALTER TABLE [dbo].[Bill_Detail]  WITH CHECK ADD FOREIGN KEY([Bill_ID])
REFERENCES [dbo].[Bill] ([Bill_ID])
GO
ALTER TABLE [dbo].[Bill_Detail]  WITH CHECK ADD FOREIGN KEY([Services_ID])
REFERENCES [dbo].[Services] ([Services_ID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([Booking_Type_ID])
REFERENCES [dbo].[Booking_type] ([Booking_Type_ID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([Booking_status_id])
REFERENCES [dbo].[Booking_status] ([Booking_status_id])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([Room_ID])
REFERENCES [dbo].[Room] ([Room_ID])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([Room_Type_ID])
REFERENCES [dbo].[Room_Type] ([Room_Type_ID])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([Room_stat_ID])
REFERENCES [dbo].[Room_status] ([Room_stat_ID])
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([Services_category_ID])
REFERENCES [dbo].[Services_Category] ([Services_category_ID])
GO
/****** Object:  StoredProcedure [dbo].[USP_CancelBooking]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo Proc hủy booking--
CREATE PROC [dbo].[USP_CancelBooking]
@booking_id INT , @room_id NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Room SET Room_stat_ID = N'00' WHERE Room_ID = @room_id
	UPDATE dbo.Booking SET Booking_status_id = 2 WHERE Booking_ID = @booking_id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_ChangeBookingToBill]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo proce chuyển từ phòng đặt sang phòng thuê---
CREATE PROC [dbo].[USP_ChangeBookingToBill]
@booking_id INT ,@datecheckin DATETIME , @deposit FLOAT , @username NVARCHAR(100), @customer_id INT , @room_id NVARCHAR(100)
AS
BEGIN
	INSERT dbo.Bill (Date_Chekin , Date_Checkout ,  Date_Created , Deposit ,Discount , Bill_Status , Total ,UserName , Customer_ID ,Room_ID)
	VALUES  (@datecheckin , NULL, GETDATE(), @deposit , 0.0 , 0 , 0.0 , @username , @customer_id, @room_id)
	UPDATE dbo.Room SET Room_stat_ID = N'02' WHERE Room_ID = @room_id
	UPDATE dbo.Booking SET Booking_status_id = 1 WHERE Booking_ID =@booking_id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_CheckOut]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo proce trả phòng ---
CREATE PROC [dbo].[USP_CheckOut]
@bill_id INT , @room_id NVARCHAR(100) , @deposit FLOAT , @discount FLOAT , @total FLOAT	
AS
BEGIN
	UPDATE dbo.Bill SET Bill_Status = 1, Deposit = @deposit , Discount = @discount, Total = @total WHERE Bill_ID = @bill_id
	UPDATE dbo.Room SET Room_stat_ID = N'00' WHERE Room_ID = @room_id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_DashBoardChartADR]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DashBoardChartADR]
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
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo proce thêm hoá đơn--
CREATE PROC [dbo].[USP_InsertBill]
@username NVARCHAR(100), @customer_id INT , @room_id NVARCHAR (100)
AS 
BEGIN
	INSERT dbo.Bill (Date_Chekin , Date_Checkout ,  Date_Created , Deposit ,Discount , Bill_Status , Total ,UserName , Customer_ID ,Room_ID)
	VALUES  (GETDATE() , NULL, GETDATE(), 0.0 , 0.0 , 0 , 0.0 , @username , @customer_id, @room_id)
	UPDATE dbo.Room SET Room_stat_ID = N'02' WHERE Room_ID = @room_id 
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo Proce thêm chi tiết hóa đơn---
CREATE PROC [dbo].[USP_InsertBillInfo]
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
/****** Object:  StoredProcedure [dbo].[USP_InsertBooking]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo Proce thêm Booking--
CREATE PROC [dbo].[USP_InsertBooking]
@datecheckin DATETIME, @deposit FLOAT, @bookingtype NVARCHAR(100), @username NVARCHAR(100), @customerid INT , @roomid NVARCHAR(100)
AS
BEGIN
	SET @datecheckin = DATEADD(hour,12,@datecheckin)
	INSERT dbo.Booking ( Date_Book , Date_Checkin ,  Date_Checkout , Deposit , Booking_Type_ID ,  UserName ,  Customer_ID ,  Room_ID , Booking_status_id)
	VALUES  ( GETDATE() ,  @datecheckin , NULL ,  @deposit ,   @bookingtype , @username ,  @customerid , @roomid, 0  )
	UPDATE Room SET Room_stat_ID = N'01' WHERE Room_ID = @roomid
	
END

GO
/****** Object:  StoredProcedure [dbo].[USP_LoadBillList]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tạo proc load danh sách hóa đơn--
CREATE PROC [dbo].[USP_LoadBillList]
@datefromdate DATETIME , @datetodate DATETIME
AS
BEGIN
	SET @datefromdate = DATEADD(hour,00,@datefromdate)
	SET @datetodate = DATEADD(HOUR,24,@datetodate)
	SELECT * FROM Bill b , dbo.Room r 
	WHERE b.Room_ID = r.Room_ID AND b.Date_Chekin >= @datefromdate AND b.Date_Checkout <= @datetodate AND b.Bill_Status =1
END

GO
/****** Object:  StoredProcedure [dbo].[USP_LoadReport]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[USP_LoadReport]
 AS
 BEGIN
 	SELECT b.Bill_ID, r.Room_number, b.Date_Chekin,b.Date_Checkout, DATEDIFF(HOUR,b.Date_Chekin,b.Date_Checkout) AS Hour_Rent ,b.Total
	FROM Bill b JOIN dbo.Room r on b.Room_ID = r.Room_ID
	WHERE b.Bill_Status = 1
 END

 EXECUTE dbo.USP_LoadReport

GO
/****** Object:  StoredProcedure [dbo].[USP_LoadRoomList]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tạo Proce lấy danh sách phòng--
CREATE PROC [dbo].[USP_LoadRoomList]
AS SELECT * 
FROM dbo.Room r , dbo.Room_status rs , dbo.Room_Type rt 
WHERE r.Room_stat_ID = rs.Room_stat_ID AND r.Room_Type_ID = rt.Room_Type_ID

EXECUTE dbo.USP_LoadRoomList

GO
/****** Object:  StoredProcedure [dbo].[USP_LoadRoomSwitchedList]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Tạo proc lấy danh sách phòng trống ---
Create PROC [dbo].[USP_LoadRoomSwitchedList]
AS
BEGIN
	SELECT *
	FROM Room r INNER JOIN dbo.Room_Type rt ON r.Room_Type_ID = rt.Room_Type_ID , dbo.Room_status rs
	WHERE r.Room_stat_ID = N'00' AND r.Room_stat_ID = rs.Room_stat_ID
END

GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--Tạo Proce Login cho chức năng đăng nhập--
CREATE PROC	[dbo].[USP_Login]
@userName nvarchar (100) , @passWord nvarchar (100) 
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE	UserName = @userName AND password = @passWord
END

EXECUTE dbo.USP_Login @userName = N'admin', @passWord = N'1'

GO
/****** Object:  StoredProcedure [dbo].[USP_RoomTypeNameQuantityRent]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_RoomTypeNameQuantityRent]
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
/****** Object:  StoredProcedure [dbo].[USP_SwitchRoom]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tạo Proc đổi phòng--
CREATE PROC [dbo].[USP_SwitchRoom]
@roomidold NVARCHAR(100), @roomidnew nvarchar(100) ,@billID int
AS
BEGIN
	UPDATE Bill SET Room_ID = @roomidnew WHERE Bill_ID = @billID
	UPDATE Room SET Room_stat_ID = N'00' WHERE Room_ID = @roomidold
	UPDATE Room SET Room_stat_ID = N'02' WHERE Room_ID = @roomidnew
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 2/29/2020 9:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tạo Proce cập nhật thông tin tài khoản--
CREATE PROC [dbo].[USP_UpdateAccount]
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
