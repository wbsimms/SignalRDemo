using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRDemo.Hubs
{
    public class Chat : Hub
    {
        public void SayHello()
        {
            while (true)
            {
                Clients.All.addMessage("Date time  : "+DateTime.Now);
                Thread.Sleep(500);
            }
        }
    }
}