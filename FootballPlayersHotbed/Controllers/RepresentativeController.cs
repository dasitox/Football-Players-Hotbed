using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FootballPlayersHotbed.DAO;
using FootballPlayersHotbed.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballPlayersHotbed.Controllers
{
    [Route("api/representatives")]
    [ApiController]
    public class RepresentativeController : ControllerBase
    {
        IDbContextFootballPlayersHotbed _representativeRepository;
        public RepresentativeController(IDbContextFootballPlayersHotbed representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetRepresentatives()
        {
            var Representatives = await _representativeRepository.GetRepresentatives();
            var ViewRepresentative = Mapper.Map<IEnumerable<RepresentativeDTO>>(Representatives);
            return Ok(ViewRepresentative);
        }

        [HttpGet("{RepresentativeID}")]
        public async Task<IActionResult> GetRepresentative(int RepresentativeID)
        {
            var Representative = await _representativeRepository.GetRepresentative(RepresentativeID);
            var ViewRepresentative = Mapper.Map<RepresentativeDTO>(Representative);
            return Ok(ViewRepresentative);
        }



    }
}