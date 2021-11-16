using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStop_API.Models
{
    [NotMapped]
    public class Login
    {
        [Required]
        public int tipo { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string senha { get; set; }

        public string token { get; set; }
    }
}