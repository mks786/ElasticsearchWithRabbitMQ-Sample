using ElasticMicroRabbitMQ.Common.Model;
using System.Collections.Generic;

namespace ElasticMicroRabbitMQ.Transfer.Domain.Interfaces
{
    public interface IEmployeeTransferRepository
    {
        void TransferInsertEmployee(Employee employee);
        void TransferUpdateEmployee(int Id, Employee employee);
        void TransferDeleteEmployee(int id);
    }
}
