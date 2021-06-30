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
            try
            {
                switch (args[0].ToLower())
                {
                    case "caesarcipher":
                        try
                        {
                            if (args[1].ToLower() == "bruteforce")
                            {
                                CaesarCipherArgs(args[2], args[1]);
                            }
                            CaesarCipherArgs(args[3], args[1], Convert.ToInt32(args[2]));
                        }
                        catch
                        {
                            Console.WriteLine("Valid input: caesarcipher [encrypt] [key] [message]");
                            Console.WriteLine("Valid input: caesarcipher [decrypt] [key] [message]");
                            Console.WriteLine("Valid input: caesarcipher [bruteforce] [message]");
                        }
                        return;
                    case "transpositioncipher":
                        try
                        {
                            TranspositionArgs(args[3], args[1], Convert.ToInt32(args[2]));
                        }
                        catch
                        {
                            Console.WriteLine("Valid input: transpositioncipher [key] [message]");
                        }
                        return;
                    default:
                        Console.WriteLine("Valid input: caesarcipher [encrypt] [key] [message]");
                        Console.WriteLine("Valid input: caesarcipher [decrypt] [key] [message]");
                        Console.WriteLine("Valid input: caesarcipher [bruteforce] [message]");
                        Console.WriteLine("");
                        Console.WriteLine("Valid input: transpositioncipher [encrypt] [key] [message]");
                        return;
                }
            }
            catch
            {
                MainMenu();
            }
        }

        /// <summary>
        /// if the user uses the transposition arg
        /// </summary>
        /// <param name="message"></param>
        /// <param name="option"></param>
        /// <param name="key"></param>
        static void TranspositionArgs(string message, string option, int key)
        {
            try
            {
                switch (option.ToLower())
                {
                    case "encrypt":
                        Console.WriteLine($"|{Ciphers.TranspositionCipher.Encrypt(message, key)}|");
                        return;
                    case "decrypt":
                        return;
                    default:
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Valid input: transpositioncipher [encrypt] [key] [message]");
                return;
            }
        }

        /// <summary>
        /// if the user uses the caesar cipher arg
        /// </summary>
        /// <param name="message"></param>
        /// <param name="option"></param>
        /// <param name="key"></param>
        static void CaesarCipherArgs(string message, string option, int key = 1)
        {
            try
            {
                switch (option.ToLower())
                {
                    case "encrypt":
                        Console.WriteLine($"|{Ciphers.CaesarsCipher.Encrypt(message, key)}|");
                        return;
                    case "decrypt":
                        Console.WriteLine($"|{Ciphers.CaesarsCipher.Decrypt(message, key)}|");
                        return;
                    case "bruteforce":
                        List<string> decryptedMessages = Ciphers.CaesarsCipher.BruteForce(message);

                        foreach (string decryptedText in decryptedMessages)
                        {
                            Console.WriteLine($"|{decryptedText}|");
                        }
                        return;
                    default:
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Valid input: caesarcipher [encrypt] [key] [message]");
                Console.WriteLine("Valid input: caesarcipher [decrypt] [key] [message]");
                Console.WriteLine("Valid input: caesarcipher [bruteforce] [message]");
                return;
            }
        }

        /// <summary>
        /// Console interface main menu
        /// </summary>
        static void MainMenu()
        {
            List<string> killCodes = new List<string> { "exit", "quit", "kill"};

            while (true)
            {
                Console.WriteLine("Select Cipher.");
                Console.WriteLine("1. Cesars cipher.");
                Console.WriteLine("2. Transposition cipher.\n");
                Console.WriteLine("Enter 'exit' to quit the program.\n");
                string usersSelection = Console.ReadLine();

                if (killCodes.Contains(usersSelection.ToLower()))
                {
                    return;
                }
                else
                {
                    switch (usersSelection)
                    {
                        case "1":
                            CCMenu();
                            break;
                        case "2":
                            TranspositionMenu();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Menu for the transposition option
        /// </summary>
        static void TranspositionMenu()
        {
            string message;
            string key;

            Console.WriteLine("1) Encrypt.");
            Console.WriteLine("2) Decrypt.");

            string userSelection = Console.ReadLine().Trim();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Enter message.\n");
                    message = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine("Enter a key.");
                        key = Console.ReadLine();
                        if (key.All(char.IsDigit))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid key.");
                            Console.WriteLine("Enter an integer.");
                        }
                    }
                    try
                    {
                        string encryptedMessage = Ciphers.TranspositionCipher.Encrypt(message, Convert.ToInt32(key));
                        Console.WriteLine($"|{encryptedMessage}|");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    Console.WriteLine("Enter the cipher text.");
                    message = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine("Enter the key.");
                        key = Console.ReadLine();
                        if (key.All(char.IsDigit))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid key.");
                            Console.WriteLine("Enter an integer.");
                        }
                    }
                    try
                    {
                        string decryptedMessage = Ciphers.TranspositionCipher.Decrypt(message, Convert.ToInt32(key));
                        Console.WriteLine($"| {decryptedMessage} |");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }

        /// <summary>
        /// Menu for the caesar cipher option
        /// </summary>
        static void CCMenu()
        {
            string message;
            string key;

            Console.WriteLine("1) Encrypt.");
            Console.WriteLine("2) Decrypt.");
            Console.WriteLine("3) Brute Force.");
            string userSelection = Console.ReadLine().Trim();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Enter message.\n");
                    message = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine("Enter a key.");
                        key = Console.ReadLine();
                        if (key.All(char.IsDigit))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter an integer.");
                        }
                    }
                    try
                    {
                        string encryptedMessage = Ciphers.CaesarsCipher.Encrypt(message, Convert.ToInt32(key));
                        Console.WriteLine($"|{encryptedMessage}|");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    Console.WriteLine("Enter message.\n");
                    message = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine("Enter a key.");
                        key = Console.ReadLine();
                        if (key.All(char.IsDigit))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter an integer.");
                        }
                    }
                    try
                    {
                        string encryptedMessage = Ciphers.CaesarsCipher.Decrypt(message, Convert.ToInt32(key));
                        Console.WriteLine($"|{encryptedMessage}|");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter message.\n");
                    message = Console.ReadLine();
                    List<string> decryptedMessages = Ciphers.CaesarsCipher.BruteForce(message);

                    foreach(string decryptedText in decryptedMessages)
                    {
                        Console.WriteLine($"|{decryptedText}|");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
}
