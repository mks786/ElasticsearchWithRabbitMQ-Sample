using ElasticMicroRabbitMQ.Common.Model;
using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.HRM.Application.Interfaces;
using ElasticMicroRabbitMQ.HRM.Domain.Commands;
using ElasticMicroRabbitMQ.HRM.Domain.Interfaces;
using System.Collections.Generic;

namespace ElasticMicroRabbitMQ.HRM.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEventBus _bus;

        public EmployeeService(IEmployeeRepository employeeRepository, IEventBus bus)
        {
            _employeeRepository = employeeRepository;
            _bus = bus;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _employeeRepository.GetEmployeeById(Id);
        }

        public void InsertEmployee(Employee employee)
        {
            var createNewEmployee = new CreateNewEmployeeCommand(employee.Id,
                                                                 employee.FirstName,
                                                                 employee.LastName,
                                                                 employee.Age,
                                                                 employee.Salary);
            _bus.SendCommand(createNewEmployee);
        }

        public void UpdateEmployee(int Id, Employee employee)
        {
            var updateEmployee = new UpdateEmployeeCommand(employee.Id,
                                                           employee.FirstName,
                                                           employee.LastName,
                                                           employee.Age,
                                                           employee.Salary);
            _bus.SendCommand(updateEmployee);
        }

        public void DeleteEmployee(int Id)
        {
            var deleteEmployee = new DeleteEmployeeCommand(Id);
            _bus.SendCommand(deleteEmployee);
        }
    }
}
