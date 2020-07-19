using codeignus.employeedetails.core.DBOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.employeedetails.core.Interfaces.Provider
{
    public interface IUserProvider
    {
        EmployeeInfo AddUser(EmployeeInfo employeeInfo);
        EmployeeInfo UpdateUser(EmployeeInfo employeeInfo);
        List<EmployeeInfo> GetUsers();
        bool DeleteUser(long id);
    }
}
