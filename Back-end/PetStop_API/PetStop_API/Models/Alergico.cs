using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Alergico
    {
        public int id_alergico { get; set; }

        [JsonIgnore]
        public Alergia Alergia { get; set; }

        [JsonIgnore]
        public Adotante Adotante { get; set; }
    }
}