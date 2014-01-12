using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SignalRDemo.Tests.Hubs
{
    [TestClass]
    public class ChatTest
    {
        [TestMethod]
        public void HelloTest()
        {
            HubConnection hub = new HubConnection("http://localhost:64277");
            IHubProxy proxy = hub.CreateHubProxy("Chat");

            string message = null;
            proxy.On("addMessge", m =>
            {
                message = m;
            });

            hub.Start().Wait();
            proxy.Invoke("SayHello");
            Thread.Sleep(500);

            Assert.IsNotNull(message);

        }
    }
}
