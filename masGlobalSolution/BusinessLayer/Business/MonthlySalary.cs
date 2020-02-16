using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Business
{
    class MonthlySalary : EmployeeSalary
    {
        public override int id { get; set; }

        public override string name { get; set; }

        public override string roleDescription { get; set; }

        public override int roleId { get; set; }

        public override string roleName { get; set; }

        public override decimal Salary { get; set; }

        public override decimal anualSalary()
        {
            return this.Salary * 12;
        }
    }
}