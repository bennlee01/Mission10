using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingLeagueAPI.Models
{
    public class Bowler
    {
        [Key]
        public int BowlerID { get; set; }
        public string BowlerFirstName { get; set; } = string.Empty;
        public string BowlerMiddleInit { get; set; } = string.Empty;
        public string BowlerLastName { get; set; } = string.Empty;
        public string BowlerAddress { get; set; } = string.Empty;
        public string BowlerCity { get; set; } = string.Empty;
        public string BowlerState { get; set; } = string.Empty;
        public string BowlerZip { get; set; } = string.Empty;
        public string BowlerPhoneNumber { get; set; } = string.Empty;

        public int TeamID { get; set; }
        public Team? Team { get; set; }
    }
}