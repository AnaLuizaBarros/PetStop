using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data.Configurations
{
    public class AdotanteConfiguration : IEntityTypeConfiguration<Adotante>
    {
        public void Configure(EntityTypeBuilder<Adotante> builder)
        {
            builder.ToTable("Adotante");
            builder.HasKey(p => p.Adotante_ID);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Cpf).HasColumnType("VARCHAR(15)").IsRequired();
            builder.Property(p => p.Idade).HasColumnType("INT").IsRequired();
            builder.Property(p => p.Dt_Nascimento).HasColumnType("DATETIME");
            builder.Property(p => p.Email).HasColumnType("VARCHAR(30)").IsRequired();


            //Criando campo de índice.
            builder.HasIndex(i => i.Adotante_ID).HasDatabaseName("idx_id_adotante");
            builder.HasIndex(i => i.Cpf).HasDatabaseName("idx_adotante_cpf");
            builder.HasIndex(i => i.Nome).HasDatabaseName("idx_adotante_nome");

            //Construindo relação
            /*builder.HasMany(p => p.Animais)
                .WithOne(p => p.Adotante)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
