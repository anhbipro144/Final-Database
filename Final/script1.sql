Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'subtotal' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'total' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'vat' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'price' on entity type 'Product'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'total' on entity type 'Product_Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Persons] (
    [personId] int NOT NULL IDENTITY,
    [firstName] nvarchar(max) NOT NULL,
    [lastName] nvarchar(max) NOT NULL,
    [dateOfBirth] datetime2 NOT NULL,
    [gender] nvarchar(max) NOT NULL,
    [email] nvarchar(max) NOT NULL,
    [phone] nvarchar(max) NOT NULL,
    [address] nvarchar(max) NOT NULL,
    [status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([personId])
);
GO

CREATE TABLE [Product] (
    [productId] int NOT NULL IDENTITY,
    [productName] nvarchar(max) NULL,
    [categoryId] int NOT NULL,
    [price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([productId])
);
GO

CREATE TABLE [RetailChains] (
    [retailId] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_RetailChains] PRIMARY KEY ([retailId])
);
GO

CREATE TABLE [Suppliers] (
    [supplierId] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([supplierId])
);
GO

CREATE TABLE [Customers] (
    [customerId] int NOT NULL IDENTITY,
    [personId] int NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([customerId]),
    CONSTRAINT [FK_Customers_Persons_personId] FOREIGN KEY ([personId]) REFERENCES [Persons] ([personId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [orderId] int NOT NULL IDENTITY,
    [personId] int NOT NULL,
    [createdAt] datetime2 NOT NULL,
    [vat] decimal(18,2) NOT NULL,
    [subtotal] decimal(18,2) NOT NULL,
    [total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([orderId]),
    CONSTRAINT [FK_Orders_Persons_personId] FOREIGN KEY ([personId]) REFERENCES [Persons] ([personId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Staffs] (
    [staffId] int NOT NULL IDENTITY,
    [personId] int NOT NULL,
    CONSTRAINT [PK_Staffs] PRIMARY KEY ([staffId]),
    CONSTRAINT [FK_Staffs_Persons_personId] FOREIGN KEY ([personId]) REFERENCES [Persons] ([personId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Inventories] (
    [inventoryId] int NOT NULL IDENTITY,
    [productId] int NOT NULL,
    [retailId] int NOT NULL,
    [available] int NULL,
    [lastUpdated] datetime2 NULL,
    CONSTRAINT [PK_Inventories] PRIMARY KEY ([inventoryId]),
    CONSTRAINT [FK_Inventories_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Supplyings] (
    [supplyingId] int NOT NULL IDENTITY,
    [supplierId] int NOT NULL,
    [productId] int NOT NULL,
    [amount] int NOT NULL,
    [orderedAt] datetime2 NOT NULL,
    [arrivedAt] datetime2 NOT NULL,
    [hasArrived] bit NOT NULL,
    CONSTRAINT [PK_Supplyings] PRIMARY KEY ([supplyingId]),
    CONSTRAINT [FK_Supplyings_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Supplyings_Suppliers_supplierId] FOREIGN KEY ([supplierId]) REFERENCES [Suppliers] ([supplierId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Product_Orders] (
    [orderId] int NOT NULL,
    [productId] int NOT NULL,
    [quantity] int NOT NULL,
    [total] decimal(18,2) NOT NULL,
    [countingUnit] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Product_Orders] PRIMARY KEY ([orderId], [productId]),
    CONSTRAINT [FK_Product_Orders_Orders_orderId] FOREIGN KEY ([orderId]) REFERENCES [Orders] ([orderId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Product_Orders_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Refunds] (
    [refundId] int NOT NULL IDENTITY,
    [orderId] int NOT NULL,
    [productId] int NOT NULL,
    [createdAt] datetime2 NOT NULL,
    [reason] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Refunds] PRIMARY KEY ([refundId]),
    CONSTRAINT [FK_Refunds_Orders_orderId] FOREIGN KEY ([orderId]) REFERENCES [Orders] ([orderId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Refunds_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE CASCADE
);
GO

CREATE TABLE [EmployedAts] (
    [retailId] int NOT NULL,
    [staffId] int NOT NULL,
    [RetailChainretailId] int NULL,
    [role] nvarchar(max) NOT NULL,
    [employedSince] datetime2 NOT NULL,
    CONSTRAINT [PK_EmployedAts] PRIMARY KEY ([staffId], [retailId]),
    CONSTRAINT [FK_EmployedAts_RetailChains_RetailChainretailId] FOREIGN KEY ([RetailChainretailId]) REFERENCES [RetailChains] ([retailId]),
    CONSTRAINT [FK_EmployedAts_Staffs_staffId] FOREIGN KEY ([staffId]) REFERENCES [Staffs] ([staffId]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'personId', N'address', N'dateOfBirth', N'email', N'firstName', N'gender', N'lastName', N'phone', N'status') AND [object_id] = OBJECT_ID(N'[Persons]'))
    SET IDENTITY_INSERT [Persons] ON;
INSERT INTO [Persons] ([personId], [address], [dateOfBirth], [email], [firstName], [gender], [lastName], [phone], [status])
VALUES (1, N'312, Lac Long Quan', '2022-12-27T20:30:22.4203248+07:00', N'nbi2271@gmail.com', N'Neo', N'Male', N'Nguyen', N'0944565607', N'single'),
(2, N'262, Lac Long Quan', '2022-12-27T20:30:22.4203251+07:00', N'nbi6731@gmail.com', N'Lanh', N'Male', N'Nguyen', N'0911967483', N'single'),
(3, N'458, Nguyen Huu Tho', '2022-12-27T20:30:22.4203253+07:00', N'nbi9922@gmail.com', N'Bi', N'Male', N'Nguyen', N'0817559294', N'single');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'personId', N'address', N'dateOfBirth', N'email', N'firstName', N'gender', N'lastName', N'phone', N'status') AND [object_id] = OBJECT_ID(N'[Persons]'))
    SET IDENTITY_INSERT [Persons] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'productId', N'categoryId', N'price', N'productName') AND [object_id] = OBJECT_ID(N'[Product]'))
    SET IDENTITY_INSERT [Product] ON;
INSERT INTO [Product] ([productId], [categoryId], [price], [productName])
VALUES (1, 1, 20.0, N'lamboghini'),
(2, 2, 30.0, N'ferrari'),
(3, 3, 40.0, N'lamboghini');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'productId', N'categoryId', N'price', N'productName') AND [object_id] = OBJECT_ID(N'[Product]'))
    SET IDENTITY_INSERT [Product] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'retailId', N'address', N'name') AND [object_id] = OBJECT_ID(N'[RetailChains]'))
    SET IDENTITY_INSERT [RetailChains] ON;
INSERT INTO [RetailChains] ([retailId], [address], [name])
VALUES (1, N'156, Duong 3/2', N'Retail1'),
(2, N'326, Nguyen Tri Phuong', N'Retail2'),
(3, N'221, Hoa Hao', N'Retail3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'retailId', N'address', N'name') AND [object_id] = OBJECT_ID(N'[RetailChains]'))
    SET IDENTITY_INSERT [RetailChains] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'supplierId', N'name') AND [object_id] = OBJECT_ID(N'[Suppliers]'))
    SET IDENTITY_INSERT [Suppliers] ON;
INSERT INTO [Suppliers] ([supplierId], [name])
VALUES (1, N'Supplier1'),
(2, N'Supplier2'),
(3, N'Supplier3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'supplierId', N'name') AND [object_id] = OBJECT_ID(N'[Suppliers]'))
    SET IDENTITY_INSERT [Suppliers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'customerId', N'personId') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] ON;
INSERT INTO [Customers] ([customerId], [personId])
VALUES (1, 1),
(2, 2),
(3, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'customerId', N'personId') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'inventoryId', N'available', N'lastUpdated', N'productId', N'retailId') AND [object_id] = OBJECT_ID(N'[Inventories]'))
    SET IDENTITY_INSERT [Inventories] ON;
INSERT INTO [Inventories] ([inventoryId], [available], [lastUpdated], [productId], [retailId])
VALUES (1, 500, NULL, 1, 1),
(2, 500, NULL, 2, 2),
(3, 500, NULL, 3, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'inventoryId', N'available', N'lastUpdated', N'productId', N'retailId') AND [object_id] = OBJECT_ID(N'[Inventories]'))
    SET IDENTITY_INSERT [Inventories] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'orderId', N'createdAt', N'personId', N'subtotal', N'total', N'vat') AND [object_id] = OBJECT_ID(N'[Orders]'))
    SET IDENTITY_INSERT [Orders] ON;
