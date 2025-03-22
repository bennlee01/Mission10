using System;

namespace BowlingLeague.Models
{
    // Represents a bowling team in the league
    public class Team
    {
        // Unique identifier for each team
        public int TeamID { get; set; }

        // Name of the team (e.g., Marlins, Sharks)
        public string TeamName { get; set; }

        // Navigation property to access all bowlers in this team
        // This allows us to easily retrieve the list of bowlers who belong to this team
        public ICollection<Bowler> Bowlers { get; set; }
    }
}
