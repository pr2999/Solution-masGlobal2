using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Web;
using Newtonsoft.Json;

namespace DataLayer.Repository
{
    public class EmployeesApi
    {

        public List<Employee> GetEmployees() {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");
            var request = httpClient.GetAsync("api/Employees").Result;
            if (request.IsSuccessStatusCode)
            {
                var ResultString = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Employee>>(ResultString);
                return list;
            }
            return new List<Employee>();
        }
    }
}