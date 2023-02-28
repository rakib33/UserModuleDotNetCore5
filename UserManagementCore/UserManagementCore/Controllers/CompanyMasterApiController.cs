using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementCore.Models;

namespace UserManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyMasterApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompanyMasterApiController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
