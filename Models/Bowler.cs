using System;

namespace BowlingLeague.Models
{
    // Represents a bowler in the bowling league
    public class Bowler
    {
        // Unique identifier for each bowler
        public int BowlerID { get; set; }

        // First name of the bowler (nullable in case it’s not provided)
        public string? BowlerFirstName { get; set; }

        // Middle initial of the bowler (nullable in case it’s not provided)
        public string? BowlerMiddleInit { get; set; }  

        // Last name of the bowler (nullable in case it’s not provided)
        public string? BowlerLastName { get; set; }   

        // Address of the bowler (nullable in case it’s not provided)
        public string? BowlerAddress { get; set; }    

        // City where the bowler resides (nullable in case it’s not provided)
        public string? BowlerCity { get; set; }       

        // State where the bowler resides (nullable in case it’s not provided)
        public string? BowlerState { get; set; }      

        // Zip code of the bowler’s address (nullable in case it’s not provided)
        public string? BowlerZip { get; set; }        

        // Phone number of the bowler (nullable in case it’s not provided)
        public string? BowlerPhoneNumber { get; set; } 

        // The ID of the team the bowler is associated with (this is a foreign key)
        public int TeamID { get; set; }

        // Navigation property to access the team the bowler belongs to
        public Team Team { get; set; }
    }
}
