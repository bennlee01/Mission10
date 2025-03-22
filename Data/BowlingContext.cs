using Microsoft.EntityFrameworkCore;
using BowlingLeague.Models;

public class BowlingContext : DbContext
{
    // Constructor that accepts DbContextOptions for configuring the context
    public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

    // Represents the 'Bowlers' table in the database
    // It allows us to query and interact with the 'Bowlers' data
    public DbSet<Bowler> Bowlers { get; set; }

    // Represents the 'Teams' table in the database
    // It allows us to query and interact with the 'Teams' data
    public DbSet<Team> Teams { get; set; } // Add Teams DbSet to handle teams
}
