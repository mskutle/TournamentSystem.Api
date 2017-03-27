using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Controllers
{
   [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync();
            return Ok(teams);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _unitOfWork.Teams.GetAsync(id);

            if (team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Teams.AddAsync(team);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction("Get", new {id = team.Id}, team);
        }

        [HttpPost]
        [Route("{teamId}/players")]
        public async Task<IActionResult> AddPlayerToTeam([FromBody] Player player, int teamId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _unitOfWork.Teams.GetAsync(teamId);

            if (team == null)
                return NotFound($"Couldn't find team with id {teamId}");

            _unitOfWork.Teams.AddPlayerToTeam(player, teamId);
            return Ok(team);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Team team)
        {
            var entity = _unitOfWork.Teams.Get(team.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _unitOfWork.Teams.Remove(entity);
            await _unitOfWork.CommitAsync();

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}