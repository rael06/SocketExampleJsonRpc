using System.Net;
using System.Net.Sockets;

System.Console.WriteLine("#### CLIENT #####");
Console.Write("name: ");
var name = Console.ReadLine();
var service = new HelloService();
var message = service.Hello(name);
System.Console.WriteLine(message);
Console.WriteLine("exit!");

