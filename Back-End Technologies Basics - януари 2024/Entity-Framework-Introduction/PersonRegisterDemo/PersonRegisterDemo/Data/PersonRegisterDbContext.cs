using Microsoft.EntityFrameworkCore;
using PersonRegisterDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegisterDemo.Data
{
    public class PersonRegisterDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Region> Regions { get; set; }

        


        public PersonRegisterDbContext(DbContextOptions options) : base(options) 
        {
             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Region>();
            
        }
    }
}
