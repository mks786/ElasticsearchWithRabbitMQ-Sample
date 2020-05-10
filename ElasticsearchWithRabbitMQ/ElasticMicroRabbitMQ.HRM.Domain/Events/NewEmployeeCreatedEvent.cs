using ElasticMicroRabbitMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticMicroRabbitMQ.HRM.Domain.Events
{
    public class NewEmployeeCreatedEvent : Event
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }

        public NewEmployeeCreatedEvent(int id, string firstName, string lastName, int age, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}
