using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.employeedetails.core.DBOs
{
    [Table("EmployeeInfo1")]
    public class EmployeeInfo
    {
        [Key]
        public long EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Dept { get; set; }
        public string SubDept { get; set; }
        public string DOB { get; set; }
        public string Role { get; set; }
    }
}
