USE [master]
GO

CREATE DATABASE [AddressManagerDb]
GO

USE [AddressManagerDb]
GO

IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170604073824_init')
BEGIN
    CREATE TABLE [Address] (
        [Id] bigint NOT NULL IDENTITY,
        [City] nvarchar(50),
        [Number] int NOT NULL,
        [PostCode] nvarchar(10) NOT NULL,
        [Street] nvarchar(50),
        [Town] nvarchar(50),
        CONSTRAINT [PK_Address] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170604073824_init')
BEGIN
    CREATE TABLE [Contact] (
        [Id] bigint NOT NULL IDENTITY,
        [EndDate] datetime2,
        [FirstName] nvarchar(30),
        [LastName] nvarchar(30),
        [StartDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170604073824_init')
BEGIN
    CREATE TABLE [ContactAddress] (
        [Id] bigint NOT NULL IDENTITY,
        [ContactId] bigint NOT NULL,
        [AddressId] bigint NOT NULL,
        [EndDate] datetime2,
        [StartDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ContactAddress] PRIMARY KEY ([Id], [ContactId], [AddressId]),
        CONSTRAINT [FK_ContactAddress_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ContactAddress_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contact] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170604073824_init')
BEGIN
    CREATE INDEX [IX_ContactAddress_AddressId] ON [ContactAddress] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170604073824_init')
BEGIN
    CREATE INDEX [IX_ContactAddress_ContactId] ON [ContactAddress] ([ContactId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20170604073824_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20170604073824_init', N'1.1.2');
END;

GO

