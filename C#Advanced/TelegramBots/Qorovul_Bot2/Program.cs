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
        UpdateType.ChatMember => HandleChatMemberAsync(botClient, update, cancellationToken),
        UpdateType.MyChatMember => HandleMyChatMemberAsync(botClient, update, cancellationToken),
        UpdateType.ChannelPost => HandleChannelPostAsync(botClient, update, cancellationToken),
        UpdateType.EditedChannelPost => HandleEditedChannelPostAsync(botClient, update, cancellationToken),
        _ => HandleUnknownUpdateTypeAsync(botClient, update, cancellationToken),
    };

    try
    {
        await handler;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

async Task HandleEditedChannelPostAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendTextMessageAsync(
       chatId: update.EditedChannelPost.Chat.Id,
       text: "Edit bo'pti a----bot",
       replyToMessageId: update.EditedChannelPost.MessageId,
       cancellationToken: cancellationToken
       );
}


#region Bu kimdur admin qilishi orqali kelarkan
async Task HandleMyChatMemberAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{

    //await botClient.SendTextMessageAsync(
    //   chatId: update.MyChatMember.Chat.Id,
    //   text: "Salom bolalalar----bot",
    //   cancellationToken: cancellationToken
    //   );
}
#endregion


#region Bu Post qo'yilganda kelarkan
async Task HandleChannelPostAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendTextMessageAsync(
        chatId: update.ChannelPost.Chat.Id,
        text: update.ChannelPost.Text + "----bot",
        cancellationToken: cancellationToken
        );

    await botClient.SendDiceAsync(
        chatId: update.ChannelPost.Chat.Id,
        cancellationToken: cancellationToken);
}
#endregion

async Task HandleUnknownUpdateTypeAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Console.WriteLine(update.Type.ToString() + "Bu turddagi updateni tutolmeman");
}

async Task HandleChatMemberAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Console.WriteLine(update.Type.ToString());
}

async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var message = update.Message;

    var handler = message.Type switch
    {
        MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken),
        MessageType.Video => HandleVideoMessageAsync(botClient, update, cancellationToken),
        MessageType.ChatMembersAdded => HandleChatMembersAddedAsync(botClient, update, cancellationToken),
        MessageType.ChatPhotoChanged => HandleChatPhotoChangedAsync(botClient, update, cancellationToken),
        _ => HandleUnknownMessageTypeAsync(update, update, cancellationToken),
    };

    try
    {
        await handler;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }



    /*    */
}

async Task HandleChatPhotoChangedAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendTextMessageAsync(
      chatId: update.Message.Chat.Id,
      text: "yaxshi rasm",
      replyToMessageId: update.Message.MessageId,
      cancellationToken: cancellationToken
      );
}

async Task HandleChatMembersAddedAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    await botClient.SendTextMessageAsync(
       chatId: update.Message.Chat.Id,
       text: "Brat qo'shildi a",
       replyToMessageId: update.Message.MessageId,
       cancellationToken: cancellationToken
       );
}

Task HandleUnknownMessageTypeAsync(Update update1, Update update2, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}

Task HandleVideoMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}

async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message is not { } message)
        return;
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "You said:\n" + messageText,
        cancellationToken: cancellationToken);
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
