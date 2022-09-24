using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.API.Models;

namespace ProEvents.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }

        //For Migrations
        //dotnet ef migrations add [name of migration - ex: initialMigration]
        public DbSet<Event> Events { get; set; }
    }
}