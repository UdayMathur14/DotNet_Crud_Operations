using Microsoft.EntityFrameworkCore;
using NzWalksApi.Models;

namespace NzWalksApi.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions) 
        {
            
        }

        public DbSet<Departments> Department { get; set; }
        public DbSet<EmployeeDetails> Employee { get; set; }
        public DbSet<Roles> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var EmployeefEEDdATA = new List<EmployeeDetails>()
            {
                new EmployeeDetails()
                {
                    FirstName = "hemendra",
                    LastName = "singh",
                    DepartmentID = 2,
                    RoleId = new Roles
                    {
                        RoleName = "baatechodo"
                    },
                    DepId = new Departments()
                    {
                        DepartmentName = "Support"
                    },
                    BirthDay = new DateTime(2002, 12, 2),
                    Salary = 0


                }
            };
            modelBuilder.Entity<Employee>().HasData(EmployeefEEDdATA);
        }   
        

    }
}
