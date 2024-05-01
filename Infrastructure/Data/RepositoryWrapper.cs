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
        private ISportRepository sportRepository;
        private IEventRepository eventRepository;
        private ITeamRepository teamRepository;
        private ITeamLogoRepository logoRepository;
        private IMatchRepository matchRepository;

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

        public ISportRepository Sport
        {
            get
            {
                if (this.sportRepository == null)
                {
                    sportRepository = new SportRepository(repositoryContext);
                }

                return this.sportRepository;
            }
        }

        public IEventRepository Event
        {
            get
            {
                if (this.eventRepository == null)
                {
                    eventRepository = new EventRepository(repositoryContext);
                }

                return this.eventRepository;
            }
        }

        public ITeamRepository Team
        {
            get
            {
                if (this.teamRepository == null)
                {
                    teamRepository = new TeamRepository(repositoryContext);
                }

                return this.teamRepository;
            }
        }

        public ITeamLogoRepository TeamLogo
        {
            get
            {
                if (this.logoRepository == null)
                {
                    logoRepository = new TeamLogoRepository(repositoryContext);
                }

                return this.logoRepository;
            }
        }

        public IMatchRepository Match
        {
            get
            {
                if (this.matchRepository == null)
                {
                    matchRepository = new MatchRepository(repositoryContext);
                }

                return this.matchRepository;
            }
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
