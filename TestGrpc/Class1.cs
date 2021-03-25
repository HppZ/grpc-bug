using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Helloworld;

namespace TestGrpc
{
    public class Class1
    {
        public static async Task  A()
        {
                var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "GreeterClient" });
           
        }
    }
}
