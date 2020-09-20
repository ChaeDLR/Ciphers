using System;
using System.Net.Http;

namespace Ciphers
{
    class Program
    {
        static int Menu()
        {
            Console.WriteLine("Select Cipher.");
            Console.WriteLine("1. Cesars cipher.");
            Console.WriteLine("2. Exit the program.");
            string usersSelection = Console.ReadLine();
            return Convert.ToInt32(usersSelection);
        }
        static string CaesarsCipher(string message, int key, int encryptionflag)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,?! ";

            System.Text.StringBuilder encryptedMessage = new System.Text.StringBuilder("");

            switch (encryptionflag)
            {
                case 1:
                    foreach (char letter in message)
                    {
                        if (characters.Contains(letter))
                        {
                            int characterIndex = characters.IndexOf(letter) + key;
                            if (characterIndex >= characters.Length)
                            {
                                characterIndex -= characters.Length;
                            }
                            
                            encryptedMessage.Append(characters[characterIndex]);
                        }
                    }
                    break;

                case 2:
                    foreach (char letter in message)
                    {
                        if (characters.Contains(letter))
                        {
                            int characterIndex = characters.IndexOf(letter) - key;
                            if (characterIndex <= 0)
                            {
                                characterIndex += characters.Length;
                            }
                            
                            encryptedMessage.Append(characters[characterIndex]);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return Convert.ToString(encryptedMessage);
        }
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                int menuSelection = Menu();

                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("Make a selection.");
                        Console.WriteLine("1. Encrypt");
                        Console.WriteLine("2. Decrypt");
                        int encryptionSelection = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your message.");
                        string message = Console.ReadLine();
                        Console.WriteLine("Enter a key.");
                        int key = Convert.ToInt32(Console.ReadLine());
                        string alteredMessage = CaesarsCipher(message, key, encryptionSelection);
                        if (encryptionSelection == 1)
                        {
                            Console.WriteLine($"Encrypted message: \"{alteredMessage}\"");
                        }
                        else
                        {
                            Console.WriteLine($"Decrypted message: \"{alteredMessage}\"");
                        }
                        break;
                    case 2:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }
            }
        }
    }
}
