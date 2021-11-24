using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Especie
    {
        public int id_especie { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        [JsonIgnore]
        public List<Raca> Racas { get; set; }

        [JsonIgnore]
        public List<Alergia> Alergias { get; set; }
    }
}