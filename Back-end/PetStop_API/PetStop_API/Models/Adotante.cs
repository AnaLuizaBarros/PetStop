using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Adotante : Pessoa
    {
        public Adotante(int id, string nome, int idade, string cpf, DateTime dt_Nascimento, string email, Animal animal, Alergia alergia, Endereco endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;
            this.Dt_Nascimento = dt_Nascimento;
            this.Email = email;
            this.Animal = animal;
            this.Endereco = endereco;
            this.Alergia = alergia;
        }
    }
}
