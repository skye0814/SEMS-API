using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MatchResult
    {
        public int Id { get; set; }

        public int? MatchId { get; set; }
        public Match? Match { get; set; }

        public int Team1Score { get; set; } = 0;
        public int Team2Score { get; set; } = 0;
    }
}
