using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingLeague.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    // Define the controller for handling HTTP requests related to bowlers
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        // Declare the BowlingContext which interacts with the database
        private readonly BowlingContext _context;

        // Constructor to inject the BowlingContext dependency
        public BowlersController(BowlingContext context)
        {
            _context = context;
        }

        // GET: api/bowlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
        {
            // Fetch the bowlers who are in the Marlins or Sharks teams
            // We also ensure that the related Team data is included for each bowler
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)  // Include related Team entity data
                .Where(b => b.Team != null && (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) // Filter by TeamName (Marlins or Sharks)
                .Select(b => new
                {
                    b.BowlerID,
                    // Handle null values by providing default values
                    BowlerFirstName = b.BowlerFirstName ?? "N/A",   
                    BowlerMiddleInit = b.BowlerMiddleInit ?? "N/A", 
                    BowlerLastName = b.BowlerLastName ?? "N/A",     
                    BowlerAddress = b.BowlerAddress ?? "N/A",       
                    BowlerCity = b.BowlerCity ?? "N/A",             
                    BowlerState = b.BowlerState ?? "N/A",           
                    BowlerZip = b.BowlerZip ?? "N/A",               
                    BowlerPhoneNumber = b.BowlerPhoneNumber ?? "N/A", 
                    b.TeamID,
                    b.Team.TeamName  // Include the TeamName in the result
                })
                .ToListAsync();  // Execute the query and return the result as a list

            // Check if no bowlers were found and return a not found response
            if (!bowlers.Any())
            {
                return NotFound("No bowlers found for the Marlins or Sharks teams.");
            }

            // Return the list of bowlers with the required fields as a successful response
            return Ok(bowlers);
        }
    }
}
