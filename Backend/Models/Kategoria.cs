using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Kategoria
    {
        [Key] public int Id { get; set; }
        [Required] public string KategoriaNev { get; set; }

        public List<Teszt> _Tesztek { get; set; }
    }
}
