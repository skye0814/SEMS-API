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
using System.Diagnostics;

namespace SEMS_API_V2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class TeamLogoController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public TeamLogoController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("{id}", Name = "GetTeamLogo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetTeamLogo(int id)
        {
            try
            {
                var teamLogo = repositoryWrapper.TeamLogo.GetTeamLogoById(id);

                if (teamLogo == null)
                {
                    return NotFound($"The Team Logo with ID {id} does not exist.");
                }

                return Ok(teamLogo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllTeamLogo()
        {

            try
            {
                var teamLogo = repositoryWrapper.TeamLogo.GetAllTeamLogo();

                return Ok(teamLogo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
