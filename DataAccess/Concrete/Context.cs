using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-9NPFMUJ;database=CoreBlogDb;integrated security=true;");
        }
    }
}
