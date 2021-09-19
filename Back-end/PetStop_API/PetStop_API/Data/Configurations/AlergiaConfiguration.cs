using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data.Configurations
{
    public class AlergiaConfiguration : IEntityTypeConfiguration<Alergia>
    {
        public void Configure(EntityTypeBuilder<Alergia> builder)
        {
            builder.ToTable("Alergia");
            builder.HasKey(p => p.Alergia_ID);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();

            //Campo de índice
            builder.HasIndex(i => i.Alergia_ID).HasName("idx_id_alergia");

           /* builder.HasMany(p => p.Adotante)
                .WithMany(p => p.Alergia);

            builder.HasMany(p => p.Pessoa)
                .WithMany(p => p.Alergia);*/
        }
    }
}
