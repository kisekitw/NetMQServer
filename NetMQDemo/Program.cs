using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");

                while (true)
                {
                    var message = server.ReceiveFrameString();

                    Console.WriteLine("Received {0}", message);

                    // processing the request
                    Thread.Sleep(100);

                    Console.WriteLine("Sending World");
                    server.SendFrame("World");
                }
            }
        }
    }
}
