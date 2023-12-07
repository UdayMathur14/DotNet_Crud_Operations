using Microsoft.EntityFrameworkCore;
using NzWalksApi.Models;

namespace NzWalksApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Departments> Department { get; set; }
        public DbSet<EmployeeDetails> Employee { get; set; }
        public DbSet<Roles> Roles { get; set; }


        



    }
}
