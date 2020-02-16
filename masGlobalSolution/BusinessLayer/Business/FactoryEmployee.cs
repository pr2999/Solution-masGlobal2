using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Business
{
    public class FactoryEmployee
    {

        public const int hourlySalary = 1;
        public const int monthlySalary = 2;


        public static decimal GetAnualSalary(int tipo, Employee employee)
        {
            switch (tipo)
            {
                case hourlySalary:
                    HourlySalary hSalary = new HourlySalary();
                    hSalary.Salary = employee.hourlySalary;
                    return hSalary.anualSalary();
                case monthlySalary:
                    MonthlySalary mSalary = new MonthlySalary();
                    mSalary.Salary = employee.hourlySalary;
                    return mSalary.anualSalary();
                default: return 0;
            }
        }


        public static EmployeeSalary CreateEmp(int tipo) {
            switch (tipo)
            {
                case hourlySalary:
                    return new HourlySalary();
                case monthlySalary:
                    return new MonthlySalary();
                default: return null;
            }
        }
    }
}