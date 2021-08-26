using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Animal
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Animal(string Nome, string Data_Nascimento, string Email, string Cep, string Endereco, string Bairro, string Complemento, string Cidade) 
        {
            this.Nome = Nome;
            this.DataNascimento = Data_Nascimento;
            this.Email = Email;
            this.Bairro = Bairro;
            this.Cep = Cep;
            this.Endereco = Endereco;
            this.Complemento = Complemento;
            this.Cidade = Cidade;
        }
    }
}
