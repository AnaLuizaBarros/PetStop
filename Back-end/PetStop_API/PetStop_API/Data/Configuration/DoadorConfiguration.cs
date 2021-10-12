using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class DoadorConfiguration : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder.HasKey(x => x.id_doador);
            builder.HasMany(x => x.Animais).WithOne(x => x.Doador);
            builder.HasMany(x => x.Adocoes).WithOne(x => x.Doador);
        }
    }
}