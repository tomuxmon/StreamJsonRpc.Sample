using System;
using System.Threading.Tasks;
using Common;

internal class Server : IServer
{
    public async Task<int> AddAsync(int a, int b)
    {
        // Log to STDERR so as to not corrupt the STDOUT pipe that we may be using for JSON-RPC.
        await Console.Error.WriteLineAsync($"Received request: {a} + {b}");
        return a + b;
    }
}
