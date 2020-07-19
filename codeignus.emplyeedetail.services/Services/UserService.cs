using AutoMapper;
using codeignus.employeedetails.core.DBOs;
using codeignus.employeedetails.core.Interfaces.Provider;
using codeignus.employeedetails.core.Interfaces.Services;
using codeignus.employeedetails.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.emplyeedetail.services.Services
{
    public class UserService : IUserService
    {
        IUserProvider provider;
        IMapper mapper;

        public UserService(IUserProvider provider, IMapper mapper)
        {
            this.provider = provider;
            this.mapper = mapper;
        }

        public EmployeeInfoModel CreateUser(EmployeeInfoModel user)
        {
            var emp = this.provider.AddUser(mapper.Map<EmployeeInfo>(user));
            return mapper.Map<EmployeeInfoModel>(emp);
        }

        public bool DeleteUser(long id)
        {
            return provider.DeleteUser(id);
        }

        public List<EmployeeInfoModel> GetUsers()
        {
            var employees = this.provider.GetUsers();
            return mapper.Map<List<EmployeeInfoModel>>(employees);
        }

        public EmployeeInfoModel Update(EmployeeInfoModel employeeInfoModel)
        {
            var emp = this.provider.UpdateUser(mapper.Map<EmployeeInfo>(employeeInfoModel));
            return mapper.Map<EmployeeInfoModel>(emp);
        }
    }
}
