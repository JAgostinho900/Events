using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEvents.Domain;

namespace ProEvents.Persistence
{
    public interface ISpeakerPersist
    {
        //Speakers
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);

        Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents);

        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents);
    }
}