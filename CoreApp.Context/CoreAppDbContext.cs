using CoreApp.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Context
{
    public class CoreAppDbContext : DbContext
    { 
        public DbSet<CategoryEntity> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("connection string...");
        }
    }
}
