namespace BotTemplate;

public abstract class BotBase{

    private readonly string helpCmd = ".help";
    private readonly DiscordSocketClient _client;
    private string _token;

    public BotBase(string t,DiscordSocketConfig c){
        //Client Creation
        _token = t;
        _client = new DiscordSocketClient(c);

        //Define Handlers
        _client.MessageReceived += MessageRecievedHandler;
        _client.Log += LogHandler;
    }

    public async Task StartBotAsync(){
        //Starting Bot
        await _client.LoginAsync(TokenType.Bot, _token);
        await _client.StartAsync();
        await _client.SetActivityAsync(new Game(helpCmd, ActivityType.Watching));


        //Block this task until program is closed
        await Task.Delay(-1);
    }

    public static async Task SendMessage(ISocketMessageChannel channel, string message){
        await channel.SendMessageAsync(message);
    }

    protected static Task LogHandler(LogMessage message){
        Console.WriteLine(message.ToString());
        return Task.CompletedTask;
    }

    protected abstract Task MessageRecievedHandler(SocketMessage message);
    
}
