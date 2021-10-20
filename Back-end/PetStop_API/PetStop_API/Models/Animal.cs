﻿using System.ComponentModel.DataAnnotations;
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

        [JsonIgnore]
        public Especie Especie { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string imagem { get; set; }

        [JsonIgnore]
        public Doador Doador { get; set; }

        [JsonIgnore]
        public Porte Porte { get; set; }
    }
}