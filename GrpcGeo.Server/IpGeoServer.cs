using Grpc.Core;
using GrpcGeo.Domain;
using IpGeo;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GrpcEvents.Server
{
    internal class IpGeoServer : IpLocator.IpLocatorBase
    {
        private Grpc.Core.Server _server;
        
        public IpGeoServer()
        {
            _server = new Grpc.Core.Server
            {
                Services = { IpLocator.BindService(this) },
                Ports = { new ServerPort("localhost", Constants.Port, ServerCredentials.Insecure) }
            };
        }

        public void Start()
        {
            _server.Start();
        }

        public void Shutdown()
        {
            _server.ShutdownAsync().Wait();
        }

        public override Task<LocationDetails> Find(LocationRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Request from '{request.App}' for IP: {request.Ip}");

            var jsonString = new WebClient().DownloadString($"https://freegeoip.app/json/" + request.Ip);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var location = new LocationDetails
            {
                Country = data.country_name,
                City = data.city,
                Longitude = data.longitude,
                Latitude = data.latitude
            };

            return Task.FromResult(location);
        }
    }
}