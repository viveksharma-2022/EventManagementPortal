using System;
using System.Collections.Generic;

namespace CommonDbLayer.CommonDbEntities
{
    public partial class EventRegister
    {
        public long RegistrationId { get; set; }
        public string? MemberEmailId { get; set; }
        public long? EventId { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
