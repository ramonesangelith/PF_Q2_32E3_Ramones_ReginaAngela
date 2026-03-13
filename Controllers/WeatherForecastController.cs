using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Data;

namespace PokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly PokiDbContext _context;

        public WeatherForecastController(PokiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemon()
        {
            var data = await _context.Database
                .SqlQueryRaw<PokiDTO>("SELECT Id, Name, Height, Weight, Sprite, TrainerId FROM pokemon")
                .ToListAsync();

            return Ok(data);
        }

        public class PokiDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Height { get; set;}
            public double Weight { get; set;}
            public string Sprite { get; set;}
            public int? TrainerId { get; set; }
        }
    }
}
