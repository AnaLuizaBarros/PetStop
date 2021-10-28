using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Alergico
    {
        public int id_alergico { get; set; }

        [Required]
        public int id_alergia { get; set; }

        [JsonIgnore]
        public Alergia Alergia { get; set; }

        [Required]
        public int id_adotante { get; set; }

        [JsonIgnore]
        public Adotante Adotante { get; set; }
    }
}