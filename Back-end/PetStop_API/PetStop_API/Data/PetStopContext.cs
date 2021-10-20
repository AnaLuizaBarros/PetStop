using Microsoft.EntityFrameworkCore;
using PetStop_API.Models;
using System.Reflection;

namespace PetStop_API.Data
{
    public class PetStopContext : DbContext
    {
        public DbSet<Adotante> Adotante { get; set; }
        public DbSet<Doador> Doador { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Adocao> Adocao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Informar qual provider se está utilizando (SQL Server/ MySQL, NoSQL ...)
            optionsBuilder.UseMySql("Server=lucoliveira.com;Port=3306;Database=lucoli54_petstop;Uid=lucoli54_petstop;Pwd=9_Wct0-1}5#a;", ServerVersion.AutoDetect("Server=lucoliveira.com;Port=3306;Database=lucoli54_petstop;Uid=lucoli54_petstop;Pwd=9_Wct0-1}5#a;"));
        }

        //Configurando modelo de Dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}