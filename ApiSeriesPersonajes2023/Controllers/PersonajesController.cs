using ApiSeriesPersonajes2023.Models;
using ApiSeriesPersonajes2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriesPersonajes2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;

        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            List<Personaje> personajes = this.repo.GetPersonajes();
            return personajes;
        }

        [HttpGet("{idpersonaje}")]
        public ActionResult<Personaje> FindPersonaje(int idpersonaje)
        {
            Personaje personaje = this.repo.FindPersonaje(idpersonaje);
            return personaje;
        }

        [HttpPut]
        [Route("[action]/{idpersonaje}/{idserie}")]
        public async Task<ActionResult> UpdatePersonajeSerie(int idpersonaje, int idserie) 
        {
            await this.repo.UpdatePersonajeSerie(idpersonaje, idserie);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CrearPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
            
    }
}
