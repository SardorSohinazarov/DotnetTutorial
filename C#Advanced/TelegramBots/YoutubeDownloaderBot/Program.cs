using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using VideoLibrary;

var botClient = new TelegramBotClient("6531846063:AAGInKszG9xA3bUymMw-UWky9sr8qSsk5t8");

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

    var elon = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Yuklayapmiz",
        cancellationToken: cancellationToken
        );

    YouTube youTube = new YouTube();
    var youtubeVideo = youTube.GetVideo(messageText);

    var bytes = await youtubeVideo.GetBytesAsync();

    elon = await botClient.EditMessageTextAsync(
        chatId: chatId,
        messageId: elon.MessageId,
        text: "Jonatyapmiz",
        cancellationToken: cancellationToken
        );

    User a;

    await botClient.SendVideoAsync(
        chatId: chatId,
        video: InputFile.FromStream(new MemoryStream(bytes)),
        cancellationToken: cancellationToken);


    await botClient.DeleteMessageAsync(
        chatId: chatId,
        messageId: elon.MessageId
        );
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
