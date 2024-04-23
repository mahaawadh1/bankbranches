using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<BankBranch> BankBranches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
        
    }
}
