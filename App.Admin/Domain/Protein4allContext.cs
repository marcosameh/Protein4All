using App.Admin.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Admin.Models
{
    public partial class Protein4AllContext : IdentityDbContext<ApplicationUser>
    {
        public override DbSet<ApplicationUser> Users { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<ApplicationUser>();
     
            entity.Property(e => e.Photo)
           .IsRequired(false);



            base.OnModelCreating(modelBuilder);


        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
