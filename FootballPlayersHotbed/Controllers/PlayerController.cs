using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FootballPlayersHotbed.DAO;
using FootballPlayersHotbed.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FootballPlayersHotbed.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IDbContextFootballPlayersHotbed _playerRepository;
        public PlayerController(IDbContextFootballPlayersHotbed playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _playerRepository.GetPlayers();
            var ViewPlayers = Mapper.Map<IEnumerable<ViewPlayerDTO>>(players);
            return Ok(ViewPlayers);
        }

        [HttpGet("{PlayerID}", Name = "GetPlayer")]
        public async Task<IActionResult> GetPlayer(int PlayerID)
        {
            var player = await _playerRepository.GetPlayer(PlayerID);
            var ViewPlayer = Mapper.Map<ViewPlayerDTO>(player);
            return Ok(ViewPlayer);
        }

        [HttpGet("{PlayerID}/representative")]
        public async Task<IActionResult> GetRepresentativePlayer(int PlayerID)
        {
            var player = await _playerRepository.GetPlayer(PlayerID);
            if (player == null) return NotFound();
            var representative = _playerRepository.SearchRepresentative(player.Representative);
            if (representative == null) return NotFound();
            var ViewRepresentative = Mapper.Map<ViewRepresentativeDTO>(representative);
            return Ok(ViewRepresentative);
        }

        [HttpGet("{PlayerID}/team")]
        public async Task<IActionResult> GetTeamPlayer(int PlayerID)
        {
            if (!_playerRepository.PlayerExist(PlayerID)) return NotFound();
            var team = await _playerRepository.GetTeamPlayer(PlayerID);
            if (team == null) return NotFound();
            var ViewTeam = Mapper.Map<ViewTeamDTO>(team);
            return Ok(team);
        }

        [HttpDelete("{PlayerID}")]
        public async Task<IActionResult> DeletePlayer(int PlayerID)
        {
            if (!_playerRepository.PlayerExist(PlayerID)) return NotFound();
            var playerDelete = await _playerRepository.GetPlayer(PlayerID);
            _playerRepository.DeletePlayer(playerDelete);
            if (!_playerRepository.Save()) return BadRequest();
            return NoContent();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateNewPlayerRecord([FromBody] PlayerDTO playerDTO)
        {
            if (playerDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var maximumRegisteredId = _playerRepository.MaxIdRegistredInPlayers();
            var newPlayer = Mapper.Map<EFModels.Player>(playerDTO);
            newPlayer.Id = maximumRegisteredId;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _playerRepository.AddPlayer(newPlayer);
            if (!_playerRepository.Save()) return StatusCode(500, "Please verify your data");
            return CreatedAtRoute("GetPlayer", new { playerId = newPlayer.Id }, playerDTO);
        }

        [HttpPut("{PlayerId}")]
        public async Task<IActionResult> UpdatePlayerData(int PlayerId, [FromBody] PlayerDTO playerUpdateDTO)
        {
            if (playerUpdateDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_playerRepository.PlayerExist(PlayerId)) return BadRequest();
            var playerToUpdate = await _playerRepository.GetPlayer(PlayerId);
            Mapper.Map(playerUpdateDTO,playerToUpdate);
            if (!ModelState.IsValid) return StatusCode(500, "Please verify your data");
            _playerRepository.Save();
            return CreatedAtRoute("GetPlayer", new { PlayerId = PlayerId }, playerToUpdate);
        }

        [HttpPatch("{PlayerId}")]
        public async Task<IActionResult> PatchPlayer(int PlayerId, [FromBody] JsonPatchDocument<PlayerDTO> patchDocument)
        {
            if (patchDocument == null) return BadRequest(ModelState);
            if (!_playerRepository.PlayerExist(PlayerId)) return StatusCode(500, "Player not Exits");
            var playerToPatch = await _playerRepository.GetPlayer(PlayerId);            
            var updatePlayer = Mapper.Map<PlayerDTO>(playerToPatch);
            patchDocument.ApplyTo(updatePlayer, ModelState);
            TryValidateModel(updatePlayer);
            if (!ModelState.IsValid) return BadRequest();
            Mapper.Map(updatePlayer, playerToPatch);
            if (!_playerRepository.Save()) return BadRequest();
            return NoContent();
        }




    }
}