using codeignus.employeedetail.provider.DBO;
using codeignus.employeedetails.core.DBOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.employeedetails.core.Interfaces.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly MainContext dbContext;

        public UserProvider(MainContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EmployeeInfo AddUser(EmployeeInfo employeeInfo)
        {
            if (dbContext.EmployeeInfo.Where(e => e.UserName == employeeInfo.UserName).Count() < 1)
            {
                var savedEmployeeInfo = dbContext.EmployeeInfo.Add(employeeInfo);
                dbContext.SaveChanges();
                return savedEmployeeInfo.Entity;
            }
            throw new InvalidOperationException("User name already exists please choose another one");
        }

        public bool DeleteUser(long id)
        {
            var obj = dbContext.EmployeeInfo.Where(e => e.EmployeeId == id).FirstOrDefault();
            dbContext.Remove(obj);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<EmployeeInfo> GetUsers()
        {
            return dbContext.EmployeeInfo.ToList();
        }

        public EmployeeInfo UpdateUser(EmployeeInfo employeeInfo)
        {
            if (dbContext.EmployeeInfo.Where(e => e.UserName == employeeInfo.UserName).Count() < 2)
            {

                var emp = dbContext.EmployeeInfo.Where(e => e.EmployeeId == employeeInfo.EmployeeId).FirstOrDefault();
                emp.Dept = employeeInfo.Dept;
                emp.DOB = employeeInfo.DOB;
                emp.SubDept = employeeInfo.SubDept;
                emp.Password = employeeInfo.Password;
                emp.Role = employeeInfo.Role;
                emp.UserName = employeeInfo.UserName;
                dbContext.SaveChanges();
                return employeeInfo;
            }
            throw new InvalidOperationException("User name already exists please choose another one");
        }
    }
}
