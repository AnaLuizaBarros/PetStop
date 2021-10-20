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

        [JsonIgnore]
        public Doador Doador { get; set; }

        [JsonIgnore]
        public Adotante Adotante { get; set; }

        [ForeignKey("id_animal")] //deixa isso aqui
        [JsonIgnore]
        public Animal Animal { get; set; }
    }
}