using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStop_API.Models
{
    public class Especie
    {
        public int id_especie { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        public List<Raca> Racas { get; set; }
        public List<Alergia> Alergias { get; set; }
        public List<Animal> Animais { get; set; }
    }
}