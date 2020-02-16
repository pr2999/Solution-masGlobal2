using BusinessLayer.Business;
using DataLayer.Models;
using DataLayer.Repository;
using DomainLayer;
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


        public ActionResult employeesList(int ID)
        {

            EmployeeBL bl = new EmployeeBL();

            if (ID < 0 || ID > 2)
            {
                var list = bl.GetSalaries();
                return View(list);
            }
            else
            {
                EmployeeViewModel employee = bl.GetSalary(ID);
                return View("employee", employee);
            }
        }


        public ActionResult employee(int ID)
        {
            return View();

        }




        [HttpPost]
        public ActionResult Index2(string txtValue)
        {
            EmployeeBL bl = new EmployeeBL();

            if (txtValue == null || Convert.ToInt16(txtValue) > 2)
            {
                var list = bl.GetSalaries();
                return View(list);
            }
            else {
                EmployeeViewModel employee = bl.GetSalary(Convert.ToInt16(txtValue));
                return View("employeesList", employee);
            }
        }
    }
}