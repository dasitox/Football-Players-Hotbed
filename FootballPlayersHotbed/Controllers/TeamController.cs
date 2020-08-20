using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FootballPlayersHotbed.DAO;
using FootballPlayersHotbed.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballPlayersHotbed.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        IDbContextFootballPlayersHotbed _teamRepository;
        public TeamController(IDbContextFootballPlayersHotbed teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTeams()
        {
            var Teams = await _teamRepository.GetTeams();
            var ViewTeams = Mapper.Map<IEnumerable<TeamDTO>>(Teams);
            return Ok(ViewTeams);
        }

        [HttpGet("{TeamID}")]
        public async Task<IActionResult> GetTeam(int TeamID)
        {
            var Team = await _teamRepository.GetTeam(TeamID);
            var ViewTeam = Mapper.Map<TeamDTO>(Team);
            return Ok(ViewTeam);
        }
    }
}