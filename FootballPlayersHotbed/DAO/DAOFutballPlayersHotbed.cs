using FootballPlayersHotbed.EFModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayersHotbed.DAO
{
    public class DAOFutballPlayersHotbed : IDbContextFootballPlayersHotbed
    {
        private FootballPlayersHotbedContext _context;
        public DAOFutballPlayersHotbed(FootballPlayersHotbedContext context)
        {
            _context = context;
        }

        public async Task AddPlayer(Player newPlayer)
        {
            await _context.AddAsync(newPlayer);
        }

        public void DeletePlayer(Player Player)
        {
            _context.Player.Remove(Player);
        }

        public async Task<Player> GetPlayer(int PlayerID)
        {
            return await _context.Player.FirstAsync(p => p.Id == PlayerID);
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Player.ToListAsync();
        }

        public async Task<Representative> GetRepresentative(int RepresentativeID)
        {
            return await _context.Representative.FirstAsync(r => r.Id == RepresentativeID);
        }

        public async Task<List<Representative>> GetRepresentatives()
        {
            return await _context.Representative.OrderBy(r => r.Surname).ToListAsync();
        }

        public async Task<Team> GetTeam(int TeamId)
        {
            return await _context.Team.Where(p => p.Id == TeamId).FirstAsync();
        }

        public async Task<Team> GetTeamPlayer(int PlayerID)
        {
            return await _context.Team.Where(p => p.PlayerId == PlayerID).FirstAsync();
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Team.OrderBy(r => r.Id).ToListAsync();
        }

        public int MaxIdRegistredInPlayers()
        {
            var res = _context.Player.Max(p => p.Id) + 1;
            return res;
        }

        public int MaxIdRegistredInRepresentatives()
        {
            var res = _context.Representative.Max(p => p.Id) + 1;
            return res;
        }

        public bool PlayerExist(int PlayerID)
        {
            return _context.Player.Any(p => p.Id == PlayerID);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Representative SearchRepresentative(string nameAndSurnameRepresentative)
        {
            var reprePlayer = nameAndSurnameRepresentative.ToLower().Split(" ");
            if (reprePlayer.Count() > 2)
            {
                List<string> names = new List<string>();
                string name, surname = reprePlayer.Last();
                foreach (var values in reprePlayer)
                {
                    names.Add(values);
                }
                names.Remove(surname);
                name = string.Concat(names);
                return _context.Representative
                .Where(r => r.Name.ToLower() == name && r.Surname.ToLower() == surname)
                .FirstOrDefault();
            }
            return _context.Representative
                .Where(r => r.Name.ToLower() == reprePlayer[0] && r.Surname.ToLower() == reprePlayer[1])
                .FirstOrDefault();
        }
    }
}
