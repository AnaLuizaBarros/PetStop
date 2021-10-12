using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class AlergicoConfiguration : IEntityTypeConfiguration<Alergico>
    {
        public void Configure(EntityTypeBuilder<Alergico> builder)
        {
            builder.HasKey(x => x.id_alergico);
            builder.HasOne(x => x.Alergia).WithMany(x => x.Alergicos).HasForeignKey("id_alergia");
            builder.HasOne(x => x.Adotante).WithMany(x => x.Alergias).HasForeignKey("id_adotante");
        }
    }
}