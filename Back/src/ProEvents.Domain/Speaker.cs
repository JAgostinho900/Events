using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public string CV { get; set; }
    
        public string ImageUrl { get; set; }
    
        public string PhoneNumber { get; set; }
   
        public string Email { get; set; }
    
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
    
        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }
    }

}