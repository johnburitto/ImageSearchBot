using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImageSearchBot.Base
{
    public interface ITelegramBotHandlers
    {
        Task MessageHandlerAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
        Task ErrorHandlerAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken);
        Task InlineQueryHandlerAsync(ITelegramBotClient client, InlineQuery inlineQuery);
        Task ChosenInlineResultHandlerAsync(ITelegramBotClient client, ChosenInlineResult chosenInlineResult);
    }
}
