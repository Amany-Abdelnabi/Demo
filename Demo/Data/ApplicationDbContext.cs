using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Connecting String
            optionsBuilder.UseSqlServer("Server=DESKTOP-M93O3VJ\\SQLEXPRESS03;Database=Demo;Trusted_Connection=True;TrustServerCertificate=True"
             );

            
        }

    }
}
