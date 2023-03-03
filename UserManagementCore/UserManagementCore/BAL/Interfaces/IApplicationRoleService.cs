using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementCore.Models;

namespace UserManagementCore.BAL.Interfaces
{
  public  interface IApplicationRoleService
    {
        public  Task<IEnumerable<ApplicationRole>> GetOnlyRoleList();
        public Task<IEnumerable<ApplicationRole>> GetRoleList();
        public Task<IEnumerable<ApplicationRole>> GetRolesWithDetails();
       public Task<IEnumerable<ApplicationRole>> GetRolesWithUsers();
       public Task<IEnumerable<ApplicationRole>> GetRolesWithClaims();
       public Task<ApplicationRole> GetRole(string roleId, string roleName);

    }
}
