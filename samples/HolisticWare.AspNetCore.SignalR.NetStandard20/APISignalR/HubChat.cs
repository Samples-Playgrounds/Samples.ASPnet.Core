using System;

namespace Empty.SignalR.APISignalR
{
    public class HubChat : Microsoft.AspNetCore.SignalR.Hub
    {
        public System.Threading.Tasks.Task Send(string message)
        {
            return Clients.All.InvokeAsync("Send", message);
        }
    }
}