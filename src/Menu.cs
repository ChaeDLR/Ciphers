// Chae DeLaRosa
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers
{
    class Menu
    {

        internal List<string> killCodes = new List<string> { "exit", "quit", "kill", "q" };

        /// <summary>
        /// if the user uses the transposition arg
        /// </summary>
        /// <param name="message"></param>
        /// <param name="option"></param>
        /// <param name="key"></param>
        public void TranspositionArgs(string message, string option, int key)
        {
            try
            {
                switch (option.ToLower())
                {
                    case "-e":
                        Console.WriteLine($"{Ciphers.TranspositionCipher.Encrypt(message, key)}");
                        return;
                    case "-d":
                        Console.WriteLine($"{Ciphers.TranspositionCipher.Decrypt(message, key)}");
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
        public void CaesarCipherArgs(string message, string option, int key = 1)
        {
            try
            {
                switch (option.ToLower())
                {
                    case "-e":
                        Console.WriteLine($"{Ciphers.CaesarsCipher.Encrypt(message, key)}");
                        return;
                    case "-d":
                        Console.WriteLine($"{Ciphers.CaesarsCipher.Decrypt(message, key)}");
                        return;
                    case "-b":
                        List<string> decryptedMessages = Ciphers.CaesarsCipher.BruteForce(message);

                        foreach (string decryptedText in decryptedMessages)
                        {
                            Console.WriteLine($"{decryptedText}");
                        }
                        return;
                    default:
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Valid input: caesarcipher [mode (encrypt,decrypt,bruteforce): -e, -d, -b] [key: int] [message]");
                return;
            }
        }

        /// <summary>
        /// Console interface main menu
        /// </summary>
        public void MainMenu()
        {

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
        public void TranspositionMenu()
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
        public void CCMenu()
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

                    foreach (string decryptedText in decryptedMessages)
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