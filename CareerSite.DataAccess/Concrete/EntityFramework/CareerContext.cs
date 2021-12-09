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
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=Career;Integrated Security=True");
        }

      /*  public CareerContext(DbContextOptions<CareerContext> options) : base(options)
        {
        }*/
     

        public DbSet<Record> Persons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
