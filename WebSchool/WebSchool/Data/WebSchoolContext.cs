
using WebSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace WebSchool.Data
{
    public class WebSchoolContext : DbContext
    {
        public WebSchoolContext (DbContextOptions<WebSchoolContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().ToTable("MyCustomers");
        //}
    }
}
