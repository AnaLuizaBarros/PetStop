using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Animal
    {
        public Animal() { }
        public Animal(int id_Animal, string nome, Especie especie, Pessoa pessoa)
        {
            this.Id_Animal = id_Animal;
            this.Nome = nome;
            this.Especie = especie;
            this.Pessoa = pessoa;
        }
        public int Id_Animal { get; set; }
        public string Nome { get; set; }
        public Especie Especie { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
