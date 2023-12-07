using Microsoft.AspNetCore.Mvc;
using NzWalksApi.Data;
using NzWalksApi.Models;
using NzWalksApi.Repository;

namespace NzWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesInterface rolesInterface;

        public RolesController(IRolesInterface rolesInterface)
        {
            this.rolesInterface = rolesInterface;
        }

        [HttpGet]
        public async Task<List<Roles>> GetAllRoles ()
        {
            return await rolesInterface.GetAllRoles();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Roles?> GetRole([FromRoute]int id)
        {
            return await rolesInterface.GetEmployeesRoles(id);
        }
    }
}
