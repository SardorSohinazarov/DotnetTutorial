using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Qorovul_3;

public partial class Program
{
    private static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handler = update.Message.Type switch
        {
            MessageType.Text => HandleCommandsAsync(botClient, update, cancellationToken),
            _ => HandleUnknownMessageTypeAsync(botClient, update, cancellationToken)
        };

        try
        {
            await handler;
        }
        catch (Exception ex) { }
    }

    private static async Task HandleUnknownMessageTypeAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static async Task HandleCommandsAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handler = update.Message.Text switch
        {
            "/start" => HandleStartCommandAsync(botClient, update, cancellationToken),
            "/salom" => HandleSalomCommandAsync(botClient, update, cancellationToken),
            _ => HandleUnknownCommandAsync(botClient, update, cancellationToken)
        };

        try
        {
            await handler;
        }
        catch (Exception ex)
        {

        }
    }

    private static async Task HandleUnknownCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static async Task HandleSalomCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            await botClient.SendTextMessageAsync(
               chatId: id,
               text: "Salomat",
               cancellationToken: cancellationToken);
        }
    }

    private static async Task HandleStartCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Qales endi",
            cancellationToken: cancellationToken);
    }

    private static async Task HandleUnknownUpdateTypeAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static async Task HandleMyChatMemberAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ids.Add(update.MyChatMember.Chat.Id);
    }

}
