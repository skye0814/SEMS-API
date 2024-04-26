using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ModelExtensions
    {
        public static void MapEvent(this Event dbRecord, Event record)
        {
            dbRecord.Id = record.Id;
            dbRecord.Name = record.Name;
            dbRecord.Description = record.Description;
            dbRecord.StartDate = record.StartDate;
            dbRecord.EndDate = record.EndDate;
            dbRecord.Location = record.Location;
            dbRecord.SportId = record.SportId;
        }

        public static void MapTeam(this Team dbRecord, Team record)
        {
            dbRecord.Id = record.Id;
            dbRecord.TeamName = record.TeamName;
            dbRecord.EventId = record.EventId;
            dbRecord.TeamLogoId = record.TeamLogoId;
        }
    }
}
