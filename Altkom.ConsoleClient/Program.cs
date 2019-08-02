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
        static async void Main(string[] args)
        {

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} UI");

            //Send("Hello");
            //Send("World");


            //Thread thread = new Thread(()=>Send("Hello"));
            //thread.Start();

            //Thread thread2 = new Thread(()=>Send("World"));
            //thread2.Start();

            // Task task = Task.Run(() => Send("Hello 1 "));
            // Task.Run(() => Send("Hello 2"));
            // Task.Run(() => Send("Hello 3"));
            // Task.Run(() => Send("Hello 4"));
            // Task.Run(() => Send("Hello 5"));

            //decimal result = Calculate();
            //Send(result.ToString());


            //Task<decimal> task = Task.Run(() => Calculate());
            //task.ContinueWith(t => Send(t.Result.ToString()));

            decimal result = await CalculateAsync();
            Send(result.ToString());


            // Send(task.Result.ToString());

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        private static void Send(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sending {message}");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sent {message}.");
        }

        private static Task<decimal> CalculateAsync()
        {
            return Task.Run(() => Calculate());
        }

        private static decimal Calculate()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} calculating...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} calculated.");
            return 100;
        }
    }



}
