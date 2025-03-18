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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
        {
            // Querying the database to get bowlers who are in the Marlins or Sharks teams
            var bowlers = await _context.Bowlers
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    FullName = $"{b.BowlerFirstName ?? ""} {b.BowlerMiddleInit ?? ""} {b.BowlerLastName ?? ""}",
                    b.Team.TeamName,
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber
                })
                .ToListAsync();

            return Ok(bowlers);
        }

    }
}
