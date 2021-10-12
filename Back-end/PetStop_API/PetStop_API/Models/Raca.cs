using System.ComponentModel.DataAnnotations.Schema;

namespace PetStop_API.Models
{
    public class Raca
    {
        public int id_raca { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string nome { get; set; }

        public Especie Especie { get; set; }
    }
}