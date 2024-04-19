using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Teszt
    {
        [Key] public int Id { get; set; }
        [Required] public string Kerdes { get; set; }
        [Required] public string V1 { get; set; }
        [Required] public string V2 { get; set; }
        [Required] public string V3 { get; set; }
        [Required] public string V4 { get; set; }
        [Required, MaxLength(2)] public string Helyes { get; set; }
        [Required] public int KategoriaId { get; set; }

        [ForeignKey(nameof(KategoriaId))] public Kategoria _Kategoria { get; set; }
    }
}
