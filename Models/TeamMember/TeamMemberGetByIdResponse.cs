﻿namespace RescueTeam.Models.TeamMember
{
    public class TeamMemberGetByIdResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
