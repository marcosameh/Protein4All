using Microsoft.AspNetCore.Identity;
using System;

namespace App.Admin.Domain
{
    public class ApplicationUser : IdentityUser
    {
      

        [PersonalData]

        public string Photo { get; set; }
    }
}