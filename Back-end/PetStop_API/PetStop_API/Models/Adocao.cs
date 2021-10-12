using PetStop_API.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Adocao
    {
        public int id_adocao { get; set; }

        [Column(TypeName = "DATETIME")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime dataAdocao { get; set; }

        public Doador Doador { get; set; }
        public Adotante Adotante { get; set; }

        [ForeignKey("id_animal")] //deixa isso aqui
        public Animal Animal { get; set; }
    }
}