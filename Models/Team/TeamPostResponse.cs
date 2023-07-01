using RescueTeam.DAL.Entities;

namespace RescueTeam.Models.Team
{
    public class TeamPostResponse
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public Vehicle Trasport { get; set; }
        public int Coordinates { get; set; }
        //public List<DAL.Entities.TeamMember> Squad { get; set; }

    }
}
