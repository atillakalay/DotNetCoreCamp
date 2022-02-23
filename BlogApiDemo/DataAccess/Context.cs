using BlogApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-9NPFMUJ;database=CoreBlogApiDb;integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
