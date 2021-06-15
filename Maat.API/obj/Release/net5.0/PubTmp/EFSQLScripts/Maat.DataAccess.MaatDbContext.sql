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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218160343_InitialMigration')
BEGIN
    CREATE TABLE [SportEvents] (
        [Id] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [IsAvailable] bit NOT NULL,
        CONSTRAINT [PK_SportEvents] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218160343_InitialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsAvailable', N'Name') AND [object_id] = OBJECT_ID(N'[SportEvents]'))
        SET IDENTITY_INSERT [SportEvents] ON;
    EXEC(N'INSERT INTO [SportEvents] ([Id], [IsAvailable], [Name])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), N''Football'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsAvailable', N'Name') AND [object_id] = OBJECT_ID(N'[SportEvents]'))
        SET IDENTITY_INSERT [SportEvents] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218160343_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210218160343_InitialMigration', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210520081113_CreateUsersTable')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NULL,
        [Email] nvarchar(450) NULL,
        [Password] nvarchar(max) NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [Gender] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210520081113_CreateUsersTable')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]) WHERE [Email] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210520081113_CreateUsersTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210520081113_CreateUsersTable', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [CreatedById] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [EventTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [IsPayingNeeded] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [NumberOfParticipatingPlayers] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [NumberOfPlayersNeeded] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [Place] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [SkillLevel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD [SportType] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    CREATE INDEX [IX_SportEvents_CreatedById] ON [SportEvents] ([CreatedById]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    ALTER TABLE [SportEvents] ADD CONSTRAINT [FK_SportEvents_Users_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120011_UpdatedSportEventFields')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210612120011_UpdatedSportEventFields', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120521_UpdatedSportEventSkillLevel')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SportEvents]') AND [c].[name] = N'SkillLevel');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [SportEvents] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [SportEvents] ALTER COLUMN [SkillLevel] int NOT NULL;
    ALTER TABLE [SportEvents] ADD DEFAULT 0 FOR [SkillLevel];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210612120521_UpdatedSportEventSkillLevel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210612120521_UpdatedSportEventSkillLevel', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613085550_RemovedIsAvailableFromEvents')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SportEvents]') AND [c].[name] = N'IsAvailable');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [SportEvents] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [SportEvents] DROP COLUMN [IsAvailable];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613085550_RemovedIsAvailableFromEvents')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210613085550_RemovedIsAvailableFromEvents', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613172645_AddedSportEventUsersTable')
BEGIN
    EXEC(N'DELETE FROM [SportEvents]
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613172645_AddedSportEventUsersTable')
BEGIN
    CREATE TABLE [SportEventUsers] (
        [UserId] int NOT NULL,
        [SportEventId] bigint NOT NULL,
        CONSTRAINT [PK_SportEventUsers] PRIMARY KEY ([SportEventId], [UserId]),
        CONSTRAINT [FK_SportEventUsers_SportEvents_SportEventId] FOREIGN KEY ([SportEventId]) REFERENCES [SportEvents] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SportEventUsers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613172645_AddedSportEventUsersTable')
BEGIN
    CREATE INDEX [IX_SportEventUsers_UserId] ON [SportEventUsers] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613172645_AddedSportEventUsersTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210613172645_AddedSportEventUsersTable', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210613175107_UpdatedCreatedSportEventsForUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210613175107_UpdatedCreatedSportEventsForUser', N'5.0.3');
END;
GO

COMMIT;
GO

