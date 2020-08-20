using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayersHotbed.Models
{
    public class RepresentativeDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public int? RegisteredPlayers { get; set; }
        public string RepresentativeRegistration { get; set; }
        public int RepresentativeID { get; set; }
    }
}
