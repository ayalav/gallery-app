namespace Server.Models;

using System.Net.WebSockets;

public class ChatClient
{
    public string ImageName { get; set; }
    public string User { get; set; }
    public WebSocket WebSocket { get; set; }
}

public class ChatMessage
{
    public string ImageName { get; set; }
    public string User { get; set; }
    public string Message { get; set; }
}