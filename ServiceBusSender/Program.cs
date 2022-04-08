using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusSender
{
    class Program
    {

        const string ServiceBusConnectionString = "";
        const string queuename = "queue1";
        static IQueueClient queueClient;
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            const int numberOfMessages = 10;
            queueClient = new QueueClient(ServiceBusConnectionString, queuename);
            await SendMessage(numberOfMessages);
            await queueClient.CloseAsync();
        }
        static async Task SendMessage(int numberOfMessagesToSend)
        {
            try
            {
                for(int i=0; i< numberOfMessagesToSend; i++)
                {
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    Console.WriteLine($"Sending Message : {messageBody}");
                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
