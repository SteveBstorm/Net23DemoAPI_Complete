using Microsoft.AspNetCore.SignalR;

namespace DemoAPI_Complete.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("newMessage", user, message);
        }
    }
}
