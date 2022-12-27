Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[10625]
      The foreign key property 'Inventory.productId1' was created in shadow state because a conflicting property with the simple name 'productId' exists in the entity type, but is either not mapped, is already used for another relationship, or is incompatible with the associated primary key type. See https://aka.ms/efcore-relationships for information on mapping relationships in EF Core.
warn: Microsoft.EntityFrameworkCore.Model.Validation[10625]
      The foreign key property 'Product_Order.productId1' was created in shadow state because a conflicting property with the simple name 'productId' exists in the entity type, but is either not mapped, is already used for another relationship, or is incompatible with the associated primary key type. See https://aka.ms/efcore-relationships for information on mapping relationships in EF Core.
warn: Microsoft.EntityFrameworkCore.Model.Validation[10625]
      The foreign key property 'Refund.productId1' was created in shadow state because a conflicting property with the simple name 'productId' exists in the entity type, but is either not mapped, is already used for another relationship, or is incompatible with the associated primary key type. See https://aka.ms/efcore-relationships for information on mapping relationships in EF Core.
warn: Microsoft.EntityFrameworkCore.Model.Validation[10625]
      The foreign key property 'Supplying.productId1' was created in shadow state because a conflicting property with the simple name 'productId' exists in the entity type, but is either not mapped, is already used for another relationship, or is incompatible with the associated primary key type. See https://aka.ms/efcore-relationships for information on mapping relationships in EF Core.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'subtotal' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'total' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'vat' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
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

CREATE TABLE [Product] (
    [productId] nvarchar(450) NOT NULL,
    [productName] nvarchar(max) NULL,
    [categoryId] nvarchar(max) NULL,
    [price] nvarchar(max) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([productId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221226121025_init', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221226160346_User', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [personId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221226161321_User2', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [EmployedAts] (
    [Id] int NOT NULL IDENTITY,
    [retailId] int NULL,
    [employeeId] int NULL,
    [role] nvarchar(max) NULL,
    [employedSince] datetime2 NULL,
    CONSTRAINT [PK_EmployedAts] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Inventories] (
    [Id] int NOT NULL IDENTITY,
    [productId] int NULL,
    [retailId] int NULL,
    [quantity] int NULL,
    [lastUpdated] datetime2 NULL,
    CONSTRAINT [PK_Inventories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [customerId] int NULL,
    [createdAt] datetime2 NULL,
    [vat] decimal(18,2) NULL,
    [subtotal] decimal(18,2) NULL,
    [total] decimal(18,2) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Persons] (
    [Id] int NOT NULL IDENTITY,
    [firstName] nvarchar(max) NULL,
    [lastName] nvarchar(max) NULL,
    [dateOfBirth] datetime2 NULL,
    [gender] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    [address] nvarchar(max) NULL,
    [status] nvarchar(max) NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Product_Orders] (
    [Id] int NOT NULL IDENTITY,
    [orderId] int NULL,
    [productId] int NULL,
    [quantity] int NULL,
    [total] decimal(18,2) NULL,
    [countingUnit] nvarchar(max) NULL,
    CONSTRAINT [PK_Product_Orders] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Refunds] (
    [Id] int NOT NULL IDENTITY,
    [orderId] int NULL,
    [productId] int NULL,
    [createdAt] datetime2 NULL,
    [reason] nvarchar(max) NULL,
    CONSTRAINT [PK_Refunds] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RetailChains] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [address] nvarchar(max) NULL,
    CONSTRAINT [PK_RetailChains] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Staffs] (
    [Id] int NOT NULL IDENTITY,
    [personId] int NULL,
    [position] nvarchar(max) NULL,
    CONSTRAINT [PK_Staffs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Suppliers] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Supplyings] (
    [Id] int NOT NULL IDENTITY,
    [supplierId] int NULL,
    [productId] int NULL,
    [amount] int NOT NULL,
    [orderedAt] datetime2 NULL,
    [arrivedAt] datetime2 NULL,
    [hasArrived] bit NULL,
    CONSTRAINT [PK_Supplyings] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221227022848_Models', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [Users];
GO

ALTER TABLE [Product_Orders] DROP CONSTRAINT [PK_Product_Orders];
GO

ALTER TABLE [EmployedAts] DROP CONSTRAINT [PK_EmployedAts];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product_Orders]') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Product_Orders] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Product_Orders] DROP COLUMN [Id];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployedAts]') AND [c].[name] = N'Id');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [EmployedAts] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [EmployedAts] DROP COLUMN [Id];
GO

EXEC sp_rename N'[Supplyings].[Id]', N'supplyingId', N'COLUMN';
GO

EXEC sp_rename N'[Suppliers].[Id]', N'supplierId', N'COLUMN';
GO

EXEC sp_rename N'[Staffs].[Id]', N'staffId', N'COLUMN';
GO

EXEC sp_rename N'[RetailChains].[Id]', N'retailId', N'COLUMN';
GO

EXEC sp_rename N'[Refunds].[Id]', N'refundId', N'COLUMN';
GO

EXEC sp_rename N'[Persons].[Id]', N'personId', N'COLUMN';
GO

EXEC sp_rename N'[Orders].[customerId]', N'personId', N'COLUMN';
GO

EXEC sp_rename N'[Orders].[Id]', N'orderId', N'COLUMN';
GO

EXEC sp_rename N'[Inventories].[Id]', N'inventoryId', N'COLUMN';
GO

EXEC sp_rename N'[EmployedAts].[employeeId]', N'staffId', N'COLUMN';
GO

ALTER TABLE [Supplyings] ADD [productId1] nvarchar(450) NULL;
GO

ALTER TABLE [Refunds] ADD [productId1] nvarchar(450) NULL;
GO

ALTER TABLE [Product_Orders] ADD [productId1] nvarchar(450) NULL;
GO

ALTER TABLE [Inventories] ADD [RetailChainretailId] int NULL;
GO

ALTER TABLE [Inventories] ADD [productId1] nvarchar(450) NULL;
GO

ALTER TABLE [EmployedAts] ADD [RetailChainretailId] int NULL;
GO

CREATE TABLE [Customers] (
    [customerId] int NOT NULL IDENTITY,
    [personId] int NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([customerId]),
    CONSTRAINT [FK_Customers_Persons_personId] FOREIGN KEY ([personId]) REFERENCES [Persons] ([personId])
);
GO

CREATE INDEX [IX_Supplyings_productId1] ON [Supplyings] ([productId1]);
GO

CREATE INDEX [IX_Supplyings_supplierId] ON [Supplyings] ([supplierId]);
GO

CREATE INDEX [IX_Staffs_personId] ON [Staffs] ([personId]);
GO

CREATE INDEX [IX_Refunds_orderId] ON [Refunds] ([orderId]);
GO

CREATE INDEX [IX_Refunds_productId1] ON [Refunds] ([productId1]);
GO

CREATE INDEX [IX_Product_Orders_orderId] ON [Product_Orders] ([orderId]);
GO

CREATE INDEX [IX_Product_Orders_productId1] ON [Product_Orders] ([productId1]);
GO

CREATE INDEX [IX_Orders_personId] ON [Orders] ([personId]);
GO

CREATE INDEX [IX_Inventories_productId1] ON [Inventories] ([productId1]);
GO

CREATE INDEX [IX_Inventories_RetailChainretailId] ON [Inventories] ([RetailChainretailId]);
GO

CREATE INDEX [IX_EmployedAts_RetailChainretailId] ON [EmployedAts] ([RetailChainretailId]);
GO

CREATE INDEX [IX_EmployedAts_staffId] ON [EmployedAts] ([staffId]);
GO

CREATE INDEX [IX_Customers_personId] ON [Customers] ([personId]);
GO

ALTER TABLE [EmployedAts] ADD CONSTRAINT [FK_EmployedAts_RetailChains_RetailChainretailId] FOREIGN KEY ([RetailChainretailId]) REFERENCES [RetailChains] ([retailId]);
GO

ALTER TABLE [EmployedAts] ADD CONSTRAINT [FK_EmployedAts_Staffs_staffId] FOREIGN KEY ([staffId]) REFERENCES [Staffs] ([staffId]);
GO

ALTER TABLE [Inventories] ADD CONSTRAINT [FK_Inventories_Product_productId1] FOREIGN KEY ([productId1]) REFERENCES [Product] ([productId]);
GO

ALTER TABLE [Inventories] ADD CONSTRAINT [FK_Inventories_RetailChains_RetailChainretailId] FOREIGN KEY ([RetailChainretailId]) REFERENCES [RetailChains] ([retailId]);
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Persons_personId] FOREIGN KEY ([personId]) REFERENCES [Persons] ([personId]);
GO

