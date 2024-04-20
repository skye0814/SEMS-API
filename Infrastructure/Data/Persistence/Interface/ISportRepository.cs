using Core.Entities;
using Core.WebModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Interface
{
    public interface ISportRepository : IRepositoryBase<Sport>
    {
        Task AddSport(Sport sport);
        Task UpdateSport(Sport dbRecord, Sport record);
        Sport GetSportById(int id);
        IEnumerable<Sport> GetAllSports();
        Task DeleteSport(Sport sport);
        IQueryable<Sport> GetPagedSports(PagedRequest request);
        int GetPagedSportsCount(PagedRequest request);
    }
}
