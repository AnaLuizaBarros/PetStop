using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Pessoa
    {
        public Pessoa(string nome, string cpf, string nacionalidade)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Nacionalidade = nacionalidade;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Nacionalidade { get; set; }
    }
}
