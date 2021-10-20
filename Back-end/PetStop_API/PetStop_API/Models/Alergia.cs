using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Alergia
    {
        public int id_alergia { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        [JsonIgnore]
        public Especie Especie { get; set; }

        [JsonIgnore]
        public List<Alergico> Alergicos { get; set; }
    }
}