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

CREATE TABLE [Glues] (
    [ID] int NOT NULL IDENTITY,
    [GlueName] NVARCHAR(250) NOT NULL,
    [GlueCode] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Glues] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231002125053_initial_20231002', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'Paper') IS NULL EXEC(N'CREATE SCHEMA [Paper];');
GO

ALTER SCHEMA [Paper] TRANSFER [Glues];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231002125715_initial_20231002_1', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231004150715_initial_20231004', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231005074135_initial_20231005', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employee] (
    [Id] uniqueidentifier NOT NULL,
    [UserID] nvarchar(max) NOT NULL,
    [UserName] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [IdentityNumber] nvarchar(max) NOT NULL,
    [IdentitDated] datetime2 NOT NULL,
    [Birthday] datetime2 NOT NULL,
    [PlaceIssued] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [TemporaryAddress] nvarchar(max) NOT NULL,
    [IsOff] bit NOT NULL,
    [OffDate] datetime2 NOT NULL,
    [OnDate] datetime2 NOT NULL,
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
    CONSTRAINT [PK_Employee] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_EmployeeClaims] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeLogins] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(max) NULL,
    [ProviderKey] nvarchar(max) NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    CONSTRAINT [PK_EmployeeLogins] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [EmployeeRole] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_EmployeeRole] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_EmployeeRoleClaims] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY ([UserId], [RoleId])
);
GO

CREATE TABLE [EmployeeUserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_EmployeeUserTokens] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231007085542_initial_20231007', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Paper].[Glues] ADD [Created] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Paper].[Glues] ADD [Deleted] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Paper].[Glues] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Paper].[Glues] ADD [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Paper].[Glues] ADD [Modified] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231011071731_initial_20231011', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER SCHEMA [Paper] TRANSFER [Soles];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[Soles]') AND [c].[name] = N'SoleInfomation');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[Soles] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Paper].[Soles] ALTER COLUMN [SoleInfomation] NVARCHAR(250) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[Soles]') AND [c].[name] = N'SoleCode');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[Soles] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Paper].[Soles] ALTER COLUMN [SoleCode] NVARCHAR(250) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231013143055_initial_20231013', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Paper].[PaperTypes] (
    [ID] int NOT NULL IDENTITY,
    [PaperTypeName] NVARCHAR(250) NOT NULL,
    [PaperTypeCode] NVARCHAR(250) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Deleted] datetime2 NOT NULL,
    CONSTRAINT [PK_PaperTypes] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231014014845_initial_20231014', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[PaperTypeMains]') AND [c].[name] = N'PaperTypeID');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[PaperTypeMains] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Paper].[PaperTypeMains] ALTER COLUMN [PaperTypeID] int NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231015130843_initial_20231015', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Paper].[Papers] (
    [ID] int NOT NULL IDENTITY,
    [Supplier] nvarchar(max) NOT NULL,
    [PaperTypeID] int NOT NULL,
    [PaperTypeName] NVARCHAR(250) NOT NULL,
    [PaperTypeMainID] int NOT NULL,
    [PaperTypeMainCode] nvarchar(max) NOT NULL,
    [SoleID] int NOT NULL,
    [SoleName] nvarchar(max) NOT NULL,
    [PaperName] nvarchar(max) NOT NULL,
    [GlueID] int NOT NULL,
    [GlueName] nvarchar(max) NOT NULL,
    [Purpose] nvarchar(max) NOT NULL,
    [Characteristic] nvarchar(max) NOT NULL,
    [PaperSize] nvarchar(max) NOT NULL,
    [Unit] nvarchar(max) NOT NULL,
    [SurfaceThick] nvarchar(max) NOT NULL,
    [SoleBaseThick] nvarchar(max) NOT NULL,
    [SoleThick] nvarchar(max) NOT NULL,
    [TotalThick] nvarchar(max) NOT NULL,
    [QuantitativePaper] nvarchar(max) NOT NULL,
    [PaperTypeCode] NVARCHAR(250) NOT NULL,
    [Core] nvarchar(max) NOT NULL,
    [Note] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Deleted] datetime2 NOT NULL,
    CONSTRAINT [PK_Papers] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231018091312_initial_20231018', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[Papers]') AND [c].[name] = N'TotalThick');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[Papers] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Paper].[Papers] ALTER COLUMN [TotalThick] int NOT NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[Papers]') AND [c].[name] = N'SurfaceThick');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[Papers] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Paper].[Papers] ALTER COLUMN [SurfaceThick] int NOT NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[Papers]') AND [c].[name] = N'SoleThick');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[Papers] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Paper].[Papers] ALTER COLUMN [SoleThick] int NOT NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paper].[Papers]') AND [c].[name] = N'SoleBaseThick');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Paper].[Papers] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Paper].[Papers] ALTER COLUMN [SoleBaseThick] int NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231019140822_initial_20231019', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Paper].[UpdateDataPaperTrackings] (
    [ID] int NOT NULL IDENTITY,
    [UpdateBy] NVARCHAR(250) NOT NULL,
    [TableName] NVARCHAR(250) NOT NULL,
    [OldValue] nvarchar(max) NOT NULL,
    [NewValue] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_UpdateDataPaperTrackings] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231022060234_initial_20231022', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231022083252_initial_20231022_1', N'6.0.21');
GO

COMMIT;
GO