INSERT INTO [Orders] ([orderId], [createdAt], [personId], [subtotal], [total], [vat])
VALUES (1, '2022-12-27T20:30:22.4203209+07:00', 1, 200.0, 220.0, 20.0),
(2, '2022-12-27T20:30:22.4203214+07:00', 2, 300.0, 330.0, 30.0),
(3, '2022-12-27T20:30:22.4203215+07:00', 3, 400.0, 440.0, 40.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'orderId', N'createdAt', N'personId', N'subtotal', N'total', N'vat') AND [object_id] = OBJECT_ID(N'[Orders]'))
    SET IDENTITY_INSERT [Orders] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'staffId', N'personId') AND [object_id] = OBJECT_ID(N'[Staffs]'))
    SET IDENTITY_INSERT [Staffs] ON;
INSERT INTO [Staffs] ([staffId], [personId])
VALUES (1, 1),
(2, 2),
(3, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'staffId', N'personId') AND [object_id] = OBJECT_ID(N'[Staffs]'))
    SET IDENTITY_INSERT [Staffs] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'supplyingId', N'amount', N'arrivedAt', N'hasArrived', N'orderedAt', N'productId', N'supplierId') AND [object_id] = OBJECT_ID(N'[Supplyings]'))
    SET IDENTITY_INSERT [Supplyings] ON;
