using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.HasKey(x => x.id_especie);
            builder.HasMany(x => x.Racas).WithOne(x => x.Especie);
            builder.HasMany(x => x.Alergias).WithOne(x => x.Especie);
        }
    }
}