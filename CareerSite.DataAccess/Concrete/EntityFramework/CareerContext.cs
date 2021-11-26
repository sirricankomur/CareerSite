using CareerSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.DataAccess.Concrete.EntityFramework
{
    public class CareerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Career; Trusted_Connection=true");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
