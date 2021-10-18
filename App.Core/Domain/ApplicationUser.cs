using Microsoft.AspNetCore.Identity;
using System;

namespace App.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
      

        [PersonalData]

        public string Photo { get; set; }
    }
}