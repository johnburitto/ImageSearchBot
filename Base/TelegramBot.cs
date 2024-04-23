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
        }

        public void StartReceiving()
        {
            Bot?.StartReceiving(
                Handlers.MessageHandlerAsync,
                Handlers.ErrorHandlerAsync,
                ReceiverOptions,
                CancellationTokenSource.Token);

            Console.ReadKey();
            CancellationTokenSource.Cancel();
        }
    }
}
