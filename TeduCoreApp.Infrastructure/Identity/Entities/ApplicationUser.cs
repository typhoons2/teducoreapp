using Microsoft.AspNetCore.Identity;
using System;
using TeduCoreApp.Domain.Enums;

namespace TeduCoreApp.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public decimal Balance { get; set; }
        public string Avatar { get; set; }
        public Status Status { get; set; }
    }
} 