using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class AdocaoConfiguration : IEntityTypeConfiguration<Adocao>
    {
        public void Configure(EntityTypeBuilder<Adocao> builder)
        {
            builder.HasKey(x => x.id_adocao);
            builder.HasOne(x => x.Doador).WithMany(x => x.Adocoes).HasForeignKey(x => x.id_doador);
            builder.HasOne(x => x.Adotante).WithMany(x => x.Adocoes).HasForeignKey(x => x.id_adotante);
        }
    }
}