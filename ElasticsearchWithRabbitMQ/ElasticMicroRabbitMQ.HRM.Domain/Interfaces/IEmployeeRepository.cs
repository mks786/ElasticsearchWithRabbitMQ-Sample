using ElasticMicroRabbitMQ.Common.Model;
using System.Collections.Generic;

namespace ElasticMicroRabbitMQ.HRM.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int Id);
    }
}
