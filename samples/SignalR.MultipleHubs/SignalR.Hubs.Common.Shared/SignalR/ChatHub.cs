using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.MultipleHubs.SignalR
{
    public class ChatHub : global::Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

