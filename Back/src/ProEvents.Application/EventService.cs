using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Application.Contracts;
using ProEvents.Domain;
using ProEvents.Persistence;

namespace ProEvents.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventPersist _eventPersist;
        public EventService(IGeneralPersist generalPersist, IEventPersist eventPersist)
        {
            this._generalPersist = generalPersist;
            this._eventPersist = eventPersist;
        }

        public async Task<Event> AddEvents(Event model)
        {
            try
            {
                _generalPersist.Add<Event>(model);
                if(await _generalPersist.SaveChangesAsync()){
                    return await _eventPersist.GetEventByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> UpdateEvent(int id, Event model)
        {
           try
           {
                var eventEntity = await _eventPersist.GetEventByIdAsync(id,false);
                if(eventEntity == null)
                { 
                    return null ;
                }

                model.Id = eventEntity.Id;
                
                _generalPersist.Update(model);

                if(await _generalPersist.SaveChangesAsync()){
                    return await _eventPersist.GetEventByIdAsync(model.Id);
                }
                return null;
           }
           catch (System.Exception e)
           {
                throw new Exception(e.Message);
           }
        }

        public async Task<bool> DeleteEvent(int id)
        {
            try
           {
                var eventEntity = await _eventPersist.GetEventByIdAsync(id, false);
                if(eventEntity == null)
                { 
                    throw new Exception("Event not found");
                }
                
                _generalPersist.Delete<Event>(eventEntity);
                return await _generalPersist.SaveChangesAsync();
           }
           catch (System.Exception e)
           {
                throw new Exception(e.Message);
           }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsAsync(includeSpeakers);
                if(events == null){
                    return null;
                }

                return events;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if(events == null){
                    return null;
                }

                return events;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetEventByIdAsync(eventId, includeSpeakers);
                if(events == null){
                    return null;
                }

                return events;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}