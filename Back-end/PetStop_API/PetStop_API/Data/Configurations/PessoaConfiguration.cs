using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStop_API.Models;
using System;

namespace PetStop_API.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Adotante>
    {
        public void Configure(EntityTypeBuilder<Adotante> builder)
        {
            throw new NotImplementedException();
        }
    }
}
