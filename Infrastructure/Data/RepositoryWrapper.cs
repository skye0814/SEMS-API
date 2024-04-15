using Infrastructure.Data.Persistence.Interface;
using Infrastructure.Data.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext repositoryContext;
        private IApplicationUserRepository applicationUserRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext) 
        {
            this.repositoryContext = repositoryContext;
        }

        public IApplicationUserRepository ApplicationUser
        {
            get
            {
                if (this.applicationUserRepository == null)
                {
                    applicationUserRepository = new ApplicationUserRepository(repositoryContext);
                }

                return this.applicationUserRepository;
            }
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
