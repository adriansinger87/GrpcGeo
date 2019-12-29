using System;

namespace GrpcEvents.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is starting.");

            var server = new IpGeoServer();
            server.Start();

            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.Shutdown();
        }
    }
}
