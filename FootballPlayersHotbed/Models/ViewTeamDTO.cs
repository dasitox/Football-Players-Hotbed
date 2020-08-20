using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayersHotbed.Models
{
    public class ViewTeamDTO
    {
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public string NickNameTeam { get; set; }
        public int? RegisteredPlayers { get; set; }
        public int TeamID { get; set; }
    }
}
