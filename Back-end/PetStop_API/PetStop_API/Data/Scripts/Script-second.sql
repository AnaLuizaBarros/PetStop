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

CREATE TABLE [Endereco] (
    [Id_Endereco] int NOT NULL IDENTITY,
    [Rua] VARCHAR(50) NOT NULL,
    [Numero] int NULL,
    [Bairro] VARCHAR(20) NOT NULL,
    [Cidade] VARCHAR(30) NOT NULL,
    [Cep] nvarchar(max) NULL,
    [Estado] VARCHAR(20) NOT NULL,
    [Sigla] CHAR(2) NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id_Endereco])
);
GO

CREATE TABLE [Especie] (
    [Id_Especie] int NOT NULL IDENTITY,
    [Nome] VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Especie] PRIMARY KEY ([Id_Especie])
);
GO

CREATE TABLE [Raca] (
    [Id_Raca] int NOT NULL IDENTITY,
    [Descricao_Raca] VARCHAR(30) NOT NULL,
    CONSTRAINT [PK_Raca] PRIMARY KEY ([Id_Raca])
);
GO

CREATE TABLE [Adotante] (
    [IdAdotante] int NOT NULL IDENTITY,
    [Nome] VARCHAR(50) NOT NULL,
    [Telefone] nvarchar(max) NULL,
    [Idade] INT NOT NULL,
    [Cpf] VARCHAR(15) NOT NULL,
    [Dt_Nascimento] DATETIME NOT NULL,
    [EnderecoId_Endereco] int NULL,
    [Email] VARCHAR(30) NOT NULL,
    CONSTRAINT [PK_Adotante] PRIMARY KEY ([IdAdotante]),
    CONSTRAINT [FK_Adotante_Endereco_EnderecoId_Endereco] FOREIGN KEY ([EnderecoId_Endereco]) REFERENCES [Endereco] ([Id_Endereco]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Pessoa] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(50) NOT NULL,
    [Idade] INT NOT NULL,
    [Cpf] VARCHAR(15) NOT NULL,
    [Telefone] VARCHAR(15) NOT NULL,
    [Dt_Nascimento] DATETIME NOT NULL,
    [Email] VARCHAR(30) NOT NULL,
    [EnderecoId_Endereco] int NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoa_Endereco_EnderecoId_Endereco] FOREIGN KEY ([EnderecoId_Endereco]) REFERENCES [Endereco] ([Id_Endereco]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Animal] (
    [Id_Animal] int NOT NULL,
    [Nome] VARCHAR(50) NOT NULL,
    [RacaId_Raca] int NULL,
    CONSTRAINT [PK_Animal] PRIMARY KEY ([Id_Animal]),
    CONSTRAINT [FK_Animal_Especie_Id_Animal] FOREIGN KEY ([Id_Animal]) REFERENCES [Especie] ([Id_Especie]) ON DELETE CASCADE,
    CONSTRAINT [FK_Animal_Raca_RacaId_Raca] FOREIGN KEY ([RacaId_Raca]) REFERENCES [Raca] ([Id_Raca]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Alergia] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(50) NOT NULL,
    [AdotanteIdAdotante] int NULL,
    [PessoaId] int NULL,
    CONSTRAINT [PK_Alergia] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Alergia_Adotante_AdotanteIdAdotante] FOREIGN KEY ([AdotanteIdAdotante]) REFERENCES [Adotante] ([IdAdotante]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Alergia_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [idx_adotante_cpf] ON [Adotante] ([Cpf]);
GO

CREATE INDEX [idx_adotante_nome] ON [Adotante] ([Nome]);
GO

CREATE INDEX [idx_id_adotante] ON [Adotante] ([IdAdotante]);
GO

CREATE INDEX [IX_Adotante_EnderecoId_Endereco] ON [Adotante] ([EnderecoId_Endereco]);
GO

CREATE INDEX [idx_id_alergia] ON [Alergia] ([Id]);
GO

CREATE INDEX [IX_Alergia_AdotanteIdAdotante] ON [Alergia] ([AdotanteIdAdotante]);
GO

CREATE INDEX [IX_Alergia_PessoaId] ON [Alergia] ([PessoaId]);
GO

CREATE UNIQUE INDEX [idx_Animal_ID] ON [Animal] ([Id_Animal]);
GO

CREATE INDEX [IX_Animal_RacaId_Raca] ON [Animal] ([RacaId_Raca]);
GO

CREATE INDEX [idx_cidade] ON [Endereco] ([Cidade]);
GO

CREATE INDEX [idx_estado] ON [Endereco] ([Estado]);
GO

CREATE INDEX [idx_Animal_ID] ON [Endereco] ([Id_Endereco]);
GO

CREATE INDEX [idx_nome_especie] ON [Especie] ([Nome]);
GO

CREATE INDEX [idx_cpf_pessoa] ON [Pessoa] ([Cpf]);
GO

CREATE INDEX [idx_id_pessoa] ON [Pessoa] ([Id]);
GO

CREATE INDEX [idx_nome_pessoa] ON [Pessoa] ([Nome]);
GO

CREATE INDEX [IX_Pessoa_EnderecoId_Endereco] ON [Pessoa] ([EnderecoId_Endereco]);
GO

CREATE INDEX [idx_id_raca] ON [Raca] ([Id_Raca]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210918164322_FirstMigration', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Adotante] DROP CONSTRAINT [FK_Adotante_Endereco_EnderecoId_Endereco];
GO

ALTER TABLE [Alergia] DROP CONSTRAINT [FK_Alergia_Adotante_AdotanteIdAdotante];
GO

ALTER TABLE [Alergia] DROP CONSTRAINT [FK_Alergia_Pessoa_PessoaId];
GO

ALTER TABLE [Animal] DROP CONSTRAINT [FK_Animal_Especie_Id_Animal];
GO

ALTER TABLE [Animal] DROP CONSTRAINT [FK_Animal_Raca_RacaId_Raca];
GO

ALTER TABLE [Pessoa] DROP CONSTRAINT [FK_Pessoa_Endereco_EnderecoId_Endereco];
GO

DROP INDEX [idx_Animal_ID] ON [Animal];
GO

EXEC sp_rename N'[Raca].[Id_Raca]', N'Raca_ID', N'COLUMN';
GO

EXEC sp_rename N'[Pessoa].[EnderecoId_Endereco]', N'Endereco_ID', N'COLUMN';
GO

EXEC sp_rename N'[Pessoa].[Id]', N'Pessoa_ID', N'COLUMN';
GO

EXEC sp_rename N'[Pessoa].[IX_Pessoa_EnderecoId_Endereco]', N'IX_Pessoa_Endereco_ID', N'INDEX';
GO

EXEC sp_rename N'[Especie].[Id_Especie]', N'Especie_ID', N'COLUMN';
GO

EXEC sp_rename N'[Endereco].[Id_Endereco]', N'Endereco_ID', N'COLUMN';
GO

EXEC sp_rename N'[Animal].[RacaId_Raca]', N'Raca_ID', N'COLUMN';
GO

EXEC sp_rename N'[Animal].[Id_Animal]', N'Animal_ID', N'COLUMN';
GO

EXEC sp_rename N'[Animal].[IX_Animal_RacaId_Raca]', N'IX_Animal_Raca_ID', N'INDEX';
GO

EXEC sp_rename N'[Alergia].[PessoaId]', N'Pessoa_ID', N'COLUMN';
GO

EXEC sp_rename N'[Alergia].[AdotanteIdAdotante]', N'Adotante_ID', N'COLUMN';
GO

EXEC sp_rename N'[Alergia].[Id]', N'Alergia_ID', N'COLUMN';
GO

EXEC sp_rename N'[Alergia].[IX_Alergia_PessoaId]', N'IX_Alergia_Pessoa_ID', N'INDEX';
GO

EXEC sp_rename N'[Alergia].[IX_Alergia_AdotanteIdAdotante]', N'IX_Alergia_Adotante_ID', N'INDEX';
GO

EXEC sp_rename N'[Adotante].[EnderecoId_Endereco]', N'Endereco_ID', N'COLUMN';
GO

EXEC sp_rename N'[Adotante].[IdAdotante]', N'Adotante_ID', N'COLUMN';
GO

EXEC sp_rename N'[Adotante].[IX_Adotante_EnderecoId_Endereco]', N'IX_Adotante_Endereco_ID', N'INDEX';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Animal]') AND [c].[name] = N'Animal_ID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Animal] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Animal] DROP COLUMN [Animal_ID];
GO

