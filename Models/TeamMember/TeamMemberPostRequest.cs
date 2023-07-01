namespace RescueTeam.Models.TeamMember
{
    public class TeamMemberPostRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int CurrentTeamId { get; set; }
    }
}