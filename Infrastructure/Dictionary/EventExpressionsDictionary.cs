using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dictionary
{
    public class EventExpressionsDictionary
    {
        private Dictionary<string, Expression<Func<Event, object>>> dictionary;

        public EventExpressionsDictionary()
        {
            dictionary = new Dictionary<string, Expression<Func<Event, object>>>();
            dictionary.Add("id", x => x.Id);
            dictionary.Add("name", x => x.Name);
            dictionary.Add("startDate", x => x.StartDate);
            dictionary.Add("endDate", x => x.EndDate);
        }

        public Expression<Func<Event, object>> GetValue(string key)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[string.IsNullOrEmpty(key) ? "name" : key];
            else
                return dictionary[string.IsNullOrEmpty(key) ? "name" : "name"];

        }
    }
}
