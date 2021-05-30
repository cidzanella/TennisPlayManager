IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

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
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.10');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221123938_Initial', N'3.1.10');

GO

CREATE TABLE [Agendas] (
    [Id] int NOT NULL IDENTITY,
    [QuadraId] int NOT NULL,
    [FinalidadeUsoQuadraId] int NOT NULL,
    [DataInicial] datetime2 NOT NULL,
    [DataFinal] datetime2 NOT NULL,
    [EhPreReserva] bit NOT NULL,
    CONSTRAINT [PK_Agendas] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221124317_AddAgenda', N'3.1.10');

GO

CREATE TABLE [Cancelamentos] (
    [Id] int NOT NULL IDENTITY,
    [MotivoCancelamentoId] int NOT NULL,
    [CaneladoPorTenistaId] int NOT NULL,
    [DataCancelamento] datetime2 NOT NULL,
    [GerouWO] tinyint NOT NULL,
    [GerouMulta] tinyint NOT NULL,
    CONSTRAINT [PK_Cancelamentos] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221124424_AddCancelamento', N'3.1.10');

GO

CREATE TABLE [FinalidadeUsoQuadras] (
    [Id] tinyint NOT NULL,
    [Finalidade] nvarchar(max) NOT NULL,
    [TempoReservaEmMinutos] int NOT NULL,
    CONSTRAINT [PK_FinalidadeUsoQuadras] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221124526_AddFinalidadeUsoQuadra', N'3.1.10');

GO

CREATE TABLE [HorariosHabilitadoDesafio] (
    [Id] int NOT NULL IDENTITY,
    [DiaSemana] tinyint NOT NULL,
    [HorarioInicial] datetime2 NOT NULL,
    [HorarioFinal] datetime2 NOT NULL,
    [QuadraId] int NOT NULL,
    CONSTRAINT [PK_HorariosHabilitadoDesafio] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221181753_AddHorarioHabilitadoDesafio', N'3.1.10');

GO

CREATE TABLE [Jogos] (
    [Id] int NOT NULL IDENTITY,
    [JogoOriginalId] int NOT NULL,
    [TenistaAId] int NOT NULL,
    [TenistaBId] int NOT NULL,
    [AgendaId] int NOT NULL,
    [EhDesafio] bit NOT NULL,
    [DataConvite] datetime2 NOT NULL,
    [DataRespostaConvite] datetime2 NOT NULL,
    [ConviteAceito] bit NOT NULL,
    [TenistaVencedorId] int NOT NULL,
    [TenistaDesistenteId] int NOT NULL,
    [CancelamentoId] int NOT NULL,
    [PlacarId] int NOT NULL,
    CONSTRAINT [PK_Jogos] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221181849_AddJogo', N'3.1.10');

GO

CREATE TABLE [MotivosBloqueio] (
    [Id] int NOT NULL IDENTITY,
    [Motivo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_MotivosBloqueio] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221181930_AddMotivoBloqueio', N'3.1.10');

GO

CREATE TABLE [MotivosCancelamento] (
    [Id] int NOT NULL IDENTITY,
    [Motivo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_MotivosCancelamento] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221182016_AddMotivoCancelamento', N'3.1.10');

GO

CREATE TABLE [Placares] (
    [Id] int NOT NULL IDENTITY,
    [Set] tinyint NOT NULL,
    [GamesTenistaA] tinyint NOT NULL,
    [GamesTenistaB] tinyint NOT NULL,
    [TieBreakTenistaA] tinyint NOT NULL,
    [TieBreakTenistaB] tinyint NOT NULL,
    CONSTRAINT [PK_Placares] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221183411_AddPlacar', N'3.1.10');

GO

CREATE TABLE [Quadras] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [FinalidadeUsoQuadraId] int NOT NULL,
    CONSTRAINT [PK_Quadras] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221183450_AddQuadra', N'3.1.10');

GO

CREATE TABLE [RankingTenistas] (
    [Id] int NOT NULL IDENTITY,
    [Posicao] tinyint NOT NULL,
    [TenistaId] int NOT NULL,
    [DataPosicaoAtual] datetime2 NOT NULL,
    [PosicaoAnterior] tinyint NOT NULL,
    [DataPosicaoAnterior] datetime2 NOT NULL,
    [PosicaoInicial] tinyint NOT NULL,
    [DataPosicaoInicial] datetime2 NOT NULL,
    CONSTRAINT [PK_RankingTenistas] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221183545_AddRankingTenistas', N'3.1.10');

GO

CREATE TABLE [RegrasGerais] (
    [Id] int NOT NULL IDENTITY,
    [PosicoesAcima] tinyint NOT NULL,
    [MinimoDesafiosMes] tinyint NOT NULL,
    [MaximoDesafiosSemana] tinyint NOT NULL,
    [MaximoRecusas] tinyint NOT NULL,
    [MultaWO] tinyint NOT NULL,
    [PrazoHorasCancelamentoSemMulta] tinyint NOT NULL,
    [PrazoHorasRespostaDesafio] tinyint NOT NULL,
    [PrazoDiasRevanche] tinyint NOT NULL,
    [JogosNoAd] bit NOT NULL,
    [NumeroJogadoresTorneioFinalsMasculino] tinyint NOT NULL,
    [NumeroJogadoresTorneioFinalsFeminino] tinyint NOT NULL,
    [ToleranciaMinutosWO] tinyint NOT NULL,
    [AquecimentoMinutos] tinyint NOT NULL,
    CONSTRAINT [PK_RegrasGerais] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221183619_AddRegrasGerais', N'3.1.10');

GO

CREATE TABLE [Tenistas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Sobrenome] nvarchar(max) NOT NULL,
    [Nascimento] datetime2 NOT NULL,
    [Sexo] tinyint NOT NULL,
    [AlturaCm] tinyint NOT NULL,
    [Empunhadura] tinyint NOT NULL,
    [Backhand] tinyint NOT NULL,
    [FotoFilePath] nvarchar(max) NOT NULL,
    [Celular] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(10) NOT NULL,
    [Cidade] tinyint NOT NULL,
    [MotivoBloqueioId] int NOT NULL,
    [TipoTenista] tinyint NOT NULL,
    [JogaRanking] bit NOT NULL,
    CONSTRAINT [PK_Tenistas] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221183707_AddTenista', N'3.1.10');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Nome');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Nome] nvarchar(50) NOT NULL;

GO

ALTER TABLE [RankingTenistas] ADD [Sexo] tinyint NOT NULL DEFAULT CAST(0 AS tinyint);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226111607_AddSexoRankingTenistas', N'3.1.10');

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Cidade');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Cidade] int NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226130631_ChangeCidade_ByteToInt_emTenista', N'3.1.10');

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Cidade');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Tenistas] DROP COLUMN [Cidade];

GO

ALTER TABLE [Tenistas] ADD [CidadeId] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226131344_RenameCidade_CidadeId_emTenista', N'3.1.10');

GO

CREATE TABLE [Cidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cidades] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226132114_AddCidade', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Cidades]'))
    SET IDENTITY_INSERT [Cidades] ON;
INSERT INTO [Cidades] ([Id], [Nome])
VALUES (1, N'Medianeira'),
(2, N'Matelândia'),
(3, N'São Miguel do Iguaçu'),
(4, N'Foz do Iguaçu'),
(5, N'Missal'),
(6, N'Itaipulândia'),
(7, N'Serranópolis do Iguaçu'),
(8, N'Cascavel');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[Cidades]'))
    SET IDENTITY_INSERT [Cidades] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226140023_SeedCidade', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosCancelamento]'))
    SET IDENTITY_INSERT [MotivosCancelamento] ON;
INSERT INTO [MotivosCancelamento] ([Id], [Motivo])
VALUES (1, N'Chuva'),
(2, N'Manutenção'),
(3, N'Falta de luz'),
(4, N'Solicitação do desafiado'),
(5, N'Solicitação do desafiante'),
(6, N'Reagendado');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosCancelamento]'))
    SET IDENTITY_INSERT [MotivosCancelamento] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226153147_SeedMotivoCancelamento', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosBloqueio]'))
    SET IDENTITY_INSERT [MotivosBloqueio] ON;
