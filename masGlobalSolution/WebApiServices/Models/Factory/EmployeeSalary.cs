using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public abstract class EmployeeSalary
    {
        public abstract decimal AnualSalary(decimal salary);

    }
}