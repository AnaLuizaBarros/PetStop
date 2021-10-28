using PetStop_API.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Adocao
    {
        public int id_adocao { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime dataAdocao { get; set; }

        [Required]
        public int id_doador { get; set; }

        [JsonIgnore]
        public Doador Doador { get; set; }

        [Required]
        public int id_adotante { get; set; }

        [JsonIgnore]
        public Adotante Adotante { get; set; }

        [Required]
        [NotMapped]
        public int id_animal { get; set; }

        [ForeignKey("id_animal")]
        [JsonIgnore]
        public Animal Animal { get; set; }
    }
}