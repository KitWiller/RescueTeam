using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueTeam.DAL.Entities
{
    public class Vehicle    
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NSeats { get; set; }
    }
}