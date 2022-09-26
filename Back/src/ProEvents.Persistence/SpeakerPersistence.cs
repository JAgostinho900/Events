using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;
using ProEvents.Persistence.Contexts;

namespace ProEvents.Persistence
{
    public class SpeakerPersistence : ISpeakerPersist
    {
        private readonly ProEventContext _context;
        public SpeakerPersistence(ProEventContext context){
            this._context = context;

            //TO avoid error of tracking id
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
            .Include(e => e.SocialNetworks);

            if(includeEvents){
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents)
        {
            //Persistence of Events, in other words, populate foreign keys
            IQueryable<Speaker> query = _context.Speakers
            .Include(e => e.SocialNetworks);

            //Associative class
            if(includeEvents){
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
            .Include(e => e.SocialNetworks);

            if(includeEvents){
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}