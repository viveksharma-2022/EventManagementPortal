using System;
using System.Collections.Generic;

namespace CommonDbLayer.CommonDbEntities
{
    public partial class Event
    {
        public long EventId { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public bool? IsRegistered { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? EventDate { get; set; }
        public int? RegistrationCount { get; set; }
    }
}
