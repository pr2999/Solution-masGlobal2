using DataLayer.Models;
using DataLayer.Repository;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiServices.Controllers
{
    public class EmployeeController : ApiController
    {

        EmployeesApi DLayer = new EmployeesApi();


        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var list = DLayer.GetEmployees().ToList();
            return list;
        }

        [HttpGet]
        public Employee Get(int id)
        {
            var list = DLayer.GetEmployees().ToList();
            Employee employee = list.FirstOrDefault(x => x.id == id);
            return employee;
        }
    }
}
