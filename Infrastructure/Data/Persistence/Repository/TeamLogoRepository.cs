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
    public class TeamLogoRepository : RepositoryBase<TeamLogo>, ITeamLogoRepository
    {
        public TeamLogoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<TeamLogo> GetAllTeamLogo()
        {
            return Query().ToList().OrderBy(x => x.Name);
        }

        public TeamLogo? GetTeamLogoById(int id)
        {
            return Query()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
