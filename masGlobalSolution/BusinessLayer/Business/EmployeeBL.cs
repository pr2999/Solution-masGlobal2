﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using DomainLayer;

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
                Employee employee = JsonConvert.DeserializeObject<Employee>(ResultString);
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


        public List<EmployeeViewModel> GetSalaries(string id)
        {

            List<Employee> list;
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            EmployeeSalary employeeSalary;
            decimal anualSalary;
            if (id == null)
            {
                list = GetEmployees().ToList();
                foreach (var employee in list)
                {

                    if (employee.contractTypeName == "HourlySalaryEmployee") {
                        //employeeSalary = FactoryEmployee.CreateEmp(FactoryEmployee.hourlySalary);
                        //employee.anualySalary = employeeSalary.anualSalary();
                        anualSalary = FactoryEmployee.GetAnualSalary(FactoryEmployee.hourlySalary, employee);
                        employee.anualySalary = anualSalary;
                    }
                    if (employee.contractTypeName == "MonthlySalaryEmployee")
                    {
                        //employeeSalary = FactoryEmployee.CreateEmp(FactoryEmployee.hourlySalary);
                        //employee.anualySalary = employeeSalary.anualSalary(); 
                        anualSalary = FactoryEmployee.GetAnualSalary(FactoryEmployee.monthlySalary, employee);
                        employee.anualySalary = anualSalary;
                    }

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
            }

            return employeesList;
        }
    }
}