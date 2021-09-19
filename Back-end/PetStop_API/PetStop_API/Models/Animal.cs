using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    public class Animal
    {
        //public int Animal_ID2 { get; set; }
        public int Animal_ID { get; set; }
        public string Nome { get; set; }

        #nullable enable
        public Especie Especie { get; set; }
        public Raca Raca { get; set; }
    }
}
