using System;
using System.Collections.Generic;

namespace FootballPlayersHotbed.Models
{
    public partial class Player
    {
        public int Id { get; set; }
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
