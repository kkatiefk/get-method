using Microsoft.AspNetCore.Mvc;
using project.Clients;
using project.Model;

namespace project.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FindController : ControllerBase
    {
        private readonly ILogger<FindController> _logger;

        public FindController(ILogger<FindController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Find> GetFilmDetails(string filmName)
        {
            FilmClients clients = new FilmClients();
            Find find = await clients.GetFilmDetails(filmName);
            return find;
        }
    }
}
