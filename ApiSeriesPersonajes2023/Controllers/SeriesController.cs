using ApiSeriesPersonajes2023.Models;
using ApiSeriesPersonajes2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriesPersonajes2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            List<Serie> series = this.repo.GetSeries(); 
            return series;
        }

        [HttpGet("{idserie}")]
        public ActionResult<Serie> FindSerie(int idserie)
        {
            Serie serie = this.repo.FindSerie(idserie);
            return serie;
        }

        [HttpGet]
        [Route("[action]/{idserie}")]
        public ActionResult<List<Personaje>> PersonajeSerie(int idserie)
        {
            List<Personaje> personajes = this.repo.GetPersonajeSerie(idserie);
            return (personajes);
        }

    }
}
