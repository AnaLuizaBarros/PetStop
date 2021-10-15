using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Models
{
    [NotMapped]
    public class Login
    {
        public int tipo { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
