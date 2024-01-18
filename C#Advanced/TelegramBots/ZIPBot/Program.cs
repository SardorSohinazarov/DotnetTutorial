using System.IO.Compression;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("6666617530:AAEc5I4KUCpYe1JHw2KM4g0AD9GGSvxDxb0");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { } message)
        return;
    // Only process text messages
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    string startPath = messageText;
    string zipPath = messageText + ".zip";

    /*    string startPath = @"C:\Users\sardo\OneDrive\Рабочий стол\zipqil";
        string zipPath = @"C:\Users\sardo\OneDrive\Рабочий стол\zipqil.zip";*/

    try
    {

        if (!System.IO.File.Exists(zipPath))
            ZipFile.CreateFromDirectory(startPath, zipPath);

        var x = System.IO.File.OpenRead(zipPath);

        await botClient.SendDocumentAsync(
            chatId: chatId,
            document: InputFile.FromStream(x, startPath + ".zip"),
            cancellationToken: cancellationToken);
    }
    catch { }
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
