using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.id_animal);
            builder.HasOne(x => x.Raca).WithMany(x => x.Animais).HasForeignKey(x => x.id_raca);
            builder.HasOne(x => x.Porte).WithMany(x => x.Animais).HasForeignKey(x => x.id_porte);
            builder.HasOne(x => x.Doador).WithMany(x => x.Animais).HasForeignKey(x => x.id_doador);
            builder.HasMany(x => x.Imagens).WithOne(x => x.Animal).HasForeignKey(x => x.id_imagem);
        }
    }
}