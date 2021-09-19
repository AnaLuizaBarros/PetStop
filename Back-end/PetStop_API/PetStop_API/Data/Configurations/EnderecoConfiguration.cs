using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(p => p.Endereco_ID);
            builder.Property(p => p.Rua).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Bairro).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Cidade).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(p => p.Estado).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Sigla).HasColumnType("CHAR(2)").IsRequired();

            builder.HasIndex(i => i.Endereco_ID).HasName("idx_Animal_ID");
            builder.HasIndex(i => i.Cidade).HasName("idx_cidade");
            builder.HasIndex(i => i.Estado).HasName("idx_estado");
        }
    }
}
