using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Endereco
    {
        public Endereco(string rua, int? numero, string bairro, string cidade, string cep, string estado, string sigla)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Estado = estado;
            Sigla = sigla;
        }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Sigla { get; set; }
    }
}
