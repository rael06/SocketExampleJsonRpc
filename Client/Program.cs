using System.Net;
using System.Net.Sockets;
using System.Text;
using StreamJsonRpc;

var tcpClient = new TcpClient();
tcpClient.Connect(IPEndPoint.Parse("127.0.0.1:1234"));

var data = tcpClient.GetStream();

var formatter = new JsonMessageFormatter(Encoding.UTF8);
var messageHandler = new LengthHeaderMessageHandler(data, data, formatter);
var client = JsonRpc.Attach<IHelloService>(messageHandler);
var result = await client.Hello("jeremy");
System.Console.WriteLine(result);