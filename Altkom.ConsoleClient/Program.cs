using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Send("Hello");
            Send("World");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        private static void Send(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sending {message}");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sent {message}.");
        }
    }



}
