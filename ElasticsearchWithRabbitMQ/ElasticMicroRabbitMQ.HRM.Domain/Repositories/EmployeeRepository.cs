using ElasticMicroRabbitMQ.Common.Model;
using ElasticMicroRabbitMQ.HRM.Domain.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElasticMicroRabbitMQ.HRM.Domain.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }

        public IEnumerable<Employee> GetEmployees()
        {
            Employee emp = null;
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);

            var response = esClient.Search<Employee>(s => s.Query(q => q.MatchAll()));
            var employee1 = response.Hits.ToList();
            List<Employee> empList = new List<Employee>();
            foreach (var item in employee1)
            {
                emp = new Employee
                {
                    Id = item.Source.Id,
                    FirstName = item.Source.FirstName,
                    LastName = item.Source.LastName,
                    Age = item.Source.Age,
                    Salary = item.Source.Salary
                };
                empList.Add(emp);
            }
            return empList;
        }

        public Employee GetEmployeeById(int Id)
        {
            Employee emp = null;
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);

            var response = esClient.Search<Employee>(s => s.Query(
                q => q.Term(fld => fld.Id, Id)));


            if (response != null)
            {
                var employee = response.Hits.FirstOrDefault();
                emp = new Employee
                {
                    Id = employee.Source.Id,
                    FirstName = employee.Source.FirstName,
                    LastName = employee.Source.LastName
                };
            }
            return emp;
        }
    }
}
