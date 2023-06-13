namespace RescueTeam.Models.Mission
{
    public class MissionPutRequest
    {
        public string MissionName { get; set; }
        public DateTime MissionStart { get; set; }
        public DateTime MissionEnd { get; set; }
    }
}
