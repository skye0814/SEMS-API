using Core.Common;
using Core.Entities;
using Core.WebModel.Request;
using Infrastructure.Data.Persistence.Interface;
using Infrastructure.Dictionary;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Repository
{
    public class MatchRepository : RepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task AddMatch(Match Match)
        {
            await CreateAsync(Match);
            await SaveAsync();
        }

        public async Task DeleteMatch(Match Match)
        {
            Delete(Match);
            await SaveAsync();
        }

        public async Task UpdateMatch(Match dbRecord, Match record)
        {
            dbRecord.MapMatch(record);
            Update(dbRecord);
            await SaveAsync();
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return Query()
                .Include(x => x.Event)
                .Include(x => x.Team1)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Team2)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Winner)
                    .ThenInclude(x => x.TeamLogo)
                .ToList();
        }

        public Match? GetMatchById(int id)
        {
            return Query()
                .Include(x => x.Event)
                .Include(x => x.Team1)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Team2)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Winner)
                    .ThenInclude(x => x.TeamLogo)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Match> GetMatchesByEventId(int id)
        {
            return Query()
                .Include(x => x.Event)
                .Include(x => x.Team1)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Team2)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Winner)
                    .ThenInclude(x => x.TeamLogo)
                .Where(x => x.EventId == id)
                .AsEnumerable();
        }

        public IEnumerable<Match> GetMatchesBySportId(int id)
        {
            return Query()
                .Include(x => x.Event)
                .Include(x => x.Team1)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Team2)
                    .ThenInclude(x => x.TeamLogo)
                .Include(x => x.Winner)
                    .ThenInclude(x => x.TeamLogo)
                .Where(x => x.Event.SportId == id)
                .AsEnumerable();
        }

        public async Task AddMatches(IEnumerable<Match> matches)
        {
            await CreateMultipleAsync(matches);
            await SaveAsync();
        }
    }
}
