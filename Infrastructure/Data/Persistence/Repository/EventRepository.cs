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
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task AddEvent(Event Event)
        {
            await CreateAsync(Event);
            await SaveAsync();
        }

        public async Task DeleteEvent(Event Event)
        {
            Delete(Event);
            await SaveAsync();
        }

        public async Task UpdateEvent(Event dbRecord, Event record)
        {
            dbRecord.MapEvent(record);
            Update(dbRecord);
            await SaveAsync();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return FindAll();
        }

        public Event GetEventById(int id)
        {
            return Query()
                .Where(x => x.Id == id)
                .FirstOrDefault()!;
        }

        private Expression<Func<Event, bool>> EventSearchExpression(PagedRequest request)
        {
            return x => x.Name.ToLower().Contains(request.Search.ToLower());
        }

        public IQueryable<Event> GetPagedEvents(PagedRequest request)
        {
            var dictionary = new EventExpressionsDictionary();

            return Query()
                        .Where(EventSearchExpression(request))
                        .Sort(request.isAscending, dictionary.GetValue(request.SortBy))
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        public int GetPagedEventsCount(PagedRequest request)
        {
            return Query()
                .Where(EventSearchExpression(request))
                .Count();
        }
    }
}
