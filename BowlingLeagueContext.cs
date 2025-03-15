using Microsoft.EntityFrameworkCore;  // Importing EF Core namespaces for working with DbContext

namespace BowlingLeagueAPI.Models
{
    // DbContext class for interacting with the database in EF Core
    public class BowlingLeagueContext : DbContext
    {
        // Constructor that passes options to the base DbContext class (required by EF Core)
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options) : base(options) { }

        // DbSet properties represent the tables in the database. EF Core will map these to the actual tables in the SQLite database.
        
        // Represents the "Bowlers" table in the database
        public DbSet<Bowler> Bowlers { get; set; }

        // Represents the "Teams" table in the database
        public DbSet<Team> Teams { get; set; }
    }
}