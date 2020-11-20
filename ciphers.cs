// Chae DeLaRosa
// Cipher console program to encrypt and decrypt messages
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers
{
    class Program
    {

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
                    default:
                        Console.WriteLine("Valid input: caesarcipher [encrypt] [key] [message]");
                        Console.WriteLine("Valid input: caesarcipher [decrypt] [key] [message]");
                        Console.WriteLine("Valid input: caesarcipher [bruteforce] [message]");
                        return;
                }
            }
            catch
            {
                MainMenu();
            }
        }

        static void CaesarCipherArgs(string message, string option, int key = 1)
        {
            try
            {
                CaesarsCipher caesarsCipher = new CaesarsCipher { };

                switch (option.ToLower())
                {
                    case "encrypt":
                        Console.WriteLine($"\"{caesarsCipher.Encrypt(message, key)}\"");
                        return;
                    case "decrypt":
                        Console.WriteLine($"\"{caesarsCipher.Decrypt(message, key)}\"");
                        return;
                    case "bruteforce":
                        List<string> decryptedMessages = caesarsCipher.BruteForce(message);

                        foreach (string decryptedText in decryptedMessages)
                        {
                            Console.WriteLine($"\"{decryptedText}\"");
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

        static void MainMenu()
        {
            List<string> killCodes = new List<string> { "exit", "quit", "kill"};

            while (true)
            {
                Console.WriteLine("Select Cipher.");
                Console.WriteLine("1. Cesars cipher.\n");
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
                    }
                }
            }
        }

        static void CCMenu()
        {
            CaesarsCipher caesarsCipher = new CaesarsCipher { };

            string message;
            string key;

            Console.WriteLine("1) Encrypt.");
            Console.WriteLine("2) Decrypt.");
            Console.WriteLine("3) Brute Force.");
            string userSelection = Console.ReadLine();

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
                        string encryptedMessage = caesarsCipher.Encrypt(message, Convert.ToInt32(key));
                        Console.WriteLine(encryptedMessage);
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
                        string encryptedMessage = caesarsCipher.Decrypt(message, Convert.ToInt32(key));
                        Console.WriteLine(encryptedMessage);
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
                    List<string> decryptedMessages = caesarsCipher.BruteForce(message);

                    foreach(string decryptedText in decryptedMessages)
                    {
                        Console.WriteLine($"\"{decryptedText}\"");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
}
