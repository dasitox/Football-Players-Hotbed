using FootballPlayersHotbed.Models;
using System.Collections.Generic;

namespace FootballPlayersHotbed_Test.Stubs
{
    class StubsForMock
    {
        public static Player player_1 = new Player()
        {
            Id = 1001,
            Name = "Carlos",
            Surname = "Bebeto",
            Category = 99,
            Club = "F.C. Caracas",
            DominanFood = "Riegh",
            Nationality = "Argentina",
            Representative = "Hernesto Vele"
        };
        public static Player player_2 = new Player()
        {
            Id = 1002,
            Name = "Patricio",
            Surname = "Paz",
            Category = 96,
            Club = "F.C. Caracas",
            DominanFood = "Riegh",
            Nationality = "Argentina",
            Representative = "Hernesto Vele"
        };
        public static List<Player> playersExamples = new List<Player>(){ new Player()
        {
            Id = 1003,
            Name = "Patr",
            Surname = "Piaz",
            Category = 98,
            Club = "F.C. Ccas",
            DominanFood = "Riegh",
            Nationality = "Argentina",
            Representative = "Hernesto Vele" }, new Player()
            {
                Id = 1004,
                Name = "Paio",
                Surname = "Luu",
                Category = 95,
                Club = "F.C. Pato",
                DominanFood = "Riegh",
                Nationality = "Argentina",
                Representative = "Hernesto Vele"
            }
        };

        public static Representative Representative_1 = new Representative()
        {
            Id = 2001,
            Name = "Susan",
            Surname = "Dipal",
            Nationality = "Brasil",
            RegisteredPlayers = 22,
            RepresentativeRegistration = "123123"
        };
        public static List<Representative> representativesExamples = new List<Representative>()
        {
            new Representative()
            {
                Id = 2002,
                Name = "Suan",
                Surname = "Poll",
                Nationality = "Brasil",
                RegisteredPlayers = 22,
                RepresentativeRegistration = "23123"
            }, new Representative()
            {
                Id = 2003,
                Name = "Lao",
                Surname = "Sasa",
                Nationality = "Brasil",
                RegisteredPlayers = 26,
                RepresentativeRegistration = "423423"
            }
        };

        public static Team Team = new Team()
        {
            Id = 10001,
            TeamName = "F.C. Caracas",
            StadiumName = "Caracas Stadium",
            NickNameTeam = "Palos",
            RegisteredPlayers = 29,
            PlayerId = 1001
        };

    }
}
