
using Grpc.Core;
using GrpcGeo.Domain;
using IpGeo;
using System;
using System.Net;

namespace GrpcGeo.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Channel channel = new Channel($"127.0.0.1:{Constants.Port}", ChannelCredentials.Insecure);

            var client = new IpLocator.IpLocatorClient(channel);
            var request = new LocationRequest
            {
                App = "dotnet core",
                Ip = new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\n", "")
            };

            var reply = client.Find(request);

            Console.WriteLine($"The IP '{request.Ip}' comes from {reply.City} in {reply.Country}.");
            channel.ShutdownAsync().Wait();
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}
