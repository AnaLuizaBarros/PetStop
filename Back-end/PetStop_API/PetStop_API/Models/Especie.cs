using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Especie
    {
        public Especie(int id_Especie, string nome, Raca raca)
        {
            this.Id_Especie = id_Especie;
            this.Nome = nome;
            this.raca = raca;
        }

        public int Id_Especie { get; set; }
        public string Nome { get; set; }
        public Raca raca { get; set; }
    }
}
