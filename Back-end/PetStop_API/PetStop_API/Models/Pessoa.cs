using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Pessoa
    {
        public Pessoa() { }
        public Pessoa(int id, string nome, int idade, string cpf, DateTime dt_Nascimento, string email, Alergia alergia, Animal animal, Endereco endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;
            this.Dt_Nascimento = dt_Nascimento;
            this.Email = email;
            this.Alergia = alergia;
            this.Animal = animal;
            this.Endereco = endereco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public string Email { get; set; }
        public Animal Animal { get; set; }
        public Endereco Endereco { get; set; }
        public Alergia Alergia { get; set; }
    }
}
