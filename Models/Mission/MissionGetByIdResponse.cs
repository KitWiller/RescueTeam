namespace RescueTeam.Models.Mission
{
    public class MissionGetByIdResponse
    {
        public int Id { get; set; }
        public string MissionName { get; set; }
        public DateTime MissionStart { get; set; }
        public DateTime MissionEnd { get; set; }
    }
}
