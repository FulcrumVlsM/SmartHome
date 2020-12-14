using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome.WebSocket
{
    internal class WebSocketWrapper<T1, T2> : IDisposable
    {
        private readonly System.Net.WebSockets.WebSocket _webSocket;
        private readonly SemaphoreSlim _semaphore;
        private CancellationToken _cancellationToken;
        private bool disposedValue;

        internal WebSocketWrapper(System.Net.WebSockets.WebSocket webSocket, CancellationToken cancellationToken)
        {
            _webSocket = webSocket;
            _cancellationToken = cancellationToken;
            _semaphore = new SemaphoreSlim(1, 1);
        }


        internal bool ClosedStatus => _webSocket.CloseStatus.HasValue;

        internal async Task<T2> SendAndReceive(T1 message)
        {
            _semaphore.Wait();
            try
            {
                await Send(message);
                return await Receive();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        internal async Task Send(T1 message)
        {
            var serializedMessage = JsonConvert.SerializeObject(message);
            var buffer = Encoding.Unicode.GetBytes(serializedMessage);
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), System.Net.WebSockets.WebSocketMessageType.Text, true, _cancellationToken);
        }

        internal async Task<T2> Receive()
        {
            var inputBuffer = new byte[1024 * 4];
            var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(inputBuffer), _cancellationToken);
            string receiveMessage = Encoding.Unicode.GetString(inputBuffer);
            var deserializedMessage = JsonConvert.DeserializeObject<T2>(receiveMessage);

            if (result.CloseStatus.HasValue)
            {
                //CloseOutputAsync если бу
                await _webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, _cancellationToken);
            }

            return deserializedMessage;
        }

        internal async Task Close() => await _webSocket.CloseOutputAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "NormalClosure", _cancellationToken);




        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _semaphore.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
