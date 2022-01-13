using System;
namespace Server
{
    public class HelloService : IHelloService
    {
        public Task<string> Hello(string name)
        {
            System.Console.WriteLine("HELLO");
            return Task.FromResult($"hello {name}");
        }
    }
}

