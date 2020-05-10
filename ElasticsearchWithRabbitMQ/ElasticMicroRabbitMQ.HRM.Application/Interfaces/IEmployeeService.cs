using ElasticMicroRabbitMQ.Common.Model;
using System.Collections.Generic;

namespace ElasticMicroRabbitMQ.HRM.Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int Id);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(int Id, Employee employee);
        void DeleteEmployee(int id);
    }
}
