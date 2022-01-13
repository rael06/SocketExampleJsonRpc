using System;
namespace Server
{
	public interface IHelloService
	{
		Task<string> Hello(string name);
	}
}

