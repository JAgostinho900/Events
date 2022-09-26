using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain;

namespace ProEvents.Persistence
{
    public interface IEventPersist
    {
        //Events
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);

        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);

        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}