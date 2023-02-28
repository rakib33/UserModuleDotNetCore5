﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementCore.BAL.Services;
using UserManagementCore.Models;
using UserManagementCore.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using UserManagementCore.Filters;

namespace UserManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationRoleController : ControllerBase
    {
        private readonly ApplicationRoleService _ApplicationRoleService;
        private readonly ILogger<ApplicationRoleController> _logger;
        public ApplicationRoleController(ApplicationRoleService ApplicationRoleService, ILogger<ApplicationRoleController> logger)
        {
            _ApplicationRoleService = ApplicationRoleService;
            _logger = logger;
        }

        /// <summary>
        /// api/ApplicationRole 
        /// api/ApplicationRole/RoleList
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpGet("RoleList")]
        [ResponseCache(Duration =60)] //60 sec
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(MyActionFilters))]
        public async Task<ActionResult<List<ApplicationRole>>> Get()
        {
            //try
            //{
                throw new ApplicationException();
                _logger.LogInformation("[ApplicationRole]-> Get event fire.");
                return Ok(new { title = AppVariable.SuccessStatus, data = await _ApplicationRoleService.GetRoleList() });

            //}
            //catch (Exception ex)
            //{
            //    return Ok(new { title = AppVariable.ErrorStatus,data= ex });
            //}

        }

        /// <summary>
        /// api/ApplicationRole/1 [just put the id no ]
        /// api/ApplicationRole/RoleById/1
        /// ApplicationRole/RoleByName/1 [Id is 0 and roleName has 1]
        /// api/ApplicationRole/1/Admin [url: Id = 1 roleName = Admin]
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
       // [HttpGet("{Id:int}")]      
        [HttpGet("{Id}")]
        [HttpGet("RoleById/{Id}")]
        [HttpGet("RoleByName/{roleName}")]
        [HttpGet("{Id:int}/{roleName}")]
        [ResponseCache(Duration = 60)] //60 sec
        public async Task<ActionResult<ApplicationRole>> Get(string Id, string roleName)
        {
            try
            {
                _logger.LogInformation("[ApplicationRole]-> Get event fire.");
                var _data = await _ApplicationRoleService.GetRole(Id, roleName);
                if (_data != null)
                    return Ok(new { title = AppVariable.SuccessStatus, data = await _ApplicationRoleService.GetRoleList() });
                else
                    return NotFound();
                #region NotFound
                //{
                //    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                //     "title": "Not Found",
                //      "status": 404,
                //       "traceId": "00-404448690cd7664ea8dd217d33dfc8f1-cd89ab2c1878894f-00"
                //}
                #endregion
            }
            catch (Exception ex)
            {
                return Ok(new { title = AppVariable.ErrorStatus, data = ex });
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] ApplicationRole applicationRole)
        {
            #region ModelValidationWithout[ApiController]
            //[ApiController] attribute manage this ModelState validation
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //JsonResult of return BadRequest is:
            //{
            //    "errors": {
            //        "AllAccess": [
            //            "The AllAccess field is required."
            //        ],
            //        "Description": [
            //            "The Description field is required."
            //        ]
            //  },
            // "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            //"title": "One or more validation errors occurred.",
            //"status": 400,
            //"traceId": "00-6649cf20523b8e429c1cef9cc260dc2e-7bd846c1e274eb44-00"
            //}
            #endregion

            try
            {
                _logger.LogInformation("[ApplicationRole]-> Get event fire.");
                return Ok(new { title = AppVariable.SuccessStatus, data = applicationRole });

            }
            catch (Exception ex)
            {
                return Ok(new { title = AppVariable.ErrorStatus, data = ex });
            }
            return null;
        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
