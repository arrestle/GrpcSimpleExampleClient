using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService1;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var pond = new HelloRequest { Name = "Baby Frog", Location = "Pollywog Bog" };
            var dog = new HelloRequest { Name = "Logan the Magnificent", Location = "Dog Bed in the Corner" };

            var reply = await client.SayHelloAsync(pond);
            Console.WriteLine("Greeting 1: " + reply.Message);
            reply = await client.SayHelloAsync(  dog);
            Console.WriteLine("Greeting 2: " + reply.Message);

            reply = await client.SayGoodbyeAsync( pond );
            Console.WriteLine("Greeting 3: " + reply.Message);

            reply = await client.SayGoodbyeAsync(dog);
            Console.WriteLine("Greeting 4: " + reply.Message);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
