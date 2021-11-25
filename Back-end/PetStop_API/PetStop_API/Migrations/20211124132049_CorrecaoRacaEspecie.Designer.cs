﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetStop_API.Data;

namespace PetStop_API.Migrations
{
    [DbContext(typeof(PetStopContext))]
    [Migration("20211124132049_CorrecaoRacaEspecie")]
    partial class CorrecaoRacaEspecie
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("id_adotante")
                        .HasColumnType("int");

                    b.Property<int>("id_animal")
                        .HasColumnType("int");

                    b.Property<int>("id_doador")
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
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("VARCHAR(8)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("complemento")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("dataNascimento")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("DATETIME");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.HasKey("id_adotante");

                    b.ToTable("Adotante");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.Property<int>("id_alergia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("id_especie")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
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

                    b.Property<int>("id_adotante")
                        .HasColumnType("int");

                    b.Property<int>("id_alergia")
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

                    b.Property<int>("id_doador")
                        .HasColumnType("int");

                    b.Property<int>("id_porte")
                        .HasColumnType("int");

                    b.Property<int>("id_raca")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_animal");

                    b.HasIndex("id_doador");

                    b.HasIndex("id_porte");

                    b.HasIndex("id_raca");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("PetStop_API.Models.Doador", b =>
                {
                    b.Property<int>("id_doador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("VARCHAR(8)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("complemento")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.HasKey("id_doador");

                    b.ToTable("Doador");
                });

            modelBuilder.Entity("PetStop_API.Models.Especie", b =>
                {
                    b.Property<int>("id_especie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_especie");

                    b.ToTable("Especie");
                });

            modelBuilder.Entity("PetStop_API.Models.Imagem", b =>
                {
                    b.Property<int>("id_imagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("id_animal")
                        .HasColumnType("int");

                    b.Property<byte[]>("imagem")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("id_imagem");

                    b.HasIndex("id_animal");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("PetStop_API.Models.Porte", b =>
                {
                    b.Property<int>("id_porte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_porte");

                    b.ToTable("Porte");
                });

            modelBuilder.Entity("PetStop_API.Models.Raca", b =>
                {
                    b.Property<int>("id_raca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("id_especie")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("id_raca");

                    b.HasIndex("id_especie");

                    b.ToTable("Raca");
                });

            modelBuilder.Entity("PetStop_API.Models.Adocao", b =>
                {
                    b.HasOne("PetStop_API.Models.Adotante", "Adotante")
                        .WithMany("Adocoes")
                        .HasForeignKey("id_adotante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStop_API.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("id_animal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStop_API.Models.Doador", "Doador")
                        .WithMany("Adocoes")
                        .HasForeignKey("id_doador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adotante");

                    b.Navigation("Animal");

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergia", b =>
                {
                    b.HasOne("PetStop_API.Models.Especie", "Especie")
                        .WithMany("Alergias")
                        .HasForeignKey("id_especie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("PetStop_API.Models.Alergico", b =>
                {
                    b.HasOne("PetStop_API.Models.Adotante", "Adotante")
                        .WithMany("Alergias")
                        .HasForeignKey("id_adotante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStop_API.Models.Alergia", "Alergia")
                        .WithMany("Alergicos")
                        .HasForeignKey("id_alergia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adotante");

                    b.Navigation("Alergia");
                });

            modelBuilder.Entity("PetStop_API.Models.Animal", b =>
                {
                    b.HasOne("PetStop_API.Models.Doador", "Doador")
                        .WithMany("Animais")
                        .HasForeignKey("id_doador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStop_API.Models.Porte", "Porte")
                        .WithMany("Animais")
                        .HasForeignKey("id_porte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStop_API.Models.Raca", "Raca")
                        .WithMany("Animais")
                        .HasForeignKey("id_raca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doador");

                    b.Navigation("Porte");

                    b.Navigation("Raca");
                });

            modelBuilder.Entity("PetStop_API.Models.Imagem", b =>
                {
                    b.HasOne("PetStop_API.Models.Animal", "Animal")
                        .WithMany("Imagens")
                        .HasForeignKey("id_animal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("PetStop_API.Models.Raca", b =>
                {
                    b.HasOne("PetStop_API.Models.Especie", "Especie")
                        .WithMany("Racas")
                        .HasForeignKey("id_especie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("PetStop_API.Models.Animal", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("PetStop_API.Models.Doador", b =>
                {
                    b.Navigation("Adocoes");

                    b.Navigation("Animais");
                });

            modelBuilder.Entity("PetStop_API.Models.Especie", b =>
                {
                    b.Navigation("Alergias");

                    b.Navigation("Racas");
                });

            modelBuilder.Entity("PetStop_API.Models.Porte", b =>
                {
                    b.Navigation("Animais");
                });

            modelBuilder.Entity("PetStop_API.Models.Raca", b =>
                {
                    b.Navigation("Animais");
                });
#pragma warning restore 612, 618
        }
    }
}