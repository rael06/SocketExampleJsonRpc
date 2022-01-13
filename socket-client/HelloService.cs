using System.Net;
using System.Net.Sockets;
using System.Text;

public class HelloService {

    private Socket _socket;

    public HelloService()
    {
        System.Console.WriteLine("Creating socket...");
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _socket.Connect(IPEndPoint.Parse("127.0.0.1:1234"));

        System.Console.WriteLine("client connected");
    }
    public string Hello(string name)
    {
        System.Console.WriteLine("sending hello packet...");
        var data = Encoding.ASCII.GetBytes($"hello;{name}");
        _socket.Send(data);

        var buffer = new byte[1024];
        var count = _socket.Receive(buffer);
        var message = Encoding.ASCII.GetString(buffer, 0, count);

        return message;
    }
}