ALTER TABLE [Product_Orders] ADD CONSTRAINT [FK_Product_Orders_Orders_orderId] FOREIGN KEY ([orderId]) REFERENCES [Orders] ([orderId]);
GO

ALTER TABLE [Product_Orders] ADD CONSTRAINT [FK_Product_Orders_Product_productId1] FOREIGN KEY ([productId1]) REFERENCES [Product] ([productId]);
GO

ALTER TABLE [Refunds] ADD CONSTRAINT [FK_Refunds_Orders_orderId] FOREIGN KEY ([orderId]) REFERENCES [Orders] ([orderId]);
GO

ALTER TABLE [Refunds] ADD CONSTRAINT [FK_Refunds_Product_productId1] FOREIGN KEY ([productId1]) REFERENCES [Product] ([productId]);
GO

ALTER TABLE [Staffs] ADD CONSTRAINT [FK_Staffs_Persons_personId] FOREIGN KEY ([personId]) REFERENCES [Persons] ([personId]);
GO

ALTER TABLE [Supplyings] ADD CONSTRAINT [FK_Supplyings_Product_productId1] FOREIGN KEY ([productId1]) REFERENCES [Product] ([productId]);
GO

ALTER TABLE [Supplyings] ADD CONSTRAINT [FK_Supplyings_Suppliers_supplierId] FOREIGN KEY ([supplierId]) REFERENCES [Suppliers] ([supplierId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221227032718_Models2', N'7.0.1');
GO

COMMIT;
GO


