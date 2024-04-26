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
    public class EventController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public EventController(RepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("{id}", Name = "GetEvent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetEvent(int id)
        {
            try
            {
                var Event = repositoryWrapper.Event.GetEventById(id);

                if (Event == null)
                {
                    return NotFound($"The Event with ID {id} does not exist.");
                }

                return Ok(Event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event Event)
        {
            try
            {
                var existingEventName = repositoryWrapper.Event.GetEventByName(Event.Name);

                if (existingEventName != null)
                {
                    return BadRequest("Event name already exists");
                }

                await repositoryWrapper.Event.AddEvent(Event);

                return CreatedAtAction("GetEvent", new { id = Event.Id }, Event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [ProducesResponseType(typeof(Event), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateEvent([FromBody] Event Event)
        {
            try
            {
                if (Event == null)
                {
                    return BadRequest("Event is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbEvent = repositoryWrapper.Event.GetEventById(Event.Id);

                if (dbEvent == null)
                {
                    return NotFound("Event does not exist.");
                }

                repositoryWrapper.Event.UpdateEvent(dbEvent, Event);

                return CreatedAtAction("GetEvent", new { id = Event.Id }, Event);
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
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var Event = repositoryWrapper.Event.GetEventById(id);

                if (Event == null)  
                {
                    return NotFound("The Event you are trying to delete does not exist");
                }

                await repositoryWrapper.Event.DeleteEvent(Event);

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
        public IActionResult Events(PagedRequest pagedRequest)
        {

            try
            {
                var Events = repositoryWrapper.Event.GetPagedEvents(pagedRequest);

                var result = new PagedResponse<Event>(
                    pagedRequest.PageNumber,
                    pagedRequest.PageSize,
                    Events,
                    repositoryWrapper.Event.GetPagedEventsCount(pagedRequest));

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
        public IActionResult GetAllEvents()
        {

            try
            {
                var Events = repositoryWrapper.Event.GetAllEvents();

                return Ok(Events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
