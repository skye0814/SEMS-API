using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Persistence.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

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

        [HttpGet("{id}", Name = "GetSportById")]
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

        [HttpPost]
        public async Task<IActionResult> AddSport(Sport sport)
        {
            try
            {
                await repositoryWrapper.Sport.AddSport(sport);

                return CreatedAtAction("GetSportById", new { id = sport.Id }, sport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteProduct(int id)
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
    }
}
