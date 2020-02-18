using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models.Factory
{
    public class HourlySalary : EmployeeSalary
    {
        public override decimal AnualSalary(decimal Salary)
        {
            return Salary * 120 * 12;
        }
    }
}