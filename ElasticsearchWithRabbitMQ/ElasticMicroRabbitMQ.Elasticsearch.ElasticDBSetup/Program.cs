using ElasticMicroRabbitMQ.Common.Model;
using Nest;
using System;

namespace ElasticMicroRabbitMQ.Elasticsearch.ElasticDBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started creating Database in Elastic search");
            CreateIndex();
            CreateMappings();
            Console.WriteLine("Database created.");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CreateIndex()
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient client = new ElasticClient(settings);
            client.Indices.Delete(Indices.Index("employeestore"));
            //client.Indices.Delete(Indices.Index("kibana_sample_data_flights"));
            //client.Indices.Delete(Indices.Index(".kibana_1 "));
            //client.Indices.Delete(Indices.Index("kibana_sample_data_logs"));
            //client.Indices.Delete(Indices.Index("employee"));
            //client.Indices.Delete(Indices.Index("index"));
            //client.Indices.Delete(Indices.Index(".apm-agent-configuration "));
            //client.Indices.Delete(Indices.Index("kibana_sample_data_ecommerce"));
            //client.Indices.Delete(Indices.Index(".kibana_task_manager_1"));
            var indexSettings = client.Indices.Exists("employeestore");
            if (!indexSettings.Exists)
            {
                var indexName = Indices.Index("employeestore");
                var response = client.Indices.Create(indexName);
            }

            if (indexSettings.Exists)
            {
                Console.WriteLine("Created");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public static void CreateMappings()
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);
            esClient.Map<Employee>(m =>
            {
                var putMappingDescriptor = m.Index(Indices.Index("employeestore")).AutoMap();
                return putMappingDescriptor;
            });
        }
    }
}
