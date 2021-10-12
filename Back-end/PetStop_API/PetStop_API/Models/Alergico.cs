namespace PetStop_API.Models
{
    public class Alergico
    {
        public int id_alergico { get; set; }
        public Alergia Alergia { get; set; }
        public Adotante Adotante { get; set; }
    }
}