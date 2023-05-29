namespace RescueTeam.Models.TeamMember
{
    public class TeamMemberPutRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}