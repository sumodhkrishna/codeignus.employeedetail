using AutoMapper;
using codeignus.employeedetails.core.DBOs;
using codeignus.employeedetails.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeiggnus.employeedetail.controllers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeInfoModel, EmployeeInfo>().ReverseMap();
        }
    }
}
