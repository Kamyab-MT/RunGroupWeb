using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data.Enum;
using RunGroupsWeb.Models;
using System;

namespace RunGroupsWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Race> Races { get; set; }

    }
}
