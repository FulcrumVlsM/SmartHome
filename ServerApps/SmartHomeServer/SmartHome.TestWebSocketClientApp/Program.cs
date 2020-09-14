using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartHome.TestWebSocketClientApp.Models;

namespace SmartHome.TestWebSocketClientApp
{
    class Program
    {
        private static volatile bool _isActive = true;

        static async Task Main(string[] args)
        {
            await Task.Run(async () => await Work());
            Console.ReadKey();
            _isActive = false;
            Console.ReadKey();
        }


        static async Task Work()
        {
            ClientWebSocket clientWebSocket = new ClientWebSocket();
            try
            {
                var uri = new Uri("ws://localhost:2133/api/action-device/connect");
                Console.ReadKey();
                Console.WriteLine($"Подключаюсь к {uri.OriginalString}");
                await clientWebSocket.ConnectAsync(uri, CancellationToken.None);
                Console.WriteLine($"Подключено к {uri.OriginalString}");

                var configuration = new ConfigurationModel() { DeviceType = DeviceType.BoolActionDevice, SysName = "bool_device1" };
                var message = JsonConvert.SerializeObject(configuration);
                var buffer = Encoding.Unicode.GetBytes(message);
                Console.WriteLine("Отправляю конфигурацию");
                await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("Конфигурация отправлена");
                while (_isActive)
                {
                    var inputBuffer = new byte[1024 * 4];
                    await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(inputBuffer), CancellationToken.None);
                    string receiveMessage = Encoding.Unicode.GetString(inputBuffer);
                    var receiveModel = JsonConvert.DeserializeObject<BoolDeviceModel>(receiveMessage);
                    Console.WriteLine($"Receive value={receiveModel.Value}, date='{receiveModel.DateTime:YYYY-MM-dd HH:mm:ss}', success={receiveModel.IsSuccess}");
                }
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "closed from client", CancellationToken.None);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.Empty, "closed from client", CancellationToken.None);
            }
        }
    }
}
