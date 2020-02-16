using BusinessLayer.Business;
using DataLayer.Models;
using DataLayer.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masGlobal.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //EmployeesApi DLayer = new EmployeesApi();
            //List<Employee> list = DLayer.GetEmployees().ToList();

            return View();
        }

        [HttpGet]
        public ActionResult employeesList(string txtValue)
        {

            return View();
        }


        [HttpGet]
        public ActionResult Index2(string txtValue)
        {
            EmployeeBL bl = new EmployeeBL();
            var list = bl.GetSalaries(txtValue);
            return View();
        }


        public decimal anualSalary(string id)
        {
            //EmployeeSalary employeeSalary = FactoryEmployee.CreateEmp(FactoryEmployee.hourlySalary);
            //var salary = employeeSalary.anualSalary();

            //employeeSalary = FactoryEmployee.CreateEmp(FactoryEmployee.monthlySalary);
            //salary = employeeSalary.Salary();

            return 0;
        }
    }
}