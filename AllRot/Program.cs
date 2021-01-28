using System;
using AllRot.Classes;

namespace AllRot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AllRot";

            Console.Write("Text to decipher: ");
            string input = Console.ReadLine();

            while (Globals._bruteCounter != 25)
            {
                Globals._bruteCounter++;
                string plainText = Decipher(input, Globals._bruteCounter);

                Console.WriteLine("Rot{0}: {1}", Globals._bruteCounter, plainText);
            }

            Console.ReadKey();
        }
        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - offset) % 26) + offset);
        }

        private static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += Cipher(ch, key);

            return output;
        }

        private static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
