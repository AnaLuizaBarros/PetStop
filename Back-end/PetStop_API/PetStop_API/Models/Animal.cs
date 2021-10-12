using System.ComponentModel.DataAnnotations.Schema;

namespace PetStop_API.Models
{
    public class Animal
    {
        public int id_animal { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        public Especie Especie { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string imagem { get; set; }

        public Doador Doador { get; set; }
        public Porte Porte { get; set; }
    }
}