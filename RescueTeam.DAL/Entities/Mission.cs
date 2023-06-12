using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueTeam.DAL.Entities
{
    public class Mission    
    {
        public int Id { get; set; }
        public string MissionName { get; set; }
        public DateTime  MissionStart { get; set; }
        public DateTime MissionEnd { get; set; }
    }
}