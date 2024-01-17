using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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
        UpdateType.CallbackQuery => HandleCallBackQueryAsync(botClient, update, cancellationToken),
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

Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}

async Task HandleCallBackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var buttons = new List<List<InlineKeyboardButton>>()
    {
        new List<InlineKeyboardButton>()
        {
            InlineKeyboardButton.WithCallbackData("1","1"),
            InlineKeyboardButton.WithCallbackData("2","2"),
            InlineKeyboardButton.WithCallbackData("3","3"),
        },
        new List<InlineKeyboardButton>()
        {
            InlineKeyboardButton.WithCallbackData("1","1"),
            InlineKeyboardButton.WithCallbackData("2","2"),
            InlineKeyboardButton.WithCallbackData("3","3"),
        },
    };

    await botClient.SendTextMessageAsync(
       chatId: update.CallbackQuery.From.Id,
       parseMode: ParseMode.Html,
       text: $"<b> {update.CallbackQuery.Data}</b>",
       cancellationToken: cancellationToken);


    await botClient.EditMessageTextAsync(
        chatId: update.CallbackQuery.From.Id,
        messageId: update.CallbackQuery.Message.MessageId,
        text: $"<b> {update.CallbackQuery.Data}</b>",
        replyMarkup: new InlineKeyboardMarkup(buttons),
        parseMode: ParseMode.Html,
        cancellationToken: cancellationToken
        );
}

async Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    //await botClient.DeleteMessageAsync(
    //       chatId: update.EditedMessage.From.Id,
    //       messageId: update.EditedMessage.MessageId,
    //       cancellationToken: cancellationToken
    //      );
}

async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message is not { } message)
        return;
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    var button = InlineKeyboardButton.WithCallbackData(text: "Qales", callbackData: "q");

    if (messageText == "Qales")
    {
        Message sentMessage = await botClient.SendTextMessageAsync(
           chatId: chatId,
           text: "Rahmat yaxshi",
           replyMarkup: new InlineKeyboardMarkup(button),
           cancellationToken: cancellationToken);
    }
    else if (messageText.Contains("dotnet"))
    {
        // Echo received message text
        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "You said:\n" + messageText,
            replyMarkup: new ReplyKeyboardMarkup(new KeyboardButton("Qales")),
            cancellationToken: cancellationToken);
    }
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
