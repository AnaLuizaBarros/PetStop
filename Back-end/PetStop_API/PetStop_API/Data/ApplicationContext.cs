using Microsoft.EntityFrameworkCore;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Adotante> Adotante { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Informar qual provider se está utilizando (SQL Server/ MySQL, NoSQL ...)
            optionsBuilder.UseSqlServer("Data source=DEV-VICTOR;Initial Catalog=PetStop;Integrated Security=true");
        }
        //Configurando modelo de Dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplica a configuração de todas as IEntityTypeConfiguration<TEntity> instâncias definidas no assembly fornecido.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