INSERT INTO [MotivosBloqueio] ([Id], [Motivo])
VALUES (1, N'Pendência Mensalidade');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosBloqueio]'))
    SET IDENTITY_INSERT [MotivosBloqueio] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosBloqueio]'))
    SET IDENTITY_INSERT [MotivosBloqueio] ON;
INSERT INTO [MotivosBloqueio] ([Id], [Motivo])
VALUES (2, N'Pendência Multa');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosBloqueio]'))
    SET IDENTITY_INSERT [MotivosBloqueio] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosBloqueio]'))
    SET IDENTITY_INSERT [MotivosBloqueio] ON;
INSERT INTO [MotivosBloqueio] ([Id], [Motivo])
VALUES (3, N'Decisão CCO');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Motivo') AND [object_id] = OBJECT_ID(N'[MotivosBloqueio]'))
    SET IDENTITY_INSERT [MotivosBloqueio] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226153458_SeedMotivoBloqueio', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Finalidade', N'TempoReservaEmMinutos') AND [object_id] = OBJECT_ID(N'[FinalidadeUsoQuadras]'))
    SET IDENTITY_INSERT [FinalidadeUsoQuadras] ON;
INSERT INTO [FinalidadeUsoQuadras] ([Id], [Finalidade], [TempoReservaEmMinutos])
VALUES (CAST(1 AS tinyint), N'Aula', 30),
(CAST(2 AS tinyint), N'Ranking', 120),
(CAST(3 AS tinyint), N'Amistoso', 60),
(CAST(4 AS tinyint), N'Ranking, Amistoso', 0),
(CAST(5 AS tinyint), N'Todas', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Finalidade', N'TempoReservaEmMinutos') AND [object_id] = OBJECT_ID(N'[FinalidadeUsoQuadras]'))
    SET IDENTITY_INSERT [FinalidadeUsoQuadras] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201227122237_SeedFinalidadeUsoQuadra', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FinalidadeUsoQuadraId', N'Nome') AND [object_id] = OBJECT_ID(N'[Quadras]'))
    SET IDENTITY_INSERT [Quadras] ON;
