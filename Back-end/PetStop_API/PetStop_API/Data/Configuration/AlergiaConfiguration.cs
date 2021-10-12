using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class AlergiaConfiguration : IEntityTypeConfiguration<Alergia>
    {
        public void Configure(EntityTypeBuilder<Alergia> builder)
        {
            builder.HasKey(x => x.id_alergia);
            builder.HasOne(x => x.Especie).WithMany(x => x.Alergias).HasForeignKey("id_especie");
            builder.HasMany(x => x.Alergicos).WithOne(x => x.Alergia);
        }
    }
}