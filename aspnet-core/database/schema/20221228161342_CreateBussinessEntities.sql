BEGIN TRANSACTION;
GO

CREATE TABLE [AppInventoryTickets] (
    [Id] uniqueidentifier NOT NULL,
    [Code] varchar(50) NOT NULL,
    [TicketType] int NOT NULL,
    [IsApproved] bit NOT NULL,
    [ApproverId] uniqueidentifier NULL,
    [ApprovedDate] datetime2 NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppInventoryTickets] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppManufacturer] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Code] varchar(50) NOT NULL,
    [Slug] varchar(50) NOT NULL,
    [CoverPicture] nvarchar(250) NULL,
    [Visibility] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [Country] nvarchar(max) NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppManufacturer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppOrders] (
    [Id] uniqueidentifier NOT NULL,
    [Code] varchar(50) NOT NULL,
    [Status] int NOT NULL,
    [PaymentMethod] int NOT NULL,
    [ShippingFee] float NOT NULL,
    [Tax] float NOT NULL,
    [Total] float NOT NULL,
    [Subtotal] float NOT NULL,
    [Discount] float NOT NULL,
    [GrandTotal] float NOT NULL,
    [CustomerName] nvarchar(50) NOT NULL,
    [CustomerPhoneNumber] nvarchar(50) NOT NULL,
    [CustomerAddress] nvarchar(250) NOT NULL,
    [CustomerUserId] uniqueidentifier NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [DeleterId] uniqueidentifier NULL,
    [DeletionTime] datetime2 NULL,
    CONSTRAINT [PK_AppOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AppOrders_AbpUsers_CustomerUserId] FOREIGN KEY ([CustomerUserId]) REFERENCES [AbpUsers] ([Id])
);
GO

