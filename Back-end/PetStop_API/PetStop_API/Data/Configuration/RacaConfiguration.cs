using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class RacaConfiguration : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.HasKey(x => x.id_raca);
            builder.HasOne(x => x.Especie).WithMany(x => x.Racas).HasForeignKey("id_especie");
        }
    }
}