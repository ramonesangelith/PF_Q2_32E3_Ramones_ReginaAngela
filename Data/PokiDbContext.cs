using Microsoft.EntityFrameworkCore;

namespace PokeAPI.Data
{
    public class PokiDbContext : DbContext
    {
        public PokiDbContext(DbContextOptions<PokiDbContext> options)
            : base(options)
        {
        }
    }
}
