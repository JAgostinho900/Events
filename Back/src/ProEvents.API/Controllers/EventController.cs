using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEvents.API.Data;
using ProEvents.API.Models;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {  
        private readonly DataContext _context;
        public EventController(DataContext context){
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return this._context.Events;
        }

        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            return this._context.Events.FirstOrDefault(x => x.EventId == id);
        }

        [HttpPost]
        public IEnumerable<Event> Post()
        {
            return this._context.Events;
        }

        [HttpPut]
        public IEnumerable<Event> Put()
        {
            return this._context.Events;
        }
    }
}
