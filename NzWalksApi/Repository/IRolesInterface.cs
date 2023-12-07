using NzWalksApi.Models;

namespace NzWalksApi.Repository
{
    public interface IRolesInterface
    {
         Task<List<Roles>> GetAllRoles();
        Task<Roles?> GetEmployeesRoles(int id);
    }
}
