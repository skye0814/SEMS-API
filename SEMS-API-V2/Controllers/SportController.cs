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
    public class SportController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public SportController(RepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("{id}", Name = "GetSport")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetSport(int id)
        {
            try
            {
                var sport = repositoryWrapper.Sport.GetSportById(id);

                if (sport == null)
                {
                    return NotFound($"The sport with ID {id} does not exist.");
                }

                return Ok(sport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AddSport(Sport sport)
        {
            try
            {
                await repositoryWrapper.Sport.AddSport(sport);

                return CreatedAtAction("GetSport", new { id = sport.Id }, sport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [ProducesResponseType(typeof(Sport), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateSport([FromBody] Sport sport)
        {
            try
            {
                if (sport == null)
                {
                    return BadRequest("Sport is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbSport = repositoryWrapper.Sport.GetSportById(sport.Id);

                if (dbSport == null)
                {
                    return NotFound("Sport does not exist.");
                }

                repositoryWrapper.Sport.UpdateSport(dbSport, sport);

                return CreatedAtAction("GetSport", new { id = sport.Id }, sport);
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
        public async Task<IActionResult> DeleteSport(int id)
        {
            try
            {
                var sport = repositoryWrapper.Sport.GetSportById(id);

                if (sport == null)  
                {
                    return NotFound("The sport you are trying to delete does not exist");
                }

                await repositoryWrapper.Sport.DeleteSport(sport);

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
        public IActionResult Sports(PagedRequest pagedRequest)
        {

            try
            {
                var sports = repositoryWrapper.Sport.GetPagedSports(pagedRequest);

                var result = new PagedResponse<Sport>(
                    pagedRequest.PageNumber,
                    pagedRequest.PageSize,
                    sports,
                    repositoryWrapper.Sport.GetPagedSportsCount(pagedRequest));

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
        public IActionResult GetAllSports()
        {

            try
            {
                var sports = repositoryWrapper.Sport.GetAllSports();

                return Ok(sports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
