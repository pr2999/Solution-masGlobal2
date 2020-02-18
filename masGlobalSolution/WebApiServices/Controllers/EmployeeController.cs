using DataLayer.Models;
using DataLayer.Repository;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiServices.Models;
using WebApiServices.Models.Factory;

namespace WebApiServices.Controllers
{
    public class EmployeeController : ApiController
    {

        EmployeesApi DLayer = new EmployeesApi();


        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var list = DLayer.GetEmployees().ToList();
            List<Employee> employees = GetAnualSalary(list);
            return employees;
        }

        [HttpGet]
        public Employee Get(int id)
        {
            var list = DLayer.GetEmployees().ToList();
            Employee employee = list.FirstOrDefault(x => x.id == id);
            employee.anualySalary = GetAnualSalary(employee);
            return employee;
        }

        private decimal GetAnualSalary(Employee employee)
        {
            EmployeeSalary employeSalary;
            if (employee.contractTypeName == "HourlySalaryEmployee")
            {
                employeSalary = CreatorEmployeeSalary.Factory(CreatorEmployeeSalary.Hourly);
                return employeSalary.AnualSalary(employee.hourlySalary);
            }
            if (employee.contractTypeName == "MonthlySalaryEmployee")
            {
                employeSalary = CreatorEmployeeSalary.Factory(CreatorEmployeeSalary.Monthly);
                return employeSalary.AnualSalary(employee.monthlySalary);
            }
            return 0;
        }

        private List<Employee> GetAnualSalary(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                item.anualySalary = GetAnualSalary(item);
            }
            return employees;
        }
    }
}
