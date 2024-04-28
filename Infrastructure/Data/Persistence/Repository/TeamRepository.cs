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
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task AddTeam(Team Team)
        {
            await CreateAsync(Team);
            await SaveAsync();
        }

        public async Task DeleteTeam(Team Team)
        {
            Delete(Team);
            await SaveAsync();
        }

        public async Task UpdateTeam(Team dbRecord, Team record)
        {
            dbRecord.MapTeam(record);
            Update(dbRecord);
            await SaveAsync();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return Query().Include(x => x.Event).ToList();
        }

        public Team? GetTeamById(int id)
        {
            return Query()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        private Expression<Func<Team, bool>> TeamSearchExpression(PagedRequest request)
        {
            return x => x.TeamName.ToLower().Contains(request.Search.ToLower());
        }

        public IQueryable<Team> GetPagedTeams(PagedRequest request)
        {
            return Query()
                        .Include(x => x.TeamLogo)
                        .Include(x => x.Event)
                        .ThenInclude(x => x.Sport)
                        .Where(TeamSearchExpression(request))
                        .Sort(request.isAscending, x => x.TeamName)
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        public int GetPagedTeamsCount(PagedRequest request)
        {
            return Query()
                .Where(TeamSearchExpression(request))
                .Count();
        }

        public Team? GetTeamByName(string name)
        {
            return Query()
                .Where(x => x.TeamName == name)
                .FirstOrDefault();
        }

        public IEnumerable<Team> GetTeamsByEventId(int id)
        {
            return Query()
                .Include(x => x.TeamLogo)
                .Where(x => x.EventId == id)
                .AsEnumerable();
        }
    }
}
