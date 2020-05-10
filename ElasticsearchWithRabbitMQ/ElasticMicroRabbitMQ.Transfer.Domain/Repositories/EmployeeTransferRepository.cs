using ElasticMicroRabbitMQ.Common.Model;
using ElasticMicroRabbitMQ.Transfer.Domain.Interfaces;
using Nest;
using System;

namespace ElasticMicroRabbitMQ.Transfer.Domain.Repositories
{
    public class EmployeeTransferRepository : IEmployeeTransferRepository
    {
        public void TransferInsertEmployee(Employee employee)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));

            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);
            Employee emp = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Salary = employee.Salary
            };
            esClient.Index<Employee>(emp, i => i
                                              .Index("employeestore")
                                              .Id(employee.Id)
                                              .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void TransferUpdateEmployee(int Id, Employee employee)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);
            Employee emp = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Salary = employee.Salary
            };

            esClient.Index<Employee>(emp, i => i
                                           .Index("employeestore")
                                           .Id(employee.Id)
                                           .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void TransferDeleteEmployee(int id)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);
            var indexName = Indices.Index("employeestore");
            var delRequest = new DeleteRequest(indexName, id);
            delRequest.Refresh = Elasticsearch.Net.Refresh.True;
            esClient.Delete(new DocumentPath<Employee>(new Id(id)));
        }
    }
}
