using Microsoft.EntityFrameworkCore;

namespace kahoot_api.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<GameInfo> GameInfos { get; set; }
    } 
}