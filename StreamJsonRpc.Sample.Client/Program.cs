using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using Common;
using StreamJsonRpc;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Connecting to server...");

        using (var stream = new NamedPipeClientStream(
            ".",
            "StreamJsonRpcSamplePipe",
            PipeDirection.InOut,
            PipeOptions.Asynchronous))
        {
            await stream.ConnectAsync();
            await ActAsRpcClientAsync(stream);
            Console.WriteLine("Terminating stream...");
        }

        Console.ReadLine();
    }

    private static async Task ActAsRpcClientAsync(Stream stream)
    {
        Console.WriteLine("Connected. Sending request...");
        using var jsonRpc = JsonRpc.Attach(stream);

        var server = jsonRpc.Attach<IServer>();
        int sum = await server.AddAsync(3, 5);
        Console.WriteLine($"3 + 5 = {sum}");
    }
}
