using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;

namespace PetStop_API.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(p => p.Pessoa_ID);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("VARCHAR(15)").IsRequired();
            builder.Property(p => p.Cpf).HasColumnType("VARCHAR(15)").IsRequired();
            builder.Property(p => p.Dt_Nascimento).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(p => p.Idade).HasColumnType("INT").IsRequired();

            builder.HasIndex(i => i.Pessoa_ID).HasName("idx_id_pessoa");
            builder.HasIndex(i => i.Nome).HasName("idx_nome_pessoa");
            builder.HasIndex(i => i.Cpf).HasName("idx_cpf_pessoa");
        }
    }
}
