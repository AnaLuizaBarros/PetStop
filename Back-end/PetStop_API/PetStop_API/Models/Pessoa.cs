using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Pessoa
    {
        public int Pessoa_ID { get; set; }
        //public int Pessoa_ID2 { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public string Email { get; set; }
        
        #nullable enable
        public Endereco Endereco { get; set; }
        public List<Alergia> Alergia { get; set; }
    }
}
