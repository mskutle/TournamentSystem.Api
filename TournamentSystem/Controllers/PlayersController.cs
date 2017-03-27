using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PlayersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Get()
        {
            var players = await _unitOfWork.Players.GetAllAsync();
            return Ok(players);
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var player = await _unitOfWork.Players.GetAsync(id);

            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Persons.AddAsync(player);
            _unitOfWork.Commit();

            return CreatedAtAction("Get", new { id = player.Id }, player);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _unitOfWork.Players.Update(player);

            return Ok(player);
        }
    }
}