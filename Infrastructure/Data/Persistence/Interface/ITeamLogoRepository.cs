using Core.Entities;
using Core.WebModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Interface
{
    public interface ITeamLogoRepository : IRepositoryBase<TeamLogo>
    {
        IEnumerable<TeamLogo> GetAllTeamLogo();
        TeamLogo? GetTeamLogoById(int id);
    }
}
