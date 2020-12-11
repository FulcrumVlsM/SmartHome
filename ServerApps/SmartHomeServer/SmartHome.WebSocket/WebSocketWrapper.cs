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
        private bool disposedValue;

        public WebSocketWrapper(System.Net.WebSockets.WebSocket webSocket)
        {
            _webSocket = webSocket;
            _semaphore = new SemaphoreSlim(1, 1);
        }

        public async Task<T2> SendAndReceive(T1 message)
        {
            _semaphore.Wait();
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message);
                var buffer = Encoding.Unicode.GetBytes(serializedMessage);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer), System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);

                return await Receive();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<T2> Receive()
        {
            _semaphore.Wait();
            try
            {
                var inputBuffer = new byte[1024 * 4];
                await _webSocket.ReceiveAsync(new ArraySegment<byte>(inputBuffer), CancellationToken.None);
                string receiveMessage = Encoding.Unicode.GetString(inputBuffer);
                var deserializedMessage = JsonConvert.DeserializeObject<T2>(receiveMessage);
                return deserializedMessage;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Close()
        {

        }




        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _semaphore.Dispose();
                    _webSocket.Dispose();
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
