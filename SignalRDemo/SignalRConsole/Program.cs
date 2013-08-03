using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace SignalRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection hub = new HubConnection("http://localhost:64277");
            IHubProxy proxy = hub.CreateHubProxy("Chat");

            proxy.On("addMessage", message =>
            {
                Console.WriteLine(message);
            });

            hub.Start().Wait();
            proxy.Invoke("SayHello");

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
            }
        }
    }
}
