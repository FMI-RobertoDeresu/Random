using System;
using System.Text;

namespace Random
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Random text will be set to clipboard. Enter the size of random text: ");
            var randomSize = int.Parse(Console.ReadLine());
            var random = CreateRandom(randomSize);
            Clipboard.Copy(random);
        }

        private static string CreateRandom(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*(){}";
            var res = new StringBuilder();
            var rnd = new System.Random();

            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}
