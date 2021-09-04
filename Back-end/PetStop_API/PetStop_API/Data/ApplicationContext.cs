using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Data
{
    public class ApplicationContext : DbContext
    {
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
