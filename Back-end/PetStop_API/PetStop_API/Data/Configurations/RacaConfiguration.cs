using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data.Configurations
{
    public class RacaConfiguration : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("Raca");
            builder.HasKey(p => p.Raca_ID);
            builder.Property(p => p.Descricao_Raca).HasColumnType("VARCHAR(30)").IsRequired();

            builder.HasIndex(i => i.Raca_ID).HasName("idx_id_raca");
        }
    }
}
