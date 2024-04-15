using Core.Entities;
using Infrastructure.Data.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Repository
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateApplicationUser(ApplicationUser user)
        {
            await CreateAsync(user);
            await SaveAsync();
        }

        public ApplicationUser? GetApplicationUserById(string Id)
        {
            return Query().Where(x => x.Id == Id)
                .FirstOrDefault();
        }
    }
}