INSERT INTO [Supplyings] ([supplyingId], [amount], [arrivedAt], [hasArrived], [orderedAt], [productId], [supplierId])
VALUES (1, 10, '2022-12-27T20:30:22.4203311+07:00', CAST(0 AS bit), '2022-12-27T20:30:22.4203312+07:00', 1, 1),
(2, 20, '2022-12-27T20:30:22.4203313+07:00', CAST(1 AS bit), '2022-12-27T20:30:22.4203314+07:00', 2, 2),
(3, 30, '2022-12-27T20:30:22.4203315+07:00', CAST(0 AS bit), '2022-12-27T20:30:22.4203316+07:00', 3, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'supplyingId', N'amount', N'arrivedAt', N'hasArrived', N'orderedAt', N'productId', N'supplierId') AND [object_id] = OBJECT_ID(N'[Supplyings]'))
    SET IDENTITY_INSERT [Supplyings] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'retailId', N'staffId', N'RetailChainretailId', N'employedSince', N'role') AND [object_id] = OBJECT_ID(N'[EmployedAts]'))
    SET IDENTITY_INSERT [EmployedAts] ON;
INSERT INTO [EmployedAts] ([retailId], [staffId], [RetailChainretailId], [employedSince], [role])
VALUES (1, 1, NULL, '2022-12-27T20:30:22.4203187+07:00', N'Manager'),
(2, 2, NULL, '2022-12-27T20:30:22.4203197+07:00', N'Staff'),
(3, 3, NULL, '2022-12-27T20:30:22.4203198+07:00', N'Cashier');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'retailId', N'staffId', N'RetailChainretailId', N'employedSince', N'role') AND [object_id] = OBJECT_ID(N'[EmployedAts]'))
    SET IDENTITY_INSERT [EmployedAts] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'orderId', N'productId', N'countingUnit', N'quantity', N'total') AND [object_id] = OBJECT_ID(N'[Product_Orders]'))
    SET IDENTITY_INSERT [Product_Orders] ON;
INSERT INTO [Product_Orders] ([orderId], [productId], [countingUnit], [quantity], [total])
VALUES (1, 1, N'chiec', 10, 100.0),
(2, 2, N'chiec', 20, 200.0),
(3, 3, N'chiec', 30, 300.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'orderId', N'productId', N'countingUnit', N'quantity', N'total') AND [object_id] = OBJECT_ID(N'[Product_Orders]'))
    SET IDENTITY_INSERT [Product_Orders] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'refundId', N'createdAt', N'orderId', N'productId', N'reason') AND [object_id] = OBJECT_ID(N'[Refunds]'))
    SET IDENTITY_INSERT [Refunds] ON;
INSERT INTO [Refunds] ([refundId], [createdAt], [orderId], [productId], [reason])
VALUES (1, '2022-12-27T20:30:22.4203281+07:00', 1, 1, N'Tai t thich'),
(2, '2022-12-27T20:30:22.4203283+07:00', 2, 2, N'Tai t thich duoc k?'),
(3, '2022-12-27T20:30:22.4203284+07:00', 3, 3, N'Tai t lai thich');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'refundId', N'createdAt', N'orderId', N'productId', N'reason') AND [object_id] = OBJECT_ID(N'[Refunds]'))
    SET IDENTITY_INSERT [Refunds] OFF;
GO

CREATE INDEX [IX_Customers_personId] ON [Customers] ([personId]);
GO

CREATE INDEX [IX_EmployedAts_RetailChainretailId] ON [EmployedAts] ([RetailChainretailId]);
GO

CREATE INDEX [IX_Inventories_productId] ON [Inventories] ([productId]);
GO

CREATE INDEX [IX_Orders_personId] ON [Orders] ([personId]);
GO

CREATE INDEX [IX_Product_Orders_productId] ON [Product_Orders] ([productId]);
GO

CREATE INDEX [IX_Refunds_orderId] ON [Refunds] ([orderId]);
GO

CREATE INDEX [IX_Refunds_productId] ON [Refunds] ([productId]);
GO

CREATE INDEX [IX_Staffs_personId] ON [Staffs] ([personId]);
GO

CREATE INDEX [IX_Supplyings_productId] ON [Supplyings] ([productId]);
GO

CREATE INDEX [IX_Supplyings_supplierId] ON [Supplyings] ([supplierId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221227133022_init', N'7.0.1');
GO

COMMIT;
GO


