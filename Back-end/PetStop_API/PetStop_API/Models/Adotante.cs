using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Adotante
    {
        //public int Adotante_ID { get; set; }
        public int Adotante_ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }

        #nullable enable
        public List<Alergia> Alergia { get; set; }
    }
}
