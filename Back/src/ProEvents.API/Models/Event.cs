using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.API.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Local { get; set; }

        public string EventDate { get; set; }

        public string Theme { get; set; }

        public int NumPeople { get; set; }

        public string Batch { get; set; }   

        public string ImageUrl { get; set; }
    }
}