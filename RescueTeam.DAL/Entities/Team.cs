using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueTeam.DAL.Entities
{
    public class Team
    {
        public string TeamName { get; set; }
        public Vehicle Trasport { get; set; }
        public int Coordinates { get; set; }
        public List<TeamMember> Squad { get; set; }
    }
}