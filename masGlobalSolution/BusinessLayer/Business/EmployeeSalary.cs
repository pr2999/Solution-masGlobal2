using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Business
{
    public abstract class EmployeeSalary
    {
        public abstract int id { get; set; }
        public abstract string name { get; set; }
        public abstract int roleId { get; set; }
        public abstract string roleName { get; set; }
        public abstract string roleDescription { get; set; }
        public abstract decimal Salary { get; set; }
        public abstract decimal anualSalary();

    }
}