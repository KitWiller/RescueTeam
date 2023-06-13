using RescueTeam.DAL.Entities;

namespace RescueTeam.Models.Team
{
    public class TeamPostRequest
    {
        public string TeamName { get; set; }
        public Vehicle Trasport { get; set; }
        public int Coordinates { get; set; }
        public List<DAL.Entities.TeamMember> Squad { get; set; }
    }
}
