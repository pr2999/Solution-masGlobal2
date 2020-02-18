using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using DomainLayer;
using BusinessLayer.Business.Factory;

namespace BusinessLayer.Business
{
    public class EmployeeBL
    {
        private Employee GetEmployee(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:1037/");
            var request = httpClient.GetAsync("api/Employee/?id =" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var ResultString = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Employee>>(ResultString);
                var employee = (from l in list
                          where l.id == id
                           select new Employee {
                               id = l.id,
                               name =l.name,
                               roleId = l.roleId,
                               roleName = l.roleName,
                               roleDescription = l.roleDescription,
                               contractTypeName = l.contractTypeName,
                               monthlySalary = l.monthlySalary,
                               hourlySalary = l.hourlySalary,
                               anualySalary = l.anualySalary
                           }).FirstOrDefault();

                return employee;
            }
            return new Employee();
        }

        private List<Employee> GetEmployees()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:1037/");
            var request = httpClient.GetAsync("api/Employee").Result;
            if (request.IsSuccessStatusCode)
            {
                var ResultString = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Employee>>(ResultString);
                return list;
            }
            return new List<Employee>();
        }

        public List<EmployeeViewModel> GetSalaries()
        {

            List<Employee> list;
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            list = GetEmployees().ToList();
            foreach (var employee in list)
            {
                EmployeeViewModel employeeViemodel = new EmployeeViewModel
                {
                    id = employee.id,
                    name = employee.name,
                    contractTypeName = employee.contractTypeName,
                    roleId = employee.roleId,
                    roleName = employee.roleName,
                    roleDescription = employee.roleDescription,
                    anualSalary = employee.anualySalary,
                };

                employeesList.Add(employeeViemodel);
            }
            return employeesList;
        }

        public EmployeeViewModel GetSalary(int id)
        {

            Employee employee = GetEmployee(id);
            EmployeeViewModel employeeViemodel = new EmployeeViewModel
            {
                id = employee.id,
                name = employee.name,
                contractTypeName = employee.contractTypeName,
                roleId = employee.roleId,
                roleName = employee.roleName,
                roleDescription = employee.roleDescription,
                anualSalary = employee.anualySalary,
            };

            return employeeViemodel;
        }
    }
}