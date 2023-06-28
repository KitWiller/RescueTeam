using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueTeam.DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Coordinates { get; set; }
       
        public ICollection<TeamMember> TeamMembers { get; set; } //relazione 1 a n con teammember



        public Vehicle Trasport { get; set; }
        public int TransportID { get; set; }

    }
}