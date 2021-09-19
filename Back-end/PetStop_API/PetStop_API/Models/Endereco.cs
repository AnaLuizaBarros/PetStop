using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Endereco
    {
        //public int Endereco_ID2 { get; set; }
        public int Endereco_ID { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Sigla { get; set; }
    }
}
