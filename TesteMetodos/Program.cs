using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace TesteMetodos
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            var ippaddress = host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            Console.WriteLine(ippaddress);
        }
    }
}
