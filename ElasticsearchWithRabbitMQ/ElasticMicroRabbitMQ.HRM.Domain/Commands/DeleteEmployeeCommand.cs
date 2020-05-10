using ElasticMicroRabbitMQ.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticMicroRabbitMQ.HRM.Domain.Commands
{
    public class DeleteEmployeeCommand : DeleteCommand
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
