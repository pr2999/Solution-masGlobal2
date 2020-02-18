using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models.Factory
{
    public class CreatorEmployeeSalary
    {
        public const int Hourly = 1;
        public const int Monthly = 2;

       public static EmployeeSalary Factory(int type) {
            switch (type)
            {
                case Hourly:
                    return new HourlySalary();
                case Monthly:
                    return new MonthlySalary();
                default:
                    return null;
            }
        }

    }
}