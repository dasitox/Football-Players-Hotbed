using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayersHotbed.Models
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Category { get; set; }
        public string Club { get; set; }
        public string DominanFood { get; set; }
        public string Nationality { get; set; }
        public string Representative { get; set; }
        public int PlayerID { get; set; }
    }
}
