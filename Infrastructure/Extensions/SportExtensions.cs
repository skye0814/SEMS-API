using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class SportExtensions
    {
        public static void Map(this Sport dbRecord, Sport record)
        {
            dbRecord.Id = record.Id;
            dbRecord.Name = record.Name;
        }
    }
}
