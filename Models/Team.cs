using System.ComponentModel.DataAnnotations;  // Required for data annotations like [Key]

// Namespace containing the Team model
namespace BowlingLeagueAPI.Models
{
    // The Team class represents a team in the bowling league
    public class Team
    {
        // Primary key for the Team table in the database
        [Key]
        public int TeamID { get; set; }

        // Name of the team, must be provided, defaults to an empty string if not set
        public string TeamName { get; set; } = string.Empty;

        // A collection of Bowlers associated with this Team
        // The '?' indicates that the collection may be null (nullable)
        public ICollection<Bowler>? Bowlers { get; set; }
    }
}