using Backend.ModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController, Route("tesztek")]
    public class TesztekController(AppDbContext context) : ControllerBase
    {
        AppDbContext context { get; } = context;

        [HttpGet]
        public IEnumerable<TesztJoinKategoriaDTO> Get() => context
            .Tesztek
            .Join(context.Kategoriak, teszt => teszt.KategoriaId, kategoria => kategoria.Id, (teszt, kategoria) => new TesztJoinKategoriaDTO {
                Id = teszt.Id,
                Kerdes = teszt.Kerdes,
                V1 = teszt.V1,
                V2 = teszt.V2,
                V3 = teszt.V3,
                V4 = teszt.V4,
                Helyes = teszt.Helyes,
                Kategoria = new KategoriaDTO {
                    Id = kategoria.Id,
                    KategoriaNev = kategoria.KategoriaNev
                }
            })
        ;

        [HttpGet("kategoria/{id}")]
        public IEnumerable<TesztJoinKategoriaDTO> Get([FromRoute] int id) => Get()
            .Where(tesztJoinKategoriaDTO => tesztJoinKategoriaDTO.Kategoria.Id == id)
        ;

        public class TesztJoinKategoriaDTO
        {
            public int Id { get; set; }
            public string Kerdes { get; set; }
            public string V1 { get; set; }
            public string V2 { get; set; }
            public string V3 { get; set; }
            public string V4 { get; set; }
            public string Helyes { get; set; }
            public KategoriaDTO Kategoria { get; set; }
        }
    }
}
