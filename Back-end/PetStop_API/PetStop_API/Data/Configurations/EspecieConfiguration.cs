using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data.Configurations
{
    public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.ToTable("Especie");
            builder.HasKey(p => p.Especie_ID);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(20)").IsRequired();

            builder.HasIndex(i => i.Nome).HasName("idx_nome_especie");

            /*builder.HasOne(p => p.Animal)
                .WithOne(p => p.Especie)
                .HasForeignKey<Animal>(c => c.Id_Animal);*/
        }
    }
}
