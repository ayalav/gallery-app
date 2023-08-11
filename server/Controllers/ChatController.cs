namespace Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

[ApiController]
public class ChatController : ControllerBase
{
    [Route("/api/chat")]
    public async Task Get()
    {
        // Respond to the client with a 400 if the request is not a WebSocket request
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        // Accept the WebSocket connection
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

        // Get the user and image name from the query string
        string? user = HttpContext.Request.Query["user"];
        string? imageName = HttpContext.Request.Query["image"];

        // Respond to the client with a 400 if the user or image name is missing
        if (user == null || imageName == null)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        // Start chat with the client
        await ChatService.NewChatClient(new ChatClient {
            WebSocket = webSocket,
            ImageName = imageName,
            User = user
        });
    }
}
