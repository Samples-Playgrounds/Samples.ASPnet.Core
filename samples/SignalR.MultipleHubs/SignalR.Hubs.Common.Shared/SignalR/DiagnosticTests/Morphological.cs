using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.MultipleHubs.SignalR.DiagnosticTests
{
    public class MorphologicalHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

