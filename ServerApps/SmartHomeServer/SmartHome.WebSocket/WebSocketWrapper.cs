using System;
using System.Text;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace SmartHome.WebSocket
{
    public abstract class WebSocketWrapper
    {
        protected readonly System.Net.WebSockets.WebSocket _webSocket;

        public WebSocketWrapper(System.Net.WebSockets.WebSocket webSocket)
        {
            _webSocket = webSocket;
        }

        protected async Task SendMessage(string message)
        {
            var messageArray = Encoding.Unicode.GetBytes(message);
            await _webSocket.SendAsync(new ArraySegment<byte>(messageArray), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        protected async Task<string> ReceiveMessage()
        {
            var buffer = new byte[1024 * 4];
            await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            return Encoding.Unicode.GetString(buffer);
        }

        protected bool IsActive => !_webSocket.CloseStatus.HasValue;
    }
}
