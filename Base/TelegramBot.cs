using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System.Net.Sockets;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace ImageSearchBot.Base
{
    public class TelegramBot<THandlers> where THandlers : ITelegramBotHandlers, new()
    {
        protected ITelegramBotClient? Bot {  get; set; }
        protected ReceiverOptions? ReceiverOptions { get; set; }
        protected string Token => "7112464849:AAFkP42UpJT_jqYRcR1MkbS8K7nqARfWmVs";
        protected CancellationTokenSource CancellationTokenSource => new();

        protected THandlers Handlers = new();

        public void Init()
        {
            Bot = new TelegramBotClient(Token);
            ReceiverOptions = new ReceiverOptions
            {
                AllowedUpdates = [],
                ThrowPendingUpdates = true
            };
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();
            TcpListener server = new TcpListener(IPAddress.Any, 10000);
            
            server.Start();

            Log.Debug("Bot created");
        }

        public void StartReceiving()
        {
            Log.Debug("Bot start receiving");
            Bot?.StartReceiving(
                Handlers.MessageHandlerAsync,
                Handlers.ErrorHandlerAsync,
                ReceiverOptions,
                CancellationTokenSource.Token);

            while (true)
            {

            }
        }
    }
}
