USE [Final.Data]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerId] [int] IDENTITY(1,1) NOT NULL,
	[personId] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployedAts]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployedAts](
	[retailId] [int] NOT NULL,
	[staffId] [int] NOT NULL,
	[RetailChainretailId] [int] NULL,
	[role] [nvarchar](max) NOT NULL,
	[employedSince] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EmployedAts] PRIMARY KEY CLUSTERED 
(
	[staffId] ASC,
	[retailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[inventoryId] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[retailId] [int] NOT NULL,
	[quantity] [int] NULL,
	[lastUpdated] [datetime2](7) NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[inventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[personId] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[vat] [decimal](18, 2) NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[personId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](max) NOT NULL,
	[lastName] [nvarchar](max) NOT NULL,
	[dateOfBirth] [datetime2](7) NOT NULL,
	[gender] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[phone] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](max) NULL,
	[categoryId] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Orders]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Orders](
	[orderId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
	[countingUnit] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Product_Orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC,
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Refunds]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Refunds](
	[refundId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[reason] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Refunds] PRIMARY KEY CLUSTERED 
(
	[refundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RetailChains]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RetailChains](
	[retailId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RetailChains] PRIMARY KEY CLUSTERED 
(
	[retailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[staffId] [int] IDENTITY(1,1) NOT NULL,
	[personId] [int] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[supplierId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[supplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplyings]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplyings](
	[supplyingId] [int] IDENTITY(1,1) NOT NULL,
	[supplierId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[orderedAt] [datetime2](7) NOT NULL,
	[arrivedAt] [datetime2](7) NOT NULL,
	[hasArrived] [bit] NOT NULL,
 CONSTRAINT [PK_Supplyings] PRIMARY KEY CLUSTERED 
(
	[supplyingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Persons_personId] FOREIGN KEY([personId])
REFERENCES [dbo].[Persons] ([personId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Persons_personId]
GO
ALTER TABLE [dbo].[EmployedAts]  WITH CHECK ADD  CONSTRAINT [FK_EmployedAts_RetailChains_RetailChainretailId] FOREIGN KEY([RetailChainretailId])
REFERENCES [dbo].[RetailChains] ([retailId])
GO
ALTER TABLE [dbo].[EmployedAts] CHECK CONSTRAINT [FK_EmployedAts_RetailChains_RetailChainretailId]
GO
ALTER TABLE [dbo].[EmployedAts]  WITH CHECK ADD  CONSTRAINT [FK_EmployedAts_Staffs_staffId] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staffs] ([staffId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployedAts] CHECK CONSTRAINT [FK_EmployedAts_Staffs_staffId]
GO
ALTER TABLE [dbo].[Inventories]  WITH CHECK ADD  CONSTRAINT [FK_Inventories_Product_productId] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([productId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventories] CHECK CONSTRAINT [FK_Inventories_Product_productId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Persons_personId] FOREIGN KEY([personId])
REFERENCES [dbo].[Persons] ([personId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Persons_personId]
GO
ALTER TABLE [dbo].[Product_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Product_Orders_Orders_orderId] FOREIGN KEY([orderId])
REFERENCES [dbo].[Orders] ([orderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Orders] CHECK CONSTRAINT [FK_Product_Orders_Orders_orderId]
GO
ALTER TABLE [dbo].[Product_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Product_Orders_Product_productId] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([productId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Orders] CHECK CONSTRAINT [FK_Product_Orders_Product_productId]
GO
ALTER TABLE [dbo].[Refunds]  WITH CHECK ADD  CONSTRAINT [FK_Refunds_Orders_orderId] FOREIGN KEY([orderId])
REFERENCES [dbo].[Orders] ([orderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Refunds] CHECK CONSTRAINT [FK_Refunds_Orders_orderId]
GO
ALTER TABLE [dbo].[Refunds]  WITH CHECK ADD  CONSTRAINT [FK_Refunds_Product_productId] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([productId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Refunds] CHECK CONSTRAINT [FK_Refunds_Product_productId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Persons_personId] FOREIGN KEY([personId])
REFERENCES [dbo].[Persons] ([personId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Persons_personId]
GO
ALTER TABLE [dbo].[Supplyings]  WITH CHECK ADD  CONSTRAINT [FK_Supplyings_Product_productId] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([productId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supplyings] CHECK CONSTRAINT [FK_Supplyings_Product_productId]
GO
ALTER TABLE [dbo].[Supplyings]  WITH CHECK ADD  CONSTRAINT [FK_Supplyings_Suppliers_supplierId] FOREIGN KEY([supplierId])
REFERENCES [dbo].[Suppliers] ([supplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supplyings] CHECK CONSTRAINT [FK_Supplyings_Suppliers_supplierId]
GO
/****** Object:  Trigger [dbo].[DeleteOrder]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
Create TRIGGER [dbo].[DeleteOrder]
   ON  [dbo].[Product_Orders] 
   FOR DELETE
AS 
BEGIN

DECLARE @quantity int;
declare @orderIdDeleted int;
	
	Set @quantity = (select quantity  from deleted d, Orders o where d.orderId = o.orderId )
	set @orderIdDeleted = (select orderId from deleted)
	
   UPDATE Inventories 
   SET quantity = iv.quantity + @quantity from Inventories iv, deleted d where iv.productId  = d.productId 

   delete from Orders where orderId = @orderIdDeleted
   END
GO
ALTER TABLE [dbo].[Product_Orders] ENABLE TRIGGER [DeleteOrder]
GO
/****** Object:  Trigger [dbo].[InsertOrder]    Script Date: 12/27/2022 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================

GO
ALTER TABLE [dbo].[Product_Orders] ENABLE TRIGGER [InsertOrder]
GO
/****** Object:  Trigger [dbo].[UpdateOrder]    Script Date: 12/27/2022 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE TRIGGER [dbo].[UpdateOrder]
   ON  [dbo].[Product_Orders] 
   FOR Update
AS 
BEGIN

DECLARE @newquantity int;
DECLARE @oldquantity int;
DECLARE @curquantity int;


	Set @newquantity = (select quantity  from inserted)
	Set @oldquantity = (select quantity  from deleted)
	Set @curquantity = (select iv.quantity  from inserted i , Inventories iv where iv.productId = i.productId)


   IF (@newquantity > @curquantity)

	begin
		
	print('Not enough stock!')
	UPDATE Product_Orders 
   SET quantity = @oldquantity where orderId = (select orderId from inserted)
	return
	end
   UPDATE Inventories 
   SET quantity = iv.quantity - @newquantity from Inventories iv, inserted i where iv.productId  = i.productId
   UPDATE Inventories 
   SET quantity = iv.quantity + @oldquantity from Inventories iv, deleted d where iv.productId  = d.productId
  

END
GO
ALTER TABLE [dbo].[Product_Orders] ENABLE TRIGGER [UpdateOrder]
GO
