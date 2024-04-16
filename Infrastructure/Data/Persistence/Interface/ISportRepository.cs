using Core.Entities;
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
        Sport GetSportById(int id);
        IEnumerable<Sport> GetAllSports();
        Task DeleteSport(Sport sport);
    }
}
