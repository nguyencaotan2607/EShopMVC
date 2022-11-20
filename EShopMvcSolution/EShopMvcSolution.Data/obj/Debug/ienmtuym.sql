IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AppConfig] (
    [Key] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AppConfig] PRIMARY KEY ([Key])
);

GO

CREATE TABLE [AppRoles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Description] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_AppRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AppUsers] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [FirstName] nvarchar(200) NOT NULL,
    [LastName] nvarchar(200) NOT NULL,
    [Dob] datetime2 NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [SortOrder] int NOT NULL,
    [IsShowOnHome] bit NOT NULL,
    [ParentId] int NULL,
    [Status] int NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [Email] nvarchar(200) NOT NULL,
    [Phone] nvarchar(200) NOT NULL,
    [Address] nvarchar(max) NULL,
    [Message] nvarchar(max) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Languages] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Isdefault] bit NOT NULL,
    CONSTRAINT [PK_Languages] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [Prince] decimal(18,2) NOT NULL,
    [OriginalPrice] decimal(18,2) NOT NULL,
    [Stock] int NOT NULL DEFAULT 0,
    [Viewcount] int NOT NULL DEFAULT 0,
    [DateCreate] datetime2 NOT NULL,
    [SeoAlias] nvarchar(max) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Promotions] (
    [Id] int NOT NULL IDENTITY,
    [FromDate] datetime2 NOT NULL,
    [ToDate] datetime2 NOT NULL,
    [ApplyforAll] bit NOT NULL,
    [DiscountPercent] int NULL,
    [DiscountAmount] decimal(18,2) NULL,
    [ProductIds] nvarchar(max) NULL,
    [ProductCategoryIds] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Promotions] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Slides] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Url] nvarchar(200) NOT NULL,
    [Image] nvarchar(200) NOT NULL,
    [SortOrder] int NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Slides] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [OrderDate] datetime2 NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [ShipName] varchar(50) NOT NULL,
    [ShipAddress] varchar(50) NOT NULL,
    [ShipEmail] varchar(50) NOT NULL,
    [ShipPhoneNumber] varchar(50) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [TransactionDate] datetime2 NOT NULL,
    [ExternalTransactionId] nvarchar(max) NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Fee] decimal(18,2) NOT NULL,
    [Result] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [Provider] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [CategoryTranslations] (
    [Id] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [SeoDescription] nvarchar(500) NULL,
    [SeoTitle] nvarchar(200) NULL,
    [LanguageId] int NOT NULL,
    [SeoAlias] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_CategoryTranslations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CategoryTranslations_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CategoryTranslations_Languages_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [Languages] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Carts] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    CONSTRAINT [PK_Carts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Carts_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Carts_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductImages] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [ImagePath] nvarchar(200) NOT NULL,
    [Caption] nvarchar(200) NULL,
    [IsDefault] bit NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [SortOrder] int NOT NULL,
    [FileSize] bigint NOT NULL,
    CONSTRAINT [PK_ProductImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductImages_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductInCategories] (
    [ProductId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_ProductInCategories] PRIMARY KEY ([CategoryId], [ProductId]),
    CONSTRAINT [FK_ProductInCategories_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductInCategories_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductTranslations] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Details] nvarchar(500) NULL,
    [SeoDescription] nvarchar(max) NULL,
    [Seotitle] nvarchar(max) NULL,
    [LanguageId] int NOT NULL,
    CONSTRAINT [PK_ProductTranslations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductTranslations_Languages_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [Languages] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductTranslations_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [OrderDetail] (
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([OrderId], [ProductId]),
    CONSTRAINT [FK_OrderDetail_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetail_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Carts_ProductId] ON [Carts] ([ProductId]);

GO

CREATE INDEX [IX_Carts_UserId] ON [Carts] ([UserId]);

GO

CREATE INDEX [IX_CategoryTranslations_CategoryId] ON [CategoryTranslations] ([CategoryId]);

GO

CREATE INDEX [IX_CategoryTranslations_LanguageId] ON [CategoryTranslations] ([LanguageId]);

GO

CREATE INDEX [IX_Order_UserId] ON [Order] ([UserId]);

GO

CREATE INDEX [IX_OrderDetail_ProductId] ON [OrderDetail] ([ProductId]);

GO

CREATE INDEX [IX_ProductImages_ProductId] ON [ProductImages] ([ProductId]);

GO

CREATE INDEX [IX_ProductInCategories_ProductId] ON [ProductInCategories] ([ProductId]);

GO

CREATE INDEX [IX_ProductTranslations_LanguageId] ON [ProductTranslations] ([LanguageId]);

GO

CREATE INDEX [IX_ProductTranslations_ProductId] ON [ProductTranslations] ([ProductId]);

GO

CREATE INDEX [IX_Transactions_UserId] ON [Transactions] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221119192747_Initial', N'3.1.31');

GO

