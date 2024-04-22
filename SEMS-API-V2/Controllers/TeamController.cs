using Core.Entities;
using Core.WebModel.Request;
using Core.WebModel.Response;
using Infrastructure.Data;
using Infrastructure.Data.Persistence.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Data;

namespace SEMS_API_V2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class TeamController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public TeamController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("{id}", Name = "GetTeam")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetTeam(int id)
        {
            try
            {
                var Team = repositoryWrapper.Team.GetTeamById(id);

                if (Team == null)
                {
                    return NotFound($"The Team with ID {id} does not exist.");
                }

                return Ok(Team);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AddTeam(Team Team)
        {
            try
            {
                var existingTeamName = repositoryWrapper.Team.GetTeamByName(Team.TeamName);

                if (existingTeamName != null)
                {
                    return BadRequest("Team name already exists");
                }

                await repositoryWrapper.Team.AddTeam(Team);

                return CreatedAtAction("GetTeam", new { id = Team.Id }, Team);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [ProducesResponseType(typeof(Team), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateTeam([FromBody] Team Team)
        {
            try
            {
                if (Team == null)
                {
                    return BadRequest("Team is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbTeam = repositoryWrapper.Team.GetTeamById(Team.Id);

                if (dbTeam == null)
                {
                    return NotFound("Team does not exist.");
                }

                repositoryWrapper.Team.UpdateTeam(dbTeam, Team);

                return CreatedAtAction("GetTeam", new { id = Team.Id }, Team);
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
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                var Team = repositoryWrapper.Team.GetTeamById(id);

                if (Team == null)  
                {
                    return NotFound("The Team you are trying to delete does not exist");
                }

                await repositoryWrapper.Team.DeleteTeam(Team);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Teams(PagedRequest pagedRequest)
        {

            try
            {
                var Teams = repositoryWrapper.Team.GetPagedTeams(pagedRequest);

                var result = new PagedResponse<Team>(
                    pagedRequest.PageNumber,
                    pagedRequest.PageSize,
                    Teams,
                    repositoryWrapper.Team.GetPagedTeamsCount(pagedRequest));

                return Ok(result);
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
                var Teams = repositoryWrapper.Team.GetAllTeams();

                return Ok(Teams);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
