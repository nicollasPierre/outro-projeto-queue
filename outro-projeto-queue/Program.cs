using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;


namespace outro_projeto_queue
{
    class Program
    {
        const string serviceBus = "Endpoint=sb://qual-app-service-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=sDhf5oIwDhhaL8I/rbd9Vbd1yJH+MfReeeNqJ5pqwE4=";
        const string queueName = "test-queue";
        static void Main(string[] args)
        {
            
            string connString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connString);

            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueName);
            }

            QueueClient client = QueueClient.CreateFromConnectionString(connString,queueName);

            string msg = "Hello World";

            BrokeredMessage message;

            //ENVIAR
            //message = new BrokeredMessage(msg);

            //client.Send(message);


            //RECEBE

            message = client.Receive();
            

            Console.Write("saida: " + message.GetBody<String>());
            Console.Read();

        }
    }
}
