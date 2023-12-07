using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Models;

namespace NzWalksApi.Repository
{
    public class SqlIntactRoles :IRolesInterface
    {
        private readonly EmployeeDbContext employeeDbContext;

        public SqlIntactRoles(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }
        public async Task<List<Roles>> GetAllRoles()
        {
            var employee = await employeeDbContext.Roles.ToListAsync();
            return employee;
        }

        public async Task<Roles?> GetEmployeesRoles(int id)
        {
            var emp = await employeeDbContext.Roles.FindAsync(id);
            return emp;
        }
    }
}
