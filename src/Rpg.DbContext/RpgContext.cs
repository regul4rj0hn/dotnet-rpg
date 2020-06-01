namespace Rpg.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Rpg.DbContext.Models;

    public class RpgContext : DbContext
    {
        public RpgContext(DbContextOptions<RpgContext> options) : base(options) { }

        public DbSet<Character> Character { get; set; }
    }
}
