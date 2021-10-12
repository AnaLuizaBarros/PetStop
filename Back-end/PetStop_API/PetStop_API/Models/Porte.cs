using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStop_API.Models
{
    public class Porte
    {
        public int id_porte { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        public List<Animal> Animais { get; set; }
    }
}