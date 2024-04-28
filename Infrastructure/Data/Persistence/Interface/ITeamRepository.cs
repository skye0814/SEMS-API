using Core.Entities;
using Core.WebModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Interface
{
    public interface ITeamRepository : IRepositoryBase<Team>
    {
        Task AddTeam(Team Team);
        Task UpdateTeam(Team dbRecord, Team record);
        Team? GetTeamById(int id);
        IEnumerable<Team> GetTeamsByEventId(int id);
        Team? GetTeamByName(string name);
        IEnumerable<Team> GetAllTeams();
        Task DeleteTeam(Team Team);
        IQueryable<Team> GetPagedTeams(PagedRequest request);
        int GetPagedTeamsCount(PagedRequest request);
    }
}
