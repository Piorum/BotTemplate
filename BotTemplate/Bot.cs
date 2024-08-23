using Discord;
using Discord.WebSocket;

namespace BotTemplate;

public class Bot(string t, DiscordSocketConfig c) : BotBase(t,c)
{
    protected override async Task MessageRecievedHandler(SocketMessage message){
        await SendMessage(message.Channel, message.Content);
    }

}
