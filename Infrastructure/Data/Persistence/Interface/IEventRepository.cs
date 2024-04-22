using Core.Entities;
using Core.WebModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.Interface
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Task AddEvent(Event Event);
        Task UpdateEvent(Event dbRecord, Event record);
        Event GetEventById(int id);
        Event? GetEventByName(string name);
        IEnumerable<Event> GetAllEvents();
        Task DeleteEvent(Event Event);
        IQueryable<Event> GetPagedEvents(PagedRequest request);
        int GetPagedEventsCount(PagedRequest request);
    }
}
