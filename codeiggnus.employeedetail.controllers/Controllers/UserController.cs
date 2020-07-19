using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codeignus.employeedetails.core.Interfaces.Services;
using codeignus.employeedetails.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace codeiggnus.employeedetail.controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateUser([FromBody]EmployeeInfoModel employeeInfoModel)
        {
            var obj = this.service.CreateUser(employeeInfoModel);
            return this.Ok(obj);
        }

        [HttpPut]
        public IActionResult Update([FromBody] EmployeeInfoModel employeeInfoModel)
        {
            var obj = this.service.Update(employeeInfoModel);
            return this.Ok(obj);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return this.Ok(this.service.GetUsers());
        }
       
        [HttpDelete]
        public IActionResult DeleteUser([FromQuery]long id)
        {
            return this.Ok(this.service.DeleteUser(id));
        }
    }
}
