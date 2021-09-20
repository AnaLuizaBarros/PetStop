﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetStop_API.Data;

namespace PetStop_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210918164322_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetStop_API.Models.Adotante", b =>
                {
                    b.Property<int>("IdAdotante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.Property<DateTime>("Dt_Nascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("EnderecoId_Endereco")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAdotante");

                    b.HasIndex("Cpf")
                        .HasDatabaseName("idx_adotante_cpf");

                    b.HasIndex("EnderecoId_Endereco");

                    b.HasIndex("IdAdotante")
                        .HasDatabaseName("idx_id_adotante");

                    b.HasIndex("Nome")
                        .HasDatabaseName("idx_adotante_nome");

                    b.ToTable("Adotante");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdotanteIdAdotante")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdotanteIdAdotante");

                    b.HasIndex("Id")
                        .HasDatabaseName("idx_id_alergia");

                    b.HasIndex("PessoaId");

                    b.ToTable("Alergia");
                });

            modelBuilder.Entity("PetStop_API.Models.Animal", b =>
                {
                    b.Property<int>("Id_Animal")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("RacaId_Raca")
                        .HasColumnType("int");

                    b.HasKey("Id_Animal");

                    b.HasIndex("Id_Animal")
                        .IsUnique()
                        .HasDatabaseName("idx_Animal_ID");

                    b.HasIndex("RacaId_Raca");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("PetStop_API.Models.Endereco", b =>
                {
                    b.Property<int>("Id_Endereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.HasKey("Id_Endereco");

                    b.HasIndex("Cidade")
                        .HasDatabaseName("idx_cidade");

                    b.HasIndex("Estado")
                        .HasDatabaseName("idx_estado");

                    b.HasIndex("Id_Endereco")
                        .HasDatabaseName("idx_Animal_ID");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("PetStop_API.Models.Especie", b =>
                {
                    b.Property<int>("Id_Especie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id_Especie");

                    b.HasIndex("Nome")
                        .HasDatabaseName("idx_nome_especie");

                    b.ToTable("Especie");
                });

            modelBuilder.Entity("PetStop_API.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.Property<DateTime>("Dt_Nascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("EnderecoId_Endereco")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .HasDatabaseName("idx_cpf_pessoa");

                    b.HasIndex("EnderecoId_Endereco");

                    b.HasIndex("Id")
                        .HasDatabaseName("idx_id_pessoa");

                    b.HasIndex("Nome")
                        .HasDatabaseName("idx_nome_pessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("PetStop_API.Models.Raca", b =>
                {
                    b.Property<int>("Id_Raca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao_Raca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id_Raca");

                    b.HasIndex("Id_Raca")
                        .HasDatabaseName("idx_id_raca");

                    b.ToTable("Raca");
                });

            modelBuilder.Entity("PetStop_API.Models.Adotante", b =>
                {
                    b.HasOne("PetStop_API.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId_Endereco");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.HasOne("PetStop_API.Models.Adotante", null)
                        .WithMany("Alergia")
                        .HasForeignKey("AdotanteIdAdotante");

                    b.HasOne("PetStop_API.Models.Pessoa", null)
                        .WithMany("Alergia")
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("PetStop_API.Models.Animal", b =>
                {
                    b.HasOne("PetStop_API.Models.Especie", "Especie")
                        .WithOne("Animal")
                        .HasForeignKey("PetStop_API.Models.Animal", "Id_Animal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStop_API.Models.Raca", "Raca")
                        .WithMany()
                        .HasForeignKey("RacaId_Raca");

                    b.Navigation("Especie");

                    b.Navigation("Raca");
                });

            modelBuilder.Entity("PetStop_API.Models.Pessoa", b =>
                {
                    b.HasOne("PetStop_API.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId_Endereco");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("PetStop_API.Models.Adotante", b =>
                {
                    b.Navigation("Alergia");
                });

            modelBuilder.Entity("PetStop_API.Models.Especie", b =>
                {
                    b.Navigation("Animal")
                        .IsRequired();
                });

            modelBuilder.Entity("PetStop_API.Models.Pessoa", b =>
                {
                    b.Navigation("Alergia");
                });
#pragma warning restore 612, 618
        }
    }
}