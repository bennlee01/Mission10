using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingLeagueAPI.Models;

namespace BowlingLeagueAPI.Controllers
{
    // The Route attribute defines the URL pattern for the controller's actions.
    // [controller] is a placeholder that automatically uses the controller's name (Bowlers)
    [Route("api/[controller]")]
    [ApiController] // This attribute enables automatic model validation and other API-related behaviors
    public class BowlersController : ControllerBase
    {
        // Private field to hold the database context (BowlingLeagueContext) for interacting with the database
        private readonly BowlingLeagueContext _context;

        // Constructor that injects the BowlingLeagueContext dependency into the controller
        public BowlersController(BowlingLeagueContext context)
        {
            _context = context; // Storing the context for later use in actions
        }

        // HTTP GET action to retrieve the list of bowlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
        {
            // Querying the database to get bowlers who are in the Marlins or Sharks teams
            var bowlers = await _context.Bowlers
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")  // Filtering by team name
                .Select(b => new  // Projecting each Bowler to a new anonymous object
                {
                    FullName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}",  // Combining first, middle, and last names
                    b.Team.TeamName,  // Team name of the bowler
                    b.BowlerAddress,  // Address of the bowler
                    b.BowlerCity,     // City of the bowler
                    b.BowlerState,    // State of the bowler
                    b.BowlerZip,      // Zip code of the bowler
                    b.BowlerPhoneNumber // Phone number of the bowler
                })
                .ToListAsync();  // Asynchronously execute the query and return the list of bowlers

            return Ok(bowlers);  // Return the bowlers list with a 200 OK status
        }
    }
}