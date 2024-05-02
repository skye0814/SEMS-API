using Core.Entities;
using Core.WebModel.Request;
using Core.WebModel.Response;
using Infrastructure.Data;
using Infrastructure.Data.Persistence.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;
using Services.Interface;
using System.Data;

namespace SEMS_API_V2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class MatchController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMatchService matchService;

        public MatchController(RepositoryWrapper repository, IMatchService matchService)
        {
            this.repository = repository;
            this.matchService = matchService;
        }

        [HttpGet("{id}", Name = "GetMatchByEventId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetMatchByEventId(int id)
        {

            try
            {
                var matches = repository.Match.GetMatchesByEventId(id);

                return Ok(matches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AddMatches(List<Match> matches)
        {
            try
            {
                await repository.Match.AddMatches(matches);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            try
            {
                var match = repository.Match.GetMatchById(id);

                if (match == null)
                {
                    return NotFound("The match you are trying to delete does not exist");
                }

                await repository.Match.DeleteMatch(match);


                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public IActionResult UpdateMatches([FromBody] List<Match> matches)
        {
            try
            {
                foreach (var match in matches)
                {
                    var dbMatch = repository.Match.GetMatchById(match.Id);

                    if (dbMatch == null)

                    {
                        return NotFound("Match does not exist.");
                    }

                    repository.Match.UpdateMatch(dbMatch, match);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllTeams()
        {

            try
            {
                var matches = repository.Match.GetAllMatches();

                return Ok(matches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetMatch")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetMatch(int id)
        {
            try
            {
                var match = repository.Match.GetMatchById(id);

                if (match == null)
                {
                    return NotFound($"The Match with ID {id} does not exist.");
                }

                return Ok(match);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