ALTER TABLE [Animal] ADD [Animal_ID] int NOT NULL IDENTITY;
GO

ALTER TABLE [Animal] ADD [Especie_ID] int NULL;
GO

CREATE INDEX [idx_Animal_ID] ON [Animal] ([Animal_ID]);
GO

CREATE INDEX [IX_Animal_Especie_ID] ON [Animal] ([Especie_ID]);
GO

ALTER TABLE [Adotante] ADD CONSTRAINT [FK_Adotante_Endereco_Endereco_ID] FOREIGN KEY ([Endereco_ID]) REFERENCES [Endereco] ([Endereco_ID]) ON DELETE NO ACTION;
GO

ALTER TABLE [Alergia] ADD CONSTRAINT [FK_Alergia_Adotante_Adotante_ID] FOREIGN KEY ([Adotante_ID]) REFERENCES [Adotante] ([Adotante_ID]) ON DELETE NO ACTION;
GO

ALTER TABLE [Alergia] ADD CONSTRAINT [FK_Alergia_Pessoa_Pessoa_ID] FOREIGN KEY ([Pessoa_ID]) REFERENCES [Pessoa] ([Pessoa_ID]) ON DELETE NO ACTION;
GO

ALTER TABLE [Animal] ADD CONSTRAINT [FK_Animal_Especie_Especie_ID] FOREIGN KEY ([Especie_ID]) REFERENCES [Especie] ([Especie_ID]) ON DELETE NO ACTION;
GO

ALTER TABLE [Animal] ADD CONSTRAINT [FK_Animal_Raca_Raca_ID] FOREIGN KEY ([Raca_ID]) REFERENCES [Raca] ([Raca_ID]) ON DELETE NO ACTION;
GO

ALTER TABLE [Pessoa] ADD CONSTRAINT [FK_Pessoa_Endereco_Endereco_ID] FOREIGN KEY ([Endereco_ID]) REFERENCES [Endereco] ([Endereco_ID]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210919140544_SecondMigration', N'5.0.9');
GO

COMMIT;
GO

