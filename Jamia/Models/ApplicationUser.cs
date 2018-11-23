using Microsoft.AspNetCore.Identity;
using System;

namespace Jamia.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string PhotoURL { get; set; }
        public string BloodGroup { get; set; }
    }
}
