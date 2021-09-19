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

