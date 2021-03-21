using System;
using System.Diagnostics;
using Grpc.Core;
using Helloworld;

namespace TestGrpc
{
    public class Class1
    {
        public static void A()
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            String user = "you";

            try
            {
                //var reply = client.SayHello(new HelloRequest { Name = user });

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }
        }
    }
}
