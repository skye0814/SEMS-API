    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Match
    {
        public int Id { get; set; }

        public int? EventId { get; set; }
        public Event? Event { get; set; }

        public int? TeamId1 { get; set; }
        public int? TeamId2 { get; set;}
        public Team? Team1 { get; set; }
        public Team? Team2 { get; set;}
        public int? Round { get; set; }
        public int? WinnerId { get; set; }
        public Team? Winner { get; set; }

        public DateTime? MatchStartDate { get; set; }
        public string MatchStatus { get; set; } = string.Empty; // NotStarted, InProgress, Finished
    }
}
