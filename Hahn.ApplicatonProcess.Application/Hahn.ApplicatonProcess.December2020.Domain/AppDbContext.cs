using Hahn.ApplicatonProcess.December2020.Data;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
