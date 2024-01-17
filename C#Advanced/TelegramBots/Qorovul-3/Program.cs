using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Qorovul_3;

public partial class Program
{
    public static List<long> ids = new List<long>();
    private static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient("6886129392:AAFx9QxWG9TRF3yJoRrnwOg4v6aiat-Rris");

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

            //IsChannelMember()
            var handler = update.Type switch
            {
                UpdateType.MyChatMember => HandleMyChatMemberAsync(botClient, update, cancellationToken),
                UpdateType.ChannelPost => HandleChannelPostAsync(botClient, update, cancellationToken),
                UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                _ => HandleUnknownUpdateTypeAsync(botClient, update, cancellationToken)
            };
            try
            {
                await handler;
            }
            catch (Exception ex) { }
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
    }

    private static async Task HandleChannelPostAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
         chatId: update.ChannelPost.Chat.Id,
         text: "Zo'r post ekan",
         replyToMessageId: update.ChannelPost.MessageId,
         cancellationToken: cancellationToken);
    }
}