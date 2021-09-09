using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Raca
    {
        public Raca() { }
        public Raca(int idRaca, string descricaoRaca)
        {
            this.Ir_Raca = idRaca;
            this.Descricao_Raca = descricaoRaca;
        }

        public int Ir_Raca { get; set; }
        public string Descricao_Raca { get; set; }
    }
}
