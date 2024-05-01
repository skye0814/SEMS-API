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

        public static void MapMatch(this Match dbRecord, Match match)
        {
            dbRecord.Id = match.Id;
            dbRecord.EventId = match.EventId;
            dbRecord.TeamId1 = match.TeamId1;
            dbRecord.TeamId2 = match.TeamId2;
            dbRecord.Team1Score = match.Team1Score;
            dbRecord.Team2Score = match.Team2Score;
            dbRecord.Round = match.Round;
            dbRecord.WinnerId = match.WinnerId;
            dbRecord.MatchStartDate = match.MatchStartDate;
            dbRecord.MatchStatus = match.MatchStatus;
        }
    }
}
