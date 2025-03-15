using System.ComponentModel.DataAnnotations;     // Required for data annotations like [Key]
using System.ComponentModel.DataAnnotations.Schema;  // Required for specifying database schema details

namespace BowlingLeagueAPI.Models
{
    // The Bowler class represents an individual bowler in the bowling league
    public class Bowler
    {
        // Primary key for the Bowler table in the database
        [Key]
        public int BowlerID { get; set; }

        // Bowler's first name, defaults to an empty string if not provided
        public string BowlerFirstName { get; set; } = string.Empty;

        // Bowler's middle initial, defaults to an empty string if not provided
        public string BowlerMiddleInit { get; set; } = string.Empty;

        // Bowler's last name, defaults to an empty string if not provided
        public string BowlerLastName { get; set; } = string.Empty;

        // Bowler's home address, defaults to an empty string if not provided
        public string BowlerAddress { get; set; } = string.Empty;

        // Bowler's city, defaults to an empty string if not provided
        public string BowlerCity { get; set; } = string.Empty;

        // Bowler's state, defaults to an empty string if not provided
        public string BowlerState { get; set; } = string.Empty;

        // Bowler's zip code, defaults to an empty string if not provided
        public string BowlerZip { get; set; } = string.Empty;

        // Bowler's phone number, defaults to an empty string if not provided
        public string BowlerPhoneNumber { get; set; } = string.Empty;

        // Foreign key to associate the Bowler with a Team
        public int TeamID { get; set; }

        // Navigation property to the associated Team. Nullable because a Bowler might not be assigned to a team
        public Team? Team { get; set; }
    }
}