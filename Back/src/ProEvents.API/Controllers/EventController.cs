using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEvents.API.Models;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        public IEnumerable<Event> _event = new Event[] {
                new Event(){                   
                    EventId = 1,
                    Theme = "App1",
                    Local = "Entroncamento",
                    Batch = "1º D",
                    NumPeople = 250,
                    EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageUrl = "photo.png"
                },
                new Event(){                   
                    EventId = 2,
                    Theme = "App2",
                    Local = "Entroncamento",
                    Batch = "2º D",
                    NumPeople = 350,
                    EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageUrl = "photo.png"
                }
            };

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return this._event;
        }

        [HttpGet("{id}")]
        public IEnumerable<Event> GetById(int id)
        {
            return this._event.Where(x => x.EventId == id);
        }

        [HttpPost]
        public IEnumerable<Event> Post()
        {
            return this._event;
        }

        [HttpPut]
        public IEnumerable<Event> Put()
        {
            return this._event;
        }
    }
}
