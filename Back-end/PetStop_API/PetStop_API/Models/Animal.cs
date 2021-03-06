using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Animal
    {
        public int id_animal { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        [Required]
        public int id_raca { get; set; }

        [JsonIgnore]
        public Raca Raca { get; set; }

        [Required]
        public List<Imagem> Imagens { get; set; }

        [Required]
        public int id_doador { get; set; }

        [JsonIgnore]
        public Doador Doador { get; set; }

        [Required]
        public int id_porte { get; set; }

        [JsonIgnore]
        public Porte Porte { get; set; }
    }
}