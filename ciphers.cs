// Chae DeLaRosa
// Cipher console program to encrypt and decrypt messages
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers
{
    class Program
    {

        /// <summary>
        /// Allow user to interact with the program using cmd line args
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            try
            {
                switch (args[0].ToLower())
                {
                    case "cc":
                        try
                        {
                            if (args[1].ToLower() == "-b")
                            {
                                menu.CaesarCipherArgs(args[2], args[1]);
                            }
                            menu.CaesarCipherArgs(args[3], args[1], Convert.ToInt32(args[2]));
                        }
                        catch
                        {
                            Console.WriteLine("Valid input: caesarcipher [mode (encrypt,decrypt,bruteforce): -e, -d, -b] [key: int] [message]");
                        }
                        return;
                    case "tc":
                        try
                        {
                            menu.TranspositionArgs(args[3], args[1], Convert.ToInt32(args[2]));
                        }
                        catch
                        {
                            Console.WriteLine("Valid input: transpositioncipher [key] [message]");
                        }
                        return;
                    default:
                        Console.WriteLine("Valid input: caesarcipher [mode (encrypt,decrypt,bruteforce): -e, -d, -b] [key: int] [message]\n");
                        Console.WriteLine("Valid input: transpositioncipher [encrypt] [key] [message]");
                        return;
                }
            }
            catch
            {
                menu.MainMenu();
            }
        }
    }
}
