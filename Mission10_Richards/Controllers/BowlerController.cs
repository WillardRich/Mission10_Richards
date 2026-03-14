
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Richards.Models;

namespace BowlingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _context;

        public BowlingController(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bowlers = _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    FirstName = b.BowlerFirstName,
                    Middle = b.BowlerMiddleInit,
                    LastName = b.BowlerLastName,
                    Team = b.Team.TeamName,
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    Phone = b.BowlerPhoneNumber
                })
                .ToList();

            return Ok(bowlers);
        }
    }
}