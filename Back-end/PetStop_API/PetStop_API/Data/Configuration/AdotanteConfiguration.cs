using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class AdotanteConfiguration : IEntityTypeConfiguration<Adotante>
    {
        public void Configure(EntityTypeBuilder<Adotante> builder)
        {
            builder.HasKey(x => x.id_adotante);
            builder.HasMany(x => x.Adocoes).WithOne(x => x.Adotante);
            builder.HasMany(x => x.Alergias).WithOne(x => x.Adotante);
        }
    }
}