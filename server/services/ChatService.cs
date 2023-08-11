namespace Server.Services;

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Models;

public static class ChatService
{
    private static readonly List<ChatClient> clients = new();
    private static readonly List<ChatMessage> messages = new();

    public static async Task NewChatClient(ChatClient chatClient)
    {
        // Send the chat history to the new client
        List<ChatMessage> history = GetMessagesByPicture(chatClient.ImageName);
        foreach (var message in history)
        {
            await WsSendMessage(chatClient.WebSocket, message);
        }

        // Add the new client to the list of clients and listen for messages
        clients.Add(chatClient);
        while (chatClient.WebSocket.State == WebSocketState.Open)
        {
            var message = await WsReceiveMessage(chatClient.WebSocket);
            if (message == null) break;

            var chatMessage = new ChatMessage
            {
                ImageName = chatClient.ImageName,
                User = chatClient.User,
                Message = message
            };
            messages.Add(chatMessage);
            await WsBroadcastMessage(chatMessage);
        }

        // Remove the client from the list of clients and close the WebSocket connection
        clients.Remove(chatClient);
        await chatClient.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
    }

    private static List<ChatMessage> GetMessagesByPicture(string ImageName)
    {
        if (!messages.Any(msg => msg.ImageName == ImageName))
        {
            messages.Add(new ChatMessage { ImageName = ImageName, User = "Admin", Message = "Hi!" });
            messages.Add(new ChatMessage { ImageName = ImageName, User = "Admin", Message = "How can I help you?" });
        }
        return messages.Where(msg => msg.ImageName == ImageName).ToList();
    }

    private static async Task WsSendMessage(WebSocket webSocket, ChatMessage message)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
    }

    private static async Task<string?> WsReceiveMessage(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Close) return null;
        return Encoding.UTF8.GetString(buffer, 0, result.Count);
    }

    private static async Task WsBroadcastMessage(ChatMessage message)
    {
        foreach (var client in clients)
        {
            if (client.User != message.User && client.WebSocket.State == WebSocketState.Open)
            {
                await WsSendMessage(client.WebSocket, message);
            }
        };
    }

}