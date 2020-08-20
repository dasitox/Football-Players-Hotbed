namespace FootballPlayersHotbed.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public string NickNameTeam { get; set; }
        public int? RegisteredPlayers { get; set; }
        public int? PlayerId { get; set; }
        public int TeamID { get; set; }
    }
}
