﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStop_API.Models
{
    public class Alergia
    {
        public int id_alergia { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        public Especie Especie { get; set; }
        public List<Alergico> Alergicos { get; set; }
    }
}