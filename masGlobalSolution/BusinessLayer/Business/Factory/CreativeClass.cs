using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Business.Factory
{
    public class CreativeClass
    {
        public const int Hourly = 1;
        public const int Monthly = 2;

        public static Employees2 Creator(int tipo) {
            switch (tipo) {
                case Hourly:
                    return new HourlySalary();
                case Monthly:
                    return new MonthlySalary();
                default: return null;
            }
        }
    }
}