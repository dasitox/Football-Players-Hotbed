using System;
using System.Collections.Generic;

namespace FootballPlayersHotbed.EFModels
{
    public partial class Representative
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public int? RegisteredPlayers { get; set; }
        public string RepresentativeRegistration { get; set; }
        public int RepresentativeID { get; set; }
    }
}