INSERT INTO [Quadras] ([Id], [FinalidadeUsoQuadraId], [Nome])
VALUES (1, 1, N'Quadra #1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FinalidadeUsoQuadraId', N'Nome') AND [object_id] = OBJECT_ID(N'[Quadras]'))
    SET IDENTITY_INSERT [Quadras] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FinalidadeUsoQuadraId', N'Nome') AND [object_id] = OBJECT_ID(N'[Quadras]'))
    SET IDENTITY_INSERT [Quadras] ON;
INSERT INTO [Quadras] ([Id], [FinalidadeUsoQuadraId], [Nome])
VALUES (2, 2, N'Quadra #2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FinalidadeUsoQuadraId', N'Nome') AND [object_id] = OBJECT_ID(N'[Quadras]'))
    SET IDENTITY_INSERT [Quadras] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FinalidadeUsoQuadraId', N'Nome') AND [object_id] = OBJECT_ID(N'[Quadras]'))
    SET IDENTITY_INSERT [Quadras] ON;
INSERT INTO [Quadras] ([Id], [FinalidadeUsoQuadraId], [Nome])
VALUES (3, 3, N'Quadra #3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FinalidadeUsoQuadraId', N'Nome') AND [object_id] = OBJECT_ID(N'[Quadras]'))
    SET IDENTITY_INSERT [Quadras] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201227122721_SeedQuadra', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DiaSemana', N'HorarioFinal', N'HorarioInicial', N'QuadraId') AND [object_id] = OBJECT_ID(N'[HorariosHabilitadoDesafio]'))
    SET IDENTITY_INSERT [HorariosHabilitadoDesafio] ON;
