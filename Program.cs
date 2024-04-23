using ImageSearchBot.Base;

var bot = new TelegramBot<TelegramBotHandlers>();

bot.Init();
bot.StartReceiving();