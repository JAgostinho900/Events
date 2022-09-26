using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.Domain
{
    public class Event
    {
        public int Id { get; set; }

        public string Local { get; set; }

        public DateTime? EventDate { get; set; }

        public string Theme { get; set; }

        public int NumPeople { get; set; }   

        public string ImageUrl { get; set; }

        public string PhoneNumber {get; set;}

        public string Email { get; set; }

        public IEnumerable<Batch> Batches { get; set; }

        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }

        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }
    }
}