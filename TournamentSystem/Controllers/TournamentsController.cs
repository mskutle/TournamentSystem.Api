using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Controllers
{
   [Route("api/[controller]")]
    public class TournamentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TournamentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tournaments = await _unitOfWork.Tournaments.GetAllAsync();
            return Ok(tournaments);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var tournament = await _unitOfWork.Tournaments.GetAsync(id);

            if (tournament == null)
                return NotFound();

            return Ok(tournament);
        }

        [Route("{id}/teams")]
        public async Task<IActionResult> GetTeams(int id)
        {
            var tournament = await _unitOfWork.Tournaments.GetAsync(id);

            if (tournament == null)
                return NotFound();

            var teams = _unitOfWork.Tournaments.GetTeamsParticipatingIn(tournament);
            return Ok(teams);
        }

        [HttpPost]
        [Route("{tournamentId}/teams")]
        public async Task<IActionResult> AddTeamToTournament([FromBody] Team team, int tournamentId)
        {
            var t = _unitOfWork.Tournaments.Get(tournamentId);
            var tournament = await _unitOfWork.Tournaments.AddTeamToTournament(team, t);

            return Ok(tournament);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tournament tournament)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _unitOfWork.Tournaments.AddAsync(tournament);
            _unitOfWork.Commit();

            return CreatedAtAction("Get", new { id = tournament.Id }, tournament);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Tournament tournament)
        {
            var entity = _unitOfWork.Tournaments.Get(tournament.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _unitOfWork.Tournaments.Remove(entity);
            _unitOfWork.Commit();

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}