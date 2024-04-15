using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; } = string.Empty;


        // Navigation property
        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
