using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Raca
    {
        public int id_raca { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        [Required]
        public int id_especie { get; set; }

        [JsonIgnore]
        public Especie Especie { get; set; }

        [JsonIgnore]
        public List<Animal> Animais { get; set; }
    }
}