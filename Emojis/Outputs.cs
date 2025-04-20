using System;
namespace lab
{
    public static class Outputs
    {
        public static void Message(string message)
        {
            ConsoleColor basic = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(message);

            Console.ForegroundColor = basic;

        }

        public static void BadMessage(string message)
        {
            ConsoleColor basic = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = basic;

        }

        public static void GoodMessage(string message)
        {
            ConsoleColor basic = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ForegroundColor = basic;

        }
    }
}