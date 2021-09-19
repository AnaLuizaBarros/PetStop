using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;

namespace PetStop_API.Data.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");
            builder.HasKey(p => p.Animal_ID).HasAnnotation("SqlServer:Identity", "1, 1");
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();

            builder.HasIndex(i => i.Animal_ID).HasDatabaseName("idx_Animal_ID");

            /*builder.HasOne(p => p.Especie)
                .WithOne(p => p.Animal)
                .HasForeignKey<Especie>(c => c.Id_Especie);*/
        }
    }
}
