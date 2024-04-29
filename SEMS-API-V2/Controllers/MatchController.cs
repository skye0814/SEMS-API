﻿using Core.Entities;
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

        //[HttpGet]
        //public IActionResult GetMatchRandomSeed(List<Team> teams)
        //{
        //    try
        //    {
        //        var matches = matchService.GenerateMatches(teams);

        //        return Ok(matches);
        //    }
        //    catch (BadRequestException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
    }

}
