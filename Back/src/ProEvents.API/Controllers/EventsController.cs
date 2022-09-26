using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEvents.Application.Contracts;
using ProEvents.Domain;
using ProEvents.Persistence.Contexts;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {  
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService){
            this._eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _eventService.GetAllEventsAsync(true);
                if(events == null){
                    return NotFound("No event found");
                }

                return Ok(events);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error getting events: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var eventEntity = await _eventService.GetEventByIdAsync(id);
                if(eventEntity == null){
                    return NotFound("No event found");
                }

                return Ok(eventEntity);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error getting events: {e.Message}");
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var events = await _eventService.GetAllEventsByThemeAsync(theme);
                if(events == null){
                    return NotFound("No events found by this theme");
                }

                return Ok(events);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error getting events: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var events = await _eventService.AddEvents(model);
                if(events == null){
                    return BadRequest("Error in adding events");
                }

                return Ok(events);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error adding events: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                var events = await _eventService.UpdateEvent(id, model);
                if(events == null){
                    return BadRequest("Error in updating events");
                }

                return Ok(events);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error updating events: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventService.DeleteEvent(id) ? Ok("Deleted") : BadRequest("Error in deleting events");
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting events: {e.Message}");
            }
        }
    }
}
