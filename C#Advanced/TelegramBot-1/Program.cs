using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("6446024298:AAFBCvYRgUcy4wgkXHY5UPOkTGMIBitvuVs");

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
    var handler = update.Type switch
    {
        UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
        UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
        _ => HandleUnknownUpdateType(botClient, update, cancellationToken),
    };

    try
    {
        await handler;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error chiqdi:{ex.Message}");
    }
}

async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var message = update.Message;

    var handler = message.Type switch
    {
        MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken),
        MessageType.Video => HandleVideoMessageAsync(botClient, update, cancellationToken),
        _ => HandleUnknownMessageTypeAsync(update, update, cancellationToken),
    };
}

async Task HandleVideoMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendPhotoAsync(
        chatId: update.Message.Chat.Id,
        photo: InputFile.FromUri("https://media.licdn.com/dms/image/D4D03AQFmWv4Bx4kB5Q/profile-displayphoto-shrink_800_800/0/1684305519369?e=2147483647&v=beta&t=2kshdwvT_DCbyxIyHkP6pJJH8fYB_MvW6NyEJ8PeCDE"),
        cancellationToken: cancellationToken);
}

async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{

}
Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}

Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}

async Task HandleUnknownMessageTypeAsync(Update update1, Update update2, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
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