INSERT INTO [HorariosHabilitadoDesafio] ([Id], [DiaSemana], [HorarioFinal], [HorarioInicial], [QuadraId])
VALUES (1, CAST(4 AS tinyint), '2020-12-27T22:00:00.0000000', '2020-12-27T19:00:00.0000000', 1),
(2, CAST(6 AS tinyint), '2020-12-27T22:00:00.0000000', '2020-12-27T19:00:00.0000000', 1),
(3, CAST(7 AS tinyint), '2020-12-27T20:00:00.0000000', '2020-12-27T15:00:00.0000000', 1),
(4, CAST(1 AS tinyint), '2020-12-27T12:00:00.0000000', '2020-12-27T09:00:00.0000000', 1),
(6, CAST(6 AS tinyint), '2020-12-27T22:00:00.0000000', '2020-12-27T19:00:00.0000000', 2),
(7, CAST(7 AS tinyint), '2020-12-27T20:00:00.0000000', '2020-12-27T15:00:00.0000000', 2),
(8, CAST(1 AS tinyint), '2020-12-27T12:00:00.0000000', '2020-12-27T09:00:00.0000000', 2),
(9, CAST(4 AS tinyint), '2020-12-27T22:00:00.0000000', '2020-12-27T19:00:00.0000000', 3),
(10, CAST(6 AS tinyint), '2020-12-27T22:00:00.0000000', '2020-12-27T19:00:00.0000000', 3),
(11, CAST(7 AS tinyint), '2020-12-27T20:00:00.0000000', '2020-12-27T15:00:00.0000000', 3),
(12, CAST(1 AS tinyint), '2020-12-27T12:00:00.0000000', '2020-12-27T09:00:00.0000000', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DiaSemana', N'HorarioFinal', N'HorarioInicial', N'QuadraId') AND [object_id] = OBJECT_ID(N'[HorariosHabilitadoDesafio]'))
    SET IDENTITY_INSERT [HorariosHabilitadoDesafio] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201227124537_SeedHorarioHabilitadoDesafio', N'3.1.10');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AquecimentoMinutos', N'JogosNoAd', N'MaximoDesafiosSemana', N'MaximoRecusas', N'MinimoDesafiosMes', N'MultaWO', N'NumeroJogadoresTorneioFinalsFeminino', N'NumeroJogadoresTorneioFinalsMasculino', N'PosicoesAcima', N'PrazoDiasRevanche', N'PrazoHorasCancelamentoSemMulta', N'PrazoHorasRespostaDesafio', N'ToleranciaMinutosWO') AND [object_id] = OBJECT_ID(N'[RegrasGerais]'))
    SET IDENTITY_INSERT [RegrasGerais] ON;
INSERT INTO [RegrasGerais] ([Id], [AquecimentoMinutos], [JogosNoAd], [MaximoDesafiosSemana], [MaximoRecusas], [MinimoDesafiosMes], [MultaWO], [NumeroJogadoresTorneioFinalsFeminino], [NumeroJogadoresTorneioFinalsMasculino], [PosicoesAcima], [PrazoDiasRevanche], [PrazoHorasCancelamentoSemMulta], [PrazoHorasRespostaDesafio], [ToleranciaMinutosWO])
VALUES (1, CAST(10 AS tinyint), CAST(1 AS bit), CAST(1 AS tinyint), CAST(2 AS tinyint), CAST(1 AS tinyint), CAST(20 AS tinyint), CAST(4 AS tinyint), CAST(8 AS tinyint), CAST(2 AS tinyint), CAST(15 AS tinyint), CAST(4 AS tinyint), CAST(12 AS tinyint), CAST(15 AS tinyint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AquecimentoMinutos', N'JogosNoAd', N'MaximoDesafiosSemana', N'MaximoRecusas', N'MinimoDesafiosMes', N'MultaWO', N'NumeroJogadoresTorneioFinalsFeminino', N'NumeroJogadoresTorneioFinalsMasculino', N'PosicoesAcima', N'PrazoDiasRevanche', N'PrazoHorasCancelamentoSemMulta', N'PrazoHorasRespostaDesafio', N'ToleranciaMinutosWO') AND [object_id] = OBJECT_ID(N'[RegrasGerais]'))
    SET IDENTITY_INSERT [RegrasGerais] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201227130337_SeedRegrasGerais', N'3.1.10');

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'FotoFilePath');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Tenistas] DROP COLUMN [FotoFilePath];

GO

ALTER TABLE [Tenistas] ADD [Foto] nvarchar(max) NOT NULL DEFAULT N'';

GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T22:00:00.0000000', [HorarioInicial] = '2020-12-29T19:00:00.0000000'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T22:00:00.0000000', [HorarioInicial] = '2020-12-29T19:00:00.0000000'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T20:00:00.0000000', [HorarioInicial] = '2020-12-29T15:00:00.0000000'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T12:00:00.0000000', [HorarioInicial] = '2020-12-29T09:00:00.0000000'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T22:00:00.0000000', [HorarioInicial] = '2020-12-29T19:00:00.0000000'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T20:00:00.0000000', [HorarioInicial] = '2020-12-29T15:00:00.0000000'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T12:00:00.0000000', [HorarioInicial] = '2020-12-29T09:00:00.0000000'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T22:00:00.0000000', [HorarioInicial] = '2020-12-29T19:00:00.0000000'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T22:00:00.0000000', [HorarioInicial] = '2020-12-29T19:00:00.0000000'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T20:00:00.0000000', [HorarioInicial] = '2020-12-29T15:00:00.0000000'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2020-12-29T12:00:00.0000000', [HorarioInicial] = '2020-12-29T09:00:00.0000000'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201229114510_ChangeTenistaFoto', N'3.1.10');

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Foto');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Foto] nvarchar(max) NULL;

GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T22:00:00.0000000', [HorarioInicial] = '2021-01-08T19:00:00.0000000'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T22:00:00.0000000', [HorarioInicial] = '2021-01-08T19:00:00.0000000'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T20:00:00.0000000', [HorarioInicial] = '2021-01-08T15:00:00.0000000'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T12:00:00.0000000', [HorarioInicial] = '2021-01-08T09:00:00.0000000'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T22:00:00.0000000', [HorarioInicial] = '2021-01-08T19:00:00.0000000'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T20:00:00.0000000', [HorarioInicial] = '2021-01-08T15:00:00.0000000'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T12:00:00.0000000', [HorarioInicial] = '2021-01-08T09:00:00.0000000'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T22:00:00.0000000', [HorarioInicial] = '2021-01-08T19:00:00.0000000'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T22:00:00.0000000', [HorarioInicial] = '2021-01-08T19:00:00.0000000'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T20:00:00.0000000', [HorarioInicial] = '2021-01-08T15:00:00.0000000'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-08T12:00:00.0000000', [HorarioInicial] = '2021-01-08T09:00:00.0000000'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210108184123_PermitirNullTenisaFoto', N'3.1.10');

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Senha');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Tenistas] DROP COLUMN [Senha];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Email');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Email] nvarchar(max) NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Celular');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Celular] nvarchar(12) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210108195111_RetiradoSenhaModelTenista', N'3.1.10');

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Celular');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Celular] nvarchar(14) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210108195903_TenistaCelular14char', N'3.1.10');

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'TipoTenista');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [TipoTenista] tinyint NULL;

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Email');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Email] nvarchar(max) NOT NULL;

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tenistas]') AND [c].[name] = N'Celular');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Tenistas] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Tenistas] ALTER COLUMN [Celular] nvarchar(11) NOT NULL;

GO

ALTER TABLE [Tenistas] ADD [Apelido] nvarchar(max) NULL;

GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T22:00:00.0000000', [HorarioInicial] = '2021-01-12T19:00:00.0000000'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T22:00:00.0000000', [HorarioInicial] = '2021-01-12T19:00:00.0000000'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T20:00:00.0000000', [HorarioInicial] = '2021-01-12T15:00:00.0000000'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T12:00:00.0000000', [HorarioInicial] = '2021-01-12T09:00:00.0000000'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T22:00:00.0000000', [HorarioInicial] = '2021-01-12T19:00:00.0000000'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T20:00:00.0000000', [HorarioInicial] = '2021-01-12T15:00:00.0000000'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T12:00:00.0000000', [HorarioInicial] = '2021-01-12T09:00:00.0000000'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T22:00:00.0000000', [HorarioInicial] = '2021-01-12T19:00:00.0000000'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T22:00:00.0000000', [HorarioInicial] = '2021-01-12T19:00:00.0000000'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T20:00:00.0000000', [HorarioInicial] = '2021-01-12T15:00:00.0000000'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


GO

UPDATE [HorariosHabilitadoDesafio] SET [HorarioFinal] = '2021-01-12T12:00:00.0000000', [HorarioInicial] = '2021-01-12T09:00:00.0000000'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210112220503_AdicionadoApelitoTenista', N'3.1.10');

GO

