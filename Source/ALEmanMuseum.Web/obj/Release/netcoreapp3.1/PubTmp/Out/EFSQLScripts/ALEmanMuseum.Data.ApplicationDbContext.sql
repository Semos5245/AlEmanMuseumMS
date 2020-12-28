IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE SEQUENCE [ItemNumberSequence] START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE SEQUENCE [OrderNumberSequence] START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
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
        [Blocked] bit NOT NULL,
        [LastLoginUtc] datetime2 NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [EnglishName] nvarchar(100) NOT NULL,
        [ArabicName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Categories_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Countries] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Name] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Countries_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [SearchTerm] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Term] nvarchar(100) NOT NULL,
        [Count] int NOT NULL,
        CONSTRAINT [PK_SearchTerm] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SearchTerm_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Slider] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [ArabicName] nvarchar(50) NOT NULL,
        [EnglishName] nvarchar(50) NOT NULL,
        [Active] bit NOT NULL,
        CONSTRAINT [PK_Slider] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Slider_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [UserActivity] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [ActionId] int NOT NULL,
        [Description] nvarchar(512) NOT NULL,
        [RelatedEntityId] int NOT NULL,
        CONSTRAINT [PK_UserActivity] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserActivity_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Items] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Guid] nvarchar(10) NOT NULL,
        [UniqueNumber] int NOT NULL DEFAULT (NEXT VALUE FOR ItemNumberSequence),
        [EnglishName] nvarchar(50) NULL,
        [ArabicName] nvarchar(50) NULL,
        [Quantity] int NOT NULL,
        [EnglishDescription] nvarchar(512) NULL,
        [ArabicDescription] nvarchar(512) NULL,
        [OriginalPrice] decimal(18, 8) NOT NULL,
        [SellingPrice] decimal(18, 8) NOT NULL,
        [BarcodeImageUrl] nvarchar(512) NULL,
        [Hidden] bit NOT NULL,
        [Views] int NOT NULL,
        [Tags] nvarchar(max) NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Items_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Items_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Name] nvarchar(150) NOT NULL,
        [Email] nvarchar(100) NULL,
        [Phone] nvarchar(50) NOT NULL,
        [ProfilePictureUrl] nvarchar(max) NULL,
        [BirthDate] datetime2 NULL,
        [Blocked] bit NOT NULL,
        [GenderId] int NOT NULL,
        [CountryId] int NULL,
        [UserId] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Customers_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE SET NULL,
        CONSTRAINT [FK_Customers_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [SliderImage] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [ImageName] nvarchar(512) NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [SliderId] int NOT NULL,
        CONSTRAINT [PK_SliderImage] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SliderImage_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SliderImage_Slider_SliderId] FOREIGN KEY ([SliderId]) REFERENCES [Slider] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [ItemImages] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        [ThumbNailUrl] nvarchar(max) NULL,
        [ItemId] int NULL,
        [CategoryId] int NULL,
        CONSTRAINT [PK_ItemImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ItemImages_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE SET NULL,
        CONSTRAINT [FK_ItemImages_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ItemImages_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE SET NULL
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Addresses] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Area] nvarchar(75) NULL,
        [Street] nvarchar(50) NULL,
        [BuildingName] nvarchar(100) NULL,
        [Floor] nvarchar(20) NULL,
        [CustomerId] int NOT NULL,
        CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Addresses_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Addresses_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Checkouts] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [CustomerName] nvarchar(100) NULL,
        [CustomerPhone] nvarchar(75) NULL,
        [CheckoutStatusId] int NOT NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_Checkouts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Checkouts_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Checkouts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Favorites] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [CustomerId] int NOT NULL,
        [ItemId] int NOT NULL,
        CONSTRAINT [PK_Favorites] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Favorites_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Favorites_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Favorites_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Rents] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [RentDate] datetime2 NOT NULL,
        [ClosedDate] datetime2 NULL,
        [CustomerName] nvarchar(100) NOT NULL,
        [CustomerPhone] nvarchar(30) NULL,
        [RentStatusId] int NOT NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_Rents] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rents_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Rents_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE SET NULL
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [ShoppingCart] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [ShoppingCartStatusId] int NOT NULL,
        [CustomerId] int NOT NULL,
        CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCart_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ShoppingCart_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [CheckoutItems] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Quantity] int NOT NULL,
        [Price] decimal(18, 8) NOT NULL,
        [ItemId] int NOT NULL,
        [CheckoutId] int NOT NULL,
        CONSTRAINT [PK_CheckoutItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CheckoutItems_Checkouts_CheckoutId] FOREIGN KEY ([CheckoutId]) REFERENCES [Checkouts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CheckoutItems_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_CheckoutItems_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [RentItems] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Quantity] int NOT NULL,
        [RentItemStatusId] int NOT NULL,
        [RentId] int NOT NULL,
        [ItemId] int NOT NULL,
        CONSTRAINT [PK_RentItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RentItems_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RentItems_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RentItems_Rents_RentId] FOREIGN KEY ([RentId]) REFERENCES [Rents] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [RentNote] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Note] nvarchar(256) NOT NULL,
        [RentId] int NOT NULL,
        CONSTRAINT [PK_RentNote] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RentNote_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RentNote_Rents_RentId] FOREIGN KEY ([RentId]) REFERENCES [Rents] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [Order] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [OrderNumber] int NOT NULL DEFAULT (NEXT VALUE FOR OrderNumberSequence),
        [OrderStatusId] int NOT NULL,
        [AddressId] int NULL,
        [CustomerId] int NOT NULL,
        [ShoppingCartId] int NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE SET NULL,
        CONSTRAINT [FK_Order_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Order_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Order_ShoppingCart_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCart] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE TABLE [ShoppingCartItem] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        [CreatorModifierId] nvarchar(450) NULL,
        [Quantity] int NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ShoppingCartId] int NOT NULL,
        [ItemId] int NOT NULL,
        CONSTRAINT [PK_ShoppingCartItem] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCartItem_AspNetUsers_CreatorModifierId] FOREIGN KEY ([CreatorModifierId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ShoppingCartItem_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ShoppingCartItem_ShoppingCart_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCart] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Addresses_CreatorModifierId] ON [Addresses] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE UNIQUE INDEX [IX_Addresses_CustomerId] ON [Addresses] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Categories_CreatorModifierId] ON [Categories] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_CheckoutItems_CheckoutId] ON [CheckoutItems] ([CheckoutId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_CheckoutItems_CreatorModifierId] ON [CheckoutItems] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_CheckoutItems_ItemId] ON [CheckoutItems] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Checkouts_CreatorModifierId] ON [Checkouts] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Checkouts_CustomerId] ON [Checkouts] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Countries_CreatorModifierId] ON [Countries] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Customers_CountryId] ON [Customers] ([CountryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Customers_CreatorModifierId] ON [Customers] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Favorites_CreatorModifierId] ON [Favorites] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Favorites_CustomerId] ON [Favorites] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Favorites_ItemId] ON [Favorites] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ItemImages_CategoryId] ON [ItemImages] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ItemImages_CreatorModifierId] ON [ItemImages] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE UNIQUE INDEX [IX_ItemImages_ItemId] ON [ItemImages] ([ItemId]) WHERE [ItemId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Items_CategoryId] ON [Items] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Items_CreatorModifierId] ON [Items] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Order_AddressId] ON [Order] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Order_CreatorModifierId] ON [Order] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Order_CustomerId] ON [Order] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE UNIQUE INDEX [IX_Order_ShoppingCartId] ON [Order] ([ShoppingCartId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_RentItems_CreatorModifierId] ON [RentItems] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_RentItems_ItemId] ON [RentItems] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_RentItems_RentId] ON [RentItems] ([RentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_RentNote_CreatorModifierId] ON [RentNote] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_RentNote_RentId] ON [RentNote] ([RentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Rents_CreatorModifierId] ON [Rents] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Rents_CustomerId] ON [Rents] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_SearchTerm_CreatorModifierId] ON [SearchTerm] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ShoppingCart_CreatorModifierId] ON [ShoppingCart] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ShoppingCart_CustomerId] ON [ShoppingCart] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ShoppingCartItem_CreatorModifierId] ON [ShoppingCartItem] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ShoppingCartItem_ItemId] ON [ShoppingCartItem] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_ShoppingCartItem_ShoppingCartId] ON [ShoppingCartItem] ([ShoppingCartId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_Slider_CreatorModifierId] ON [Slider] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_SliderImage_CreatorModifierId] ON [SliderImage] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_SliderImage_SliderId] ON [SliderImage] ([SliderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    CREATE INDEX [IX_UserActivity_CreatorModifierId] ON [UserActivity] ([CreatorModifierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626134811_InitDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200626134811_InitDB', N'3.1.5');
END;

GO

