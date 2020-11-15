// Chae DeLaRosa
// Cipher console program to encrypt and decrypt messages
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers
{
    class Program
    {
        static string Menu()
        {
            Console.WriteLine("Select Cipher.");
            Console.WriteLine("1. Cesars cipher.\n");
            Console.WriteLine("Enter 'exit' to quit the program.\n");
            string usersSelection = Console.ReadLine();
            return usersSelection;
        }

        static void CCMenu()
        {
            CaesarsCipher caesarsCipher = new CaesarsCipher { };

            string message;
            string key;

            Console.WriteLine("1) Encrypt.");
            Console.WriteLine("2) Decrypt.");
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
            }
        }


        static void Main(string[] args)
        {
            List<string> killCodes = new List<string> { };

            while (true)
            {
                string menuSelection = Menu().ToLower();
                
                if (killCodes.Contains(menuSelection.ToLower()))
                {
                    break;
                }
                else
                {
                    switch (menuSelection)
                    {
                        case "1":
                            CCMenu();
                            break;
                        case "2":
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
