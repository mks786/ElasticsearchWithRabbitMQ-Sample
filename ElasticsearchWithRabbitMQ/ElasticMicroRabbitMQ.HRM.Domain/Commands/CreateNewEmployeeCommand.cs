using ElasticMicroRabbitMQ.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticMicroRabbitMQ.HRM.Domain.Commands
{
    public class CreateNewEmployeeCommand : EmployeeCommand
    {
        public CreateNewEmployeeCommand(int id, string firstName, string lastName, int age, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}
