using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PetStop_API.Util;

namespace PetStop_API.Models
{
    public class Imagem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_imagem { get; set; }
        /// <summary>
        /// Imagem no formato string de base64
        /// </summary>
        [Required]
        [Column(TypeName = "BLOB")]
        [JsonConverter(typeof(Base64StringJsonConverter))]
        public byte[] imagem { get; set; }
        [Required]
        public int id_animal { get; set; }
        [JsonIgnore]
        public Animal Animal{ get; set; }
    }
}
