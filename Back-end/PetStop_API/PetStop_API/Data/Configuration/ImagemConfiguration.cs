using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class ImagemConfiguration : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.HasKey(x => x.id_imagem);
            builder.HasOne(x => x.Animal).WithMany(x => x.Imagens).HasForeignKey(x => x.id_animal);
        }
    }
}
