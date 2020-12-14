using System;

namespace HelloworldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Please enter a word");
            String str = Console.ReadLine();
            Console.WriteLine($"You put {str}.");
        }
    }
}
