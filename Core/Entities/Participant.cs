using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public decimal HeightInCm { get; set; } 
        public decimal WeightInKg { get; set; }


        // navprop
        public int? TeamId { get; set; }
        public Team? Team { get; set; }


    }
}
