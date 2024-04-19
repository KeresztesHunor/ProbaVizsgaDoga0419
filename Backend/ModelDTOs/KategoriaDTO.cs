using System.ComponentModel.DataAnnotations;

namespace Backend.ModelDTOs
{
    public class KategoriaDTO
    {
        public int? Id { get; set; }
        [Required] public string KategoriaNev { get; set; }
    }
}
