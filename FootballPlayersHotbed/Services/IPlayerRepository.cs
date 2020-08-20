using FootballPlayersHotbed.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballPlayersHotbed.Services
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
        Player GetPlayer(int PlayerID);
        bool Save();
        void DeletePlayer(Player Player);
        Task<Team> GetTeamPlayer(int PlayerID);
        bool PlayerExist(int PlayerID);
        Task<List<Representative>> GetRepresentatives();
        Task<Representative> SearchRepresentative(string nameAndSurnameRepresentative);
        Task AddPlayer(Player newPlayer);
    }
}
