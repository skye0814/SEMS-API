using Core.Entities;
using Core.WebModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Interface
{
    public interface IMatchRepository : IRepositoryBase<Match>
    {
        Task AddMatch(Match Match);
        Task AddMatches(IEnumerable<Match> Matches);
        Task UpdateMatch(Match dbRecord, Match record);
        Match? GetMatchById(int id);
        IEnumerable<Match> GetMatchesByEventId(int id);
        IEnumerable<Match> GetMatchesBySportId(int id);
        IEnumerable<Match> GetAllMatches();
        Task DeleteMatch(Match Match);
    }
}
