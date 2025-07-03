using Microsoft.AspNetCore.Identity;
using System;

namespace TeduCoreApp.Infrastructure.Identity.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
} 