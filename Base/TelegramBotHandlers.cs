using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ImageSearchBot.Base
{
    public class TelegramBotHandlers : ITelegramBotHandlers
    {
        public async Task MessageHandlerAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            switch (update.Type)
            {
                case UpdateType.InlineQuery:
                    {
                        await InlineQueryHandlerAsync(client, update.InlineQuery!);
                    } return;
                case UpdateType.ChosenInlineResult:
                    {
                        await ChosenInlineResultHandlerAsync(client, update.ChosenInlineResult!);
                    } return;
                default: return;
            }
        }

        public Task ErrorHandlerAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram Bot API exception:\n {apiRequestException.ErrorCode}\n {apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);

            return Task.CompletedTask;
        }

        public async Task InlineQueryHandlerAsync(ITelegramBotClient client, InlineQuery inlineQuery)
        {
            return;
        }

        public async Task ChosenInlineResultHandlerAsync(ITelegramBotClient client, ChosenInlineResult chosenInlineResult)
        {
            return;
        }
    }
}
