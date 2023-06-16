using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace DemoAPI_Complete.Hubs
{
    public class GameHub : Hub
    {
        public async Task NotifyNewGame()
        {
            await Clients.All.SendAsync("newGame");
        }
    }
}
