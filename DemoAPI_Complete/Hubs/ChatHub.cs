using Microsoft.AspNetCore.SignalR;

namespace DemoAPI_Complete.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("newMessage", user, message);
        }

        public async Task JoinGroup(string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);

            await SendToGroup(groupname, "System", $"L'utilisateur {Context.ConnectionId} vient de nous rejoindre");   
        }

        public async Task SendToGroup(string groupname, string user, string message)
        {
            await Clients.Group(groupname).SendAsync("fromGroup" + groupname, user, message);
        }
    }
}
