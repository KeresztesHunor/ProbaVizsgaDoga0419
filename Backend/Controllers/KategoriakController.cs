using Backend.ModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController, Route("kategoriak")]
    public class KategoriakController(AppDbContext context) : ControllerBase
    {
        AppDbContext context { get; } = context;

        [HttpGet]
        public IEnumerable<KategoriaDTO> Get() => context
            .Kategoriak
            .ToList()
            .ConvertAll(kategoria => new KategoriaDTO {
                Id = kategoria.Id,
                KategoriaNev = kategoria.KategoriaNev
            })
        ;
    }
}
