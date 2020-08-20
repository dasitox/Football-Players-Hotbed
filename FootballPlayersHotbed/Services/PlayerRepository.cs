using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPlayersHotbed.Models;

namespace FootballPlayersHotbed.Services
{
    public class PlayerRepository : IPlayerRepository
    {

        private IPlayerRepository _playerRepository;
        public PlayerRepository(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task AddPlayer(Player newPlayer)
        {
            await _playerRepository.AddPlayer(newPlayer);
        }

        public void DeletePlayer(Player Player)
        {
            _playerRepository.DeletePlayer(Player);
        }

        public Player GetPlayer(int PlayerID)
        {
            return _playerRepository.GetPlayer(PlayerID);
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _playerRepository.GetPlayers();
        }

        public async Task<List<Representative>> GetRepresentatives()
        {
            return await _playerRepository.GetRepresentatives();
        }

        public async Task<Team> GetTeamPlayer(int PlayerID)
        {
            return await _playerRepository.GetTeamPlayer(PlayerID);
        }

        public bool PlayerExist(int PlayerID)
        {
            return _playerRepository.PlayerExist(PlayerID);
        }

        public bool Save()
        {
            return _playerRepository.Save();
        }

        public async Task<Representative> SearchRepresentative(string nameAndSurnameRepresentative)
        {
           return await _playerRepository.SearchRepresentative(nameAndSurnameRepresentative);
        }        
    }
}
