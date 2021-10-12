﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;

namespace PetStop_API.Data.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.id_animal);
            builder.HasOne(x => x.Especie).WithMany(x => x.Animais).HasForeignKey("id_especie");
            builder.HasOne(x => x.Porte).WithMany(x => x.Animais).HasForeignKey("id_porte");
            builder.HasOne(x => x.Doador).WithMany(x => x.Animais).HasForeignKey("id_doador");
        }
    }
}