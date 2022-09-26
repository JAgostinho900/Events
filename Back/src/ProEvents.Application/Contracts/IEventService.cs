using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain;

namespace ProEvents.Application.Contracts
{
    public interface IEventService
    {
        Task<Event> AddEvents(Event model);

        Task<Event> UpdateEvent(int id, Event model);

        Task<bool> DeleteEvent(int id);

        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);

        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);

        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}