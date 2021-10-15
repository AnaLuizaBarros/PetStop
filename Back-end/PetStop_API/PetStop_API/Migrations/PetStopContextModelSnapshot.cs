﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetStop_API.Data;

namespace PetStop_API.Migrations
{
    [DbContext(typeof(PetStopContext))]
    partial class PetStopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("PetStop_API.Models.Adocao", b =>
                {
                    b.Property<int>("id_adocao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dataAdocao")
                        .HasColumnType("DATETIME");

                    b.Property<int?>("id_adotante")
                        .HasColumnType("int");

                    b.Property<int?>("id_animal")
                        .HasColumnType("int");

                    b.Property<int?>("id_doador")
                        .HasColumnType("int");

                    b.HasKey("id_adocao");

                    b.HasIndex("id_adotante");

                    b.HasIndex("id_animal");

                    b.HasIndex("id_doador");

                    b.ToTable("Adocao");
                });

            modelBuilder.Entity("PetStop_API.Models.Adotante", b =>
                {
                    b.Property<int>("id_adotante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("cep")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("cidade")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("complemento")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("cpf")
                        .HasColumnType("VARCHAR(14)");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("email")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("estado")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("numero")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("rua")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("senha")
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("telefone")
                        .HasColumnType("VARCHAR(14)");

                    b.HasKey("id_adotante");

                    b.ToTable("Adotante");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.Property<int>("id_alergia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("id_especie")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_alergia");

                    b.HasIndex("id_especie");

                    b.ToTable("Alergia");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergico", b =>
                {
                    b.Property<int>("id_alergico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("id_adotante")
                        .HasColumnType("int");

                    b.Property<int?>("id_alergia")
                        .HasColumnType("int");

                    b.HasKey("id_alergico");

                    b.HasIndex("id_adotante");

                    b.HasIndex("id_alergia");

                    b.ToTable("Alergico");
                });

            modelBuilder.Entity("PetStop_API.Models.Animal", b =>
                {
                    b.Property<int>("id_animal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("id_doador")
                        .HasColumnType("int");

                    b.Property<int?>("id_especie")
                        .HasColumnType("int");

                    b.Property<int?>("id_porte")
                        .HasColumnType("int");

                    b.Property<string>("imagem")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_animal");

                    b.HasIndex("id_doador");

                    b.HasIndex("id_especie");

                    b.HasIndex("id_porte");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("PetStop_API.Models.Doador", b =>
                {
                    b.Property<int>("id_doador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("cep")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("cidade")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("complemento")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("cpf")
                        .HasColumnType("VARCHAR(14)");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("email")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("estado")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("numero")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("rua")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("senha")
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("telefone")
                        .HasColumnType("VARCHAR(14)");

                    b.HasKey("id_doador");

                    b.ToTable("Doador");
                });

            modelBuilder.Entity("PetStop_API.Models.Especie", b =>
                {
                    b.Property<int>("id_especie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_especie");

                    b.ToTable("Especie");
                });

            modelBuilder.Entity("PetStop_API.Models.Porte", b =>
                {
                    b.Property<int>("id_porte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_porte");

                    b.ToTable("Porte");
                });

            modelBuilder.Entity("PetStop_API.Models.Raca", b =>
                {
                    b.Property<int>("id_raca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("id_especie")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_raca");

                    b.HasIndex("id_especie");

                    b.ToTable("Raca");
                });

            modelBuilder.Entity("PetStop_API.Models.Adocao", b =>
                {
                    b.HasOne("PetStop_API.Models.Adotante", "Adotante")
                        .WithMany("Adocoes")
                        .HasForeignKey("id_adotante");

                    b.HasOne("PetStop_API.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("id_animal");

                    b.HasOne("PetStop_API.Models.Doador", "Doador")
                        .WithMany("Adocoes")
                        .HasForeignKey("id_doador");

                    b.Navigation("Adotante");

                    b.Navigation("Animal");

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.HasOne("PetStop_API.Models.Especie", "Especie")
                        .WithMany("Alergias")
                        .HasForeignKey("id_especie");

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergico", b =>
                {
                    b.HasOne("PetStop_API.Models.Adotante", "Adotante")
                        .WithMany("Alergias")
                        .HasForeignKey("id_adotante");

                    b.HasOne("PetStop_API.Models.Alergia", "Alergia")
                        .WithMany("Alergicos")
                        .HasForeignKey("id_alergia");

                    b.Navigation("Adotante");

                    b.Navigation("Alergia");
                });

            modelBuilder.Entity("PetStop_API.Models.Animal", b =>
                {
                    b.HasOne("PetStop_API.Models.Doador", "Doador")
                        .WithMany("Animais")
                        .HasForeignKey("id_doador");

                    b.HasOne("PetStop_API.Models.Especie", "Especie")
                        .WithMany("Animais")
                        .HasForeignKey("id_especie");

                    b.HasOne("PetStop_API.Models.Porte", "Porte")
                        .WithMany("Animais")
                        .HasForeignKey("id_porte");

                    b.Navigation("Doador");

                    b.Navigation("Especie");

                    b.Navigation("Porte");
                });

            modelBuilder.Entity("PetStop_API.Models.Raca", b =>
                {
                    b.HasOne("PetStop_API.Models.Especie", "Especie")
                        .WithMany("Racas")
                        .HasForeignKey("id_especie");

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("PetStop_API.Models.Adotante", b =>
                {
                    b.Navigation("Adocoes");

                    b.Navigation("Alergias");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.Navigation("Alergicos");
                });

            modelBuilder.Entity("PetStop_API.Models.Doador", b =>
                {
                    b.Navigation("Adocoes");

                    b.Navigation("Animais");
                });

            modelBuilder.Entity("PetStop_API.Models.Especie", b =>
                {
                    b.Navigation("Alergias");

                    b.Navigation("Animais");

                    b.Navigation("Racas");
                });

            modelBuilder.Entity("PetStop_API.Models.Porte", b =>
                {
                    b.Navigation("Animais");
                });
#pragma warning restore 612, 618
        }
    }
}
