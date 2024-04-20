using Core.Common;
using Core.Entities;
using Core.WebModel.Request;
using Infrastructure.Data.Persistence.Interface;
using Infrastructure.Dictionary;
using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Repository
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepository
    {
        public SportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task AddSport(Sport sport)
        {
            await CreateAsync(sport);
            await SaveAsync();
        }

        public async Task DeleteSport(Sport sport)
        {
            Delete(sport);
            await SaveAsync();
        }

        public async Task UpdateSport(Sport dbRecord, Sport record)
        {
            dbRecord.Map(record);
            Update(dbRecord);
            await SaveAsync();
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return FindAll();
        }

        public Sport GetSportById(int id)
        {
            return Query()
                .Where(x => x.Id == id)
                .FirstOrDefault()!;

            //if (sport == null)
            //{
            //    return new Result<Sport>("Sport with ID " + id + " not found.");
            //}

               //return new Result<Sport>(sport);
        }

        private Expression<Func<Sport, bool>> SportSearchExpression(PagedRequest request)
        {
            return x => x.Name.ToLower().Contains(request.Search.ToLower());
        }

        public IQueryable<Sport> GetPagedSports(PagedRequest request)
        {
            var dictionary = new SportExpressionsDictionary();

            return Query()
                        .Where(SportSearchExpression(request))
                        .Sort(request.isAscending, dictionary.GetValue(request.SortBy))
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        public int GetPagedSportsCount(PagedRequest request)
        {
            return Query()
                .Where(SportSearchExpression(request))
                .Count();
        }
    }
}
