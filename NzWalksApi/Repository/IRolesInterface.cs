using NzWalksApi.Models;

namespace NzWalksApi.Repository
{
    public interface IRolesInterface
    {
         Task<List<Roles>> GetAllRoles(string? column , string? word , string? sortby , int pagenumber , int pagesize);
        Task<Roles?> GetEmployeesRoles(int id);
    }
}
