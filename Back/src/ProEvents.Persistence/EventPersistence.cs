using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;
using ProEvents.Persistence.Contexts;

namespace ProEvents.Persistence
{
    public class EventPersistence : IEventPersist
    {
        private readonly ProEventContext _context;
        public EventPersistence(ProEventContext context){
            this._context = context;
            
            //TO avoid error of tracking id
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialNetworks);

            if(includeSpeakers){
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            //Persistence of Events, in other words, populate foreign keys
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialNetworks);

            //Associative class
            if(includeSpeakers){
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialNetworks);

            if(includeSpeakers){
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}