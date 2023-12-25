using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data.Enum;
using RunGroupsWeb.Models;
using System;

namespace RunGroupsWeb.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Race> Races { get; set; }

    }
}
