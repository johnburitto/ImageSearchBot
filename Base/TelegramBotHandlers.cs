using ImageSearchBot.HttpInfrastructure;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;

namespace ImageSearchBot.Base
{
    public class TelegramBotHandlers : ITelegramBotHandlers
    {
        private IImageSearchService _service;
        private string _key = "6c582cabb320497ebb8ddd97eb6643ff";

        public TelegramBotHandlers()
        {
            _service = new ImageSearchService(_key);
        }

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
            var imageResponse = await _service.Search(inlineQuery.Query, 30);
            var images = imageResponse?.Value;
            var results = new List<InlineQueryResult>();

            images?.Select((_, index) => new { Image = _, Index = index }).ToList()
                .ForEach(_ => results.Add(new InlineQueryResultPhoto($"{_.Index}", _.Image.ContentUrl!, _.Image.ThumbnailUrl!)));

            await client.AnswerInlineQueryAsync(inlineQuery.Id, results);
        }

        public Task ChosenInlineResultHandlerAsync(ITelegramBotClient client, ChosenInlineResult chosenInlineResult)
        {
            return Task.CompletedTask;
        }
    }
}
