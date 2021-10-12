﻿using PetStop_API.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetStop_API.Models
{
    public class Adotante
    {
        [JsonIgnore]
        public int id_adotante { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        [Column(TypeName = "VARCHAR(12)")]
        public string senha { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string email { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        public string cpf { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        public string telefone { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string rua { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        public string numero { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string complemento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string bairro { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string cidade { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        public string cep { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string estado { get; set; }

        [Column(TypeName = "DATETIME")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime dataNascimento { get; set; }

        [JsonIgnore]
        public List<Alergico> Alergias { get; set; }

        [JsonIgnore]
        public List<Adocao> Adocoes { get; set; }
    }
}