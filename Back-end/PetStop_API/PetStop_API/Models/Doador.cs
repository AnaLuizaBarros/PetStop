using PetStop_API.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Doador
    {
        public int id_doador { get; set; }

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
        [Column(TypeName = "VARCHAR(14)")]
        public string cpf { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(14)")]
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
        [Column(TypeName = "VARCHAR(10)")]
        public string cep { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string estado { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime dataNascimento { get; set; }

        [JsonIgnore]
        public List<Animal> Animais { get; set; }

        [JsonIgnore]
        public List<Adocao> Adocoes { get; set; }
    }
}