CREATE TABLE [AppProductAttributes] (
    [Id] uniqueidentifier NOT NULL,
    [Code] varchar(50) NOT NULL,
    [DataType] int NOT NULL,
    [Label] nvarchar(50) NOT NULL,
    [SortOrder] int NOT NULL,
    [Visibility] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [IsRequired] bit NOT NULL,
    [IsUnique] bit NOT NULL,
    [Note] nvarchar(max) NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppProductAttributes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppProductCategories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Code] varchar(50) NOT NULL,
    [Slug] varchar(50) NOT NULL,
    [SortOrder] int NOT NULL,
    [CoverPicture] nvarchar(250) NULL,
    [Visibility] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [ParentId] uniqueidentifier NULL,
    [SeoMetaDescription] nvarchar(250) NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppProductCategories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppPromotions] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [CouponCode] varchar(50) NOT NULL,
    [RequireUseCouponCode] bit NOT NULL,
    [ValidDate] datetime2 NOT NULL,
    [ExpiredDate] datetime2 NULL,
    [DiscountAmount] float NOT NULL,
    [DiscountUnit] int NOT NULL,
    [LimitedUsageTimes] bit NOT NULL,
    [MaximumDiscountAmount] bigint NOT NULL,
    [IsActive] bit NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppPromotions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppTags] (
    [Id] nvarchar(50) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_AppTags] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppInventoryTicketItems] (
    [Id] uniqueidentifier NOT NULL,
    [TicketId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [SKU] varchar(50) NOT NULL,
    [Quantity] int NOT NULL,
    [BatchNumber] varchar(50) NULL,
    [ExpiredDate] datetime2 NULL,
    CONSTRAINT [PK_AppInventoryTicketItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InventoryTicketItem_InventoryTicket] FOREIGN KEY ([TicketId]) REFERENCES [AppInventoryTickets] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppOrderTransactions] (
    [Id] uniqueidentifier NOT NULL,
    [Code] varchar(50) NOT NULL,
    [OrderId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NULL,
    [TransactionType] int NOT NULL,
    [Note] nvarchar(max) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppOrderTransactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AppOrderTransactions_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]),
    CONSTRAINT [FK_OrderTransaction_Order] FOREIGN KEY ([OrderId]) REFERENCES [AppOrders] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProducts] (
    [Id] uniqueidentifier NOT NULL,
    [ManufacturerId] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Code] varchar(50) NOT NULL,
    [Description] nvarchar(max) NULL,
    [ProductType] int NOT NULL,
    [SKU] varchar(50) NOT NULL,
    [Slug] varchar(50) NOT NULL,
    [SortOrder] int NOT NULL,
    [Visibility] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [SeoMetaDescription] nvarchar(250) NULL,
    [ThumbnailPicture] nvarchar(250) NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppProducts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY ([ManufacturerId]) REFERENCES [AppManufacturer] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [AppProductCategories] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppPromotionCategories] (
    [Id] uniqueidentifier NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [PromotionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppPromotionCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PromotionCategory_Promotion] FOREIGN KEY ([PromotionId]) REFERENCES [AppPromotions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppPromotionManufacturers] (
    [Id] uniqueidentifier NOT NULL,
    [ManufactureId] uniqueidentifier NOT NULL,
    [PromotionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppPromotionManufacturers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PromotionManufacturer_Promotion] FOREIGN KEY ([PromotionId]) REFERENCES [AppPromotions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppPromotionProducts] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [PromotionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppPromotionProducts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PromotionProduct_Promotion] FOREIGN KEY ([PromotionId]) REFERENCES [AppPromotions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppPromotionUsageHistories] (
    [Id] uniqueidentifier NOT NULL,
    [PromotionId] uniqueidentifier NOT NULL,
    [OrderId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppPromotionUsageHistories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PromotionUsageHistory_Promotion] FOREIGN KEY ([PromotionId]) REFERENCES [AppPromotions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppInventories] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [SKU] varchar(50) NOT NULL,
    [StockQuantity] int NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppInventories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Inventory_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppOrderItems] (
    [OrderId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [SKU] varchar(50) NOT NULL,
    [Quantity] int NOT NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_AppOrderItems] PRIMARY KEY ([ProductId], [OrderId]),
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [AppOrders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductAttributeDateTimes] (
    [Id] uniqueidentifier NOT NULL,
    [AttributeId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Value] datetime2 NOT NULL,
    CONSTRAINT [PK_AppProductAttributeDateTimes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductAttributeDateTime_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAttributeDateTime_ProductAttribute] FOREIGN KEY ([AttributeId]) REFERENCES [AppProductAttributes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductAttributeDecimals] (
    [Id] uniqueidentifier NOT NULL,
    [AttributeId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Value] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_AppProductAttributeDecimals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductAttributeDecimal_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAttributeDecimal_ProductAttribute] FOREIGN KEY ([AttributeId]) REFERENCES [AppProductAttributes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductAttributeInts] (
    [Id] uniqueidentifier NOT NULL,
    [AttributeId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Value] int NOT NULL,
    CONSTRAINT [PK_AppProductAttributeInts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductAttributeInt_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAttributeInt_ProductAttribute] FOREIGN KEY ([AttributeId]) REFERENCES [AppProductAttributes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductAttributeTexts] (
    [Id] uniqueidentifier NOT NULL,
    [AttributeId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Value] nvarchar(500) NULL,
    CONSTRAINT [PK_AppProductAttributeTexts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductAttributeText_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAttributeText_ProductAttribute] FOREIGN KEY ([AttributeId]) REFERENCES [AppProductAttributes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductAttributeVarchars] (
    [Id] uniqueidentifier NOT NULL,
    [AttributeId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Value] nvarchar(500) NULL,
    CONSTRAINT [PK_AppProductAttributeVarchars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductAttributeVarchar_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAttributeVarchar_ProductAttribute] FOREIGN KEY ([AttributeId]) REFERENCES [AppProductAttributes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductLinks] (
    [ProductId] uniqueidentifier NOT NULL,
    [LinkedProductId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppProductLinks] PRIMARY KEY ([ProductId], [LinkedProductId]),
    CONSTRAINT [FK_ProductLink_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AppProductReviews] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [ParentId] uniqueidentifier NULL,
    [Title] nvarchar(250) NOT NULL,
    [Rating] float NOT NULL,
    [PublishedDate] datetime2 NULL,
    [Content] nvarchar(max) NULL,
    [OrderId] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AppProductReviews] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductReview_Order] FOREIGN KEY ([OrderId]) REFERENCES [AppOrders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductReview_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductReview_ProductReview] FOREIGN KEY ([ParentId]) REFERENCES [AppProductReviews] ([Id])
);
GO

CREATE TABLE [AppProductTags] (
    [ProductId] uniqueidentifier NOT NULL,
    [TagId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_AppProductTags] PRIMARY KEY ([ProductId], [TagId]),
    CONSTRAINT [FK_ProductTag_Product] FOREIGN KEY ([ProductId]) REFERENCES [AppProducts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [AppTags] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AppInventories_ProductId] ON [AppInventories] ([ProductId]);
GO

CREATE INDEX [IX_AppInventoryTicketItems_TicketId] ON [AppInventoryTicketItems] ([TicketId]);
GO

CREATE INDEX [IX_AppOrderItems_OrderId] ON [AppOrderItems] ([OrderId]);
GO

CREATE INDEX [IX_AppOrders_CustomerUserId] ON [AppOrders] ([CustomerUserId]);
GO

CREATE INDEX [IX_AppOrderTransactions_OrderId] ON [AppOrderTransactions] ([OrderId]);
GO

CREATE INDEX [IX_AppOrderTransactions_UserId] ON [AppOrderTransactions] ([UserId]);
GO

CREATE INDEX [IX_AppProductAttributeDateTimes_AttributeId] ON [AppProductAttributeDateTimes] ([AttributeId]);
GO

CREATE INDEX [IX_AppProductAttributeDateTimes_ProductId] ON [AppProductAttributeDateTimes] ([ProductId]);
GO

CREATE INDEX [IX_AppProductAttributeDecimals_AttributeId] ON [AppProductAttributeDecimals] ([AttributeId]);
GO

CREATE INDEX [IX_AppProductAttributeDecimals_ProductId] ON [AppProductAttributeDecimals] ([ProductId]);
GO

CREATE INDEX [IX_AppProductAttributeInts_AttributeId] ON [AppProductAttributeInts] ([AttributeId]);
GO

CREATE INDEX [IX_AppProductAttributeInts_ProductId] ON [AppProductAttributeInts] ([ProductId]);
GO

CREATE INDEX [IX_AppProductAttributeTexts_AttributeId] ON [AppProductAttributeTexts] ([AttributeId]);
GO

CREATE INDEX [IX_AppProductAttributeTexts_ProductId] ON [AppProductAttributeTexts] ([ProductId]);
GO

CREATE INDEX [IX_AppProductAttributeVarchars_AttributeId] ON [AppProductAttributeVarchars] ([AttributeId]);
GO

CREATE INDEX [IX_AppProductAttributeVarchars_ProductId] ON [AppProductAttributeVarchars] ([ProductId]);
GO

CREATE INDEX [IX_AppProductReviews_OrderId] ON [AppProductReviews] ([OrderId]);
GO

CREATE INDEX [IX_AppProductReviews_ParentId] ON [AppProductReviews] ([ParentId]);
GO

CREATE INDEX [IX_AppProductReviews_ProductId] ON [AppProductReviews] ([ProductId]);
GO

CREATE INDEX [IX_AppProducts_CategoryId] ON [AppProducts] ([CategoryId]);
GO

CREATE INDEX [IX_AppProducts_ManufacturerId] ON [AppProducts] ([ManufacturerId]);
GO

CREATE INDEX [IX_AppProductTags_TagId] ON [AppProductTags] ([TagId]);
GO

CREATE INDEX [IX_AppPromotionCategories_PromotionId] ON [AppPromotionCategories] ([PromotionId]);
GO

CREATE INDEX [IX_AppPromotionManufacturers_PromotionId] ON [AppPromotionManufacturers] ([PromotionId]);
GO

CREATE INDEX [IX_AppPromotionProducts_PromotionId] ON [AppPromotionProducts] ([PromotionId]);
GO

CREATE INDEX [IX_AppPromotionUsageHistories_PromotionId] ON [AppPromotionUsageHistories] ([PromotionId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221228161342_CreateBussinessEntities', N'6.0.5');
GO

COMMIT;
GO

