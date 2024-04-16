using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dictionary
{
    public class SportExpressionsDictionary
    {
        private Dictionary<string, Expression<Func<Sport, object>>> dictionary;

        public SportExpressionsDictionary()
        {
            dictionary = new Dictionary<string, Expression<Func<Sport, object>>>();
            dictionary.Add("name", x => x.Name);
        }

        public Expression<Func<Sport, object>> GetValue(string key)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[string.IsNullOrEmpty(key) ? "name" : key];
            else
                return dictionary[string.IsNullOrEmpty(key) ? "name" : "name"];

        }
    }
}
