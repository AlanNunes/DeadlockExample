using System;
using System.Threading;
namespace deadlockincsharp
{
    public class Program
    {
        static readonly object Tongue = new object();
        static readonly object Throat = new object();
        static void Speak()
        {
            lock (Tongue)
            {
                Console.WriteLine("Using the tongue.");
                Thread.Sleep(1000);
                lock (Throat)
                {
                    Console.WriteLine("Hello World!");
                }
            }
        }
        static void Eat()
        {
            lock (Throat)
            {
                Console.WriteLine("Using the throat.");
                lock (Tongue)
                {
                    Console.WriteLine("Eating x-burguer.");
                }
            }
        }
        static void Main()
        {
            new Thread(new ThreadStart(Speak)).Start();
            Thread.Sleep(500);
            Eat();
        }
    }
}