using PetStop_API.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Adotante
    {
        public int id_adotante { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(32)")]
        public string senha { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(11)")]
        public string cpf { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(11)")]
        public string telefone { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string rua { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(10)")]
        public string numero { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string complemento { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string bairro { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string cidade { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(8)")]
        public string cep { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string estado { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime dataNascimento { get; set; }

        [JsonIgnore]
        public List<Alergico> Alergias { get; set; }

        [JsonIgnore]
        public List<Adocao> Adocoes { get; set; }
    }
}