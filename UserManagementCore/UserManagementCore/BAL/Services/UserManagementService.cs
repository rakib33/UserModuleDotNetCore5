﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementCore.Common;
using UserManagementCore.Models;

namespace UserManagementCore.BAL.Services
{
    //https://stackoverflow.com/questions/59608828/how-to-add-user-to-role-using-userid-and-roleid-of-asp-net-core-identity
    public class UserManagementService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagementService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreateRolesandUsers()
        {

            bool x = await _roleManager.RoleExistsAsync(AppVariable.Role_Admin);
            if (!x)
            {
                // first we create Admin role   
                var role = new ApplicationRole();
                role.Name = AppVariable.Role_Admin;
                await _roleManager.CreateAsync(role);
            }
            //Then we create a user 
            var user = new ApplicationUser();
            user.UserName = "default";
            user.Email = "default@default.com";
            string userPWD = "122@Xsdf";

            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "Admin");
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetUserList()
        {
             var Users = await  _userManager.Users.Include(u => u.UserRoles).ToListAsync();
            return Users;
            //var userList = await (from user in _userManager.Users
            //                      select new
            //                      {
            //                          UserId = user.Id,
            //                          Username = user.UserName,
            //                          user.Email,
            //                          user.EmailConfirmed,
            //                          RoleNames = (from userRole in user.UserRoles //[AspNetUserRoles]
            //                                       join role in _roleManager.Roles //[AspNetRoles]//
            //                                       on userRole.RoleId
            //                                       equals role.Id
            //                                       select role.Name).ToList()
            //                      }).ToListAsync();

            //var userListVm = userList.Select(p => new AccountViewModel
            //{
            //    UserId = p.UserId,
            //    UserName = p.Username,
            //    Email = p.Email,
            //    Roles = string.Join(",", p.RoleNames),
            //    EmailConfirmed = p.EmailConfirmed.ToString()
            //});

          //  return userList;
        }

    }
}
