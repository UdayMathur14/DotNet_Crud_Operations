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
        public async Task<List<Roles>> GetAllRoles(string ? column , string? word, string? sortby , int pagenumber , int pagesize)
        {
            //filtering
            var employee =  employeeDbContext.Roles.AsQueryable();
            if(string.IsNullOrWhiteSpace(column)==false && string.IsNullOrWhiteSpace(word)==null) { 
                if(column.Equals("RoleName", StringComparison.OrdinalIgnoreCase))
                {
                    employee = employee.Where(x => x.RoleName.Contains(word));
                }
            }

            //sorting , if you want in acending or decending pass another parameter
            if (string.IsNullOrWhiteSpace(sortby) == false)
            {
                if(sortby.Equals("RoleName" , StringComparison.OrdinalIgnoreCase))
                {
                    employee = employee.OrderBy(x => x.RoleName);
                }
            }

            //Pagination
            var SkipResult = (pagenumber-1) * pagesize;

            return await employee.Skip(SkipResult).Take(pagesize).ToListAsync();

            return await employee.ToListAsync();
        }

        public async Task<Roles?> GetEmployeesRoles(int id)
        {
            //related data for this employee
            // var walks = employeeDbContext.Employee.Include("Departments").Include("Roles").ToListAsync();
            // var walks = employeeDbContext.Employee.Include("x=>x.EmployeeId").Include("b;Roles").ToListAsync();

            var emp = await employeeDbContext.Roles.FindAsync(id);
            return emp;
        }
    }
}
