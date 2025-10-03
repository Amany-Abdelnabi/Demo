using Demo.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
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
        ///Changes  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                       new Product { Id = 32, Description = "default", Name = "amany" }

                );
                modelBuilder.Entity<Category>().HasData
                (
                       new Product { Id = 33, Description = "default", Name = "Ahmed" }

                );


        }











    }
}
