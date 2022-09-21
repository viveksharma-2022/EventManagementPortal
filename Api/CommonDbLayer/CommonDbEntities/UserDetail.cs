using System;
using System.Collections.Generic;

namespace CommonDbLayer.CommonDbEntities
{
    public partial class UserDetail
    {
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public DateTime? Dob { get; set; }
        public string? UserType { get; set; }
    }
}
