using System.Net;
using System.Net.Sockets;
using System.Text;
using Server;
using StreamJsonRpc;

var tcpServer = new TcpListener(IPEndPoint.Parse("127.0.0.1:1234"));
tcpServer.Start();
System.Console.WriteLine("waiting client");
var tcpClient = tcpServer.AcceptTcpClient();

var data = tcpClient.GetStream();
var formatter = new JsonMessageFormatter(Encoding.UTF8);
var messageHandler = new LengthHeaderMessageHandler(data, data, formatter);

using var rpc = new JsonRpc(messageHandler, new HelloService());
System.Console.WriteLine("rpc start listening...");
rpc.StartListening();

await rpc.Completion;
