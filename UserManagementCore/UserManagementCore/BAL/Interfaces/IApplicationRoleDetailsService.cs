using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementCore.Models;

namespace UserManagementCore.BAL.Interfaces
{
  public  interface IApplicationRoleDetailsService
    {
        public IEnumerable<ApplicationRoleDetails> GetRoleById(int id);
        public IEnumerable<ApplicationRoleDetails> GetAllApplicationRoleDetailss();
        public Task<ApplicationRoleDetails> AddApplicationRoleDetails(ApplicationRoleDetails applicationRoleDetails);
        public bool DeleteApplicationRoleDetails(int id);
        public bool UpdateApplicationRoleDetails(List<ApplicationRoleDetails> DataList);
    }
}
