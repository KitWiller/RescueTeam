using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueTeam.DAL.Entities
{
    public class TeamMember 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public int? CurrentTeamId { get; set; }
        public Team? Team { get; set; }
    }
}
