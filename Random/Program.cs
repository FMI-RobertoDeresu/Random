using System;
using System.Text;

namespace Random
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
            }
        }

        private static void Run()
        {
            var exitProgram = false;
            while (!exitProgram)
            {
                Console.Write("Use default settings? (only with letters and digits) y/n ");
                var defaultSettings = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();

                var withDigits = true;
                var withLetters = true;
                var withSpecialChars = false;

                if (!defaultSettings)
                {
                    Console.Write("Include digits? y/n ");
                    withDigits = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();

                    Console.Write("Include letters? y/n ");
                    withLetters = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();

                    Console.Write("Include special characters? y/n ");
                    withSpecialChars = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();
                }

                Console.Write("Random text will be set to clipboard. Enter the size of random text: ");
                var randomSize = int.Parse(Console.ReadLine());

                var generate = true;
                while (generate)
                {
                    var random = CreateRandom(randomSize, withDigits, withLetters, withSpecialChars);
                    Clipboard.Copy(random);
                    Console.WriteLine(random);

                    Console.WriteLine();
                    Console.Write("Another? y/n ");
                    generate = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();
                }

                Console.Write("Exit program? y/n ");
                exitProgram = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static string CreateRandom(int length, bool withDigits, bool withLetters, bool withSpecialChars)
        {
            const string digits = "1234567890";
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string specialChars = "!@#$%^&*(){}";

            var chars = (withDigits ? digits : string.Empty) +
                        (withLetters ? letters : string.Empty) +
                        (withSpecialChars ? specialChars : string.Empty);
            

            var res = new StringBuilder();
            var rnd = new System.Random();

            while (0 < length--)
            {
                res.Append(chars[rnd.Next(chars.Length)]);
            }

            return res.ToString();
        }
    }
}
