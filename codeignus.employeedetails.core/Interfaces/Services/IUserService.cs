using codeignus.employeedetails.core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.employeedetails.core.Interfaces.Services
{
    public interface IUserService
    {
        EmployeeInfoModel CreateUser(EmployeeInfoModel user);
        EmployeeInfoModel Update(EmployeeInfoModel employeeInfoModel);
        List<EmployeeInfoModel> GetUsers();
        bool DeleteUser(long id);
    }
}
