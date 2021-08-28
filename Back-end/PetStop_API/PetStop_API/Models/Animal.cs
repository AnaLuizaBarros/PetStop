using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Animal
    {
        public Animal() { }

        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }

        public Animal(string nome, string dtNascimento, string email, string cep, string endereco, string bairro, string complemento, string cidade)
        {
            this.Nome = nome;
            this.DataNascimento = dtNascimento;
            this.Email = email;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Complemento = complemento;
            this.Cidade = cidade;
        }
    }
}
