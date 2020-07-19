using codeignus.employeedetails.core.DBOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.employeedetail.provider.DBO
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
    }
}
