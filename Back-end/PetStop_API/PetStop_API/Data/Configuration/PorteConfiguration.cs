using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class PorteConfiguration : IEntityTypeConfiguration<Porte>
    {
        public void Configure(EntityTypeBuilder<Porte> builder)
        {
            builder.HasKey(x => x.id_porte);
            builder.HasMany(x => x.Animais).WithOne(x => x.Porte);
        }
    }
}