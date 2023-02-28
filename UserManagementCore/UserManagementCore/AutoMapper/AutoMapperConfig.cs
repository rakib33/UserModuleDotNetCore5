using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagementCore.Models;
using UserManagementEntityModel.ViewModel;

namespace UserManagementCore.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ApplicationUser, vm_ApplicationUser>().ReverseMap();           
        }    
    }
}
