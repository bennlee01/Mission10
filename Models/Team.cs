using System.ComponentModel.DataAnnotations;

namespace BowlingLeagueAPI.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; } = string.Empty;

        public ICollection<Bowler>? Bowlers { get; set; }
    }
}