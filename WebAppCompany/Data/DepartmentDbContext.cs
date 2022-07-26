using Microsoft.EntityFrameworkCore;
using WebAppCompany.Models;
namespace WebAppCompany.Data
{
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options)
            : base(options) 
        {
        }

        public DbSet<Department> Departments { get; set; }
    }
}
