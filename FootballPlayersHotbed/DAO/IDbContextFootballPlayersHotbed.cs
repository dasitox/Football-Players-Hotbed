using FootballPlayersHotbed.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayersHotbed.DAO
{
    public interface IDbContextFootballPlayersHotbed
    {
        Task<List<Player>> GetPlayers();
        Task<Player> GetPlayer(int PlayerID);
        Task AddPlayer(Player newPlayer);
        bool Save();
        void DeletePlayer(Player Player);
        Task<Team> GetTeamPlayer(int PlayerID);
        bool PlayerExist(int PlayerID);
        Task<List<Representative>> GetRepresentatives();
        Representative SearchRepresentative(string nameAndSurnameRepresentative);
        int MaxIdRegistredInPlayers();
        int MaxIdRegistredInRepresentatives();
        Task<Representative> GetRepresentative(int RepresentativeID);
        Task<List<Team>> GetTeams();
        Task<Team> GetTeam(int TeamId);

    }
}
