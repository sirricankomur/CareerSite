using CareerSite.Core.Configuration;
using CareerSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.DataAccess.EntityFramework
{
    public class CareerContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordItem> RecordItems { get; set; }

        public CareerContext(DbContextOptions options) : base(options)
        {

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=CareerSite;Integrated Security=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CourseCategoryConfiguration());

            modelBuilder.Seed();
        }
    }
}
