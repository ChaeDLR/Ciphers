// Chae DeLaRosa
// 
using System;


namespace Ciphers
{
    class Program
    {
        static string Menu()
        {
            Console.WriteLine("Select Cipher.");
            Console.WriteLine("1. Cesars cipher.");
            Console.WriteLine("Enter 'exit' to quit the program.");
            string usersSelection = Console.ReadLine();
            return usersSelection;
        }

        // Inputs: A string to encrypted or decrypted,
        // The int key used in the encryption method,
        // And the int of the encryption or decryption selection

        // Outputs: Encrypted or decrypted string
        static string CaesarsCipher(string message, int key, int encryptionflag)
        {
            // string of characters used for the encryption and decryption
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz !?.,";
            // Found this as a way to append to a string repeatedly 
            System.Text.StringBuilder encryptedMessage = new System.Text.StringBuilder("");

            // perform encryption or decryption based on the encryptionflag input
            switch (encryptionflag)
            {
                // encryption case
                case 1:
                    // loop through the message so we can work with each character individually
                    foreach (char letter in message)
                    {
                        // If the character in the message is in our character list
                        if (characters.Contains(letter))
                        {
                            // for encryption we want to take the index of the char and add the key
                            int characterIndex = characters.IndexOf(letter) + key;
                            // If the key is massive we need to be able to get it into a workable index
                            while (characterIndex >= characters.Length)
                            {
                                characterIndex -= characters.Length;
                            }
                            // append our encypted char to our ciphertext
                            encryptedMessage.Append(characters[characterIndex]);
                        }
                    }
                    break;
                // decryption case
                // same thing as encryption just backwards
                case 2:
                    foreach (char letter in message)
                    {
                        if (characters.Contains(letter))
                        {
                            int characterIndex = characters.IndexOf(letter) - key;
                            while (characterIndex <= 0)
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
            // Keep our program running until the user stops it
            bool running = true;
            while (running)
            {
                // grab our users selection
                string menuSelection = Menu().ToLower();
                // Decide what to do with it
                switch (menuSelection)
                {
                    // caesars cipher
                    case "1":
                        Console.WriteLine("Make a selection.");
                        Console.WriteLine("1. Encrypt");
                        Console.WriteLine("2. Decrypt");
                        int encryptionSelection = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your message.");
                        string message = Console.ReadLine();
                        Console.WriteLine("Enter a key.");
                        int key = Convert.ToInt32(Console.ReadLine());
                        // Execute cipher
                        string alteredMessage = CaesarsCipher(message, key, encryptionSelection);
                        // Decide what to print to the user depending on their selection
                        if (encryptionSelection == 1)
                        {
                            Console.WriteLine($"Encrypted message: \"{alteredMessage}\"");
                        }
                        else
                        {
                            Console.WriteLine($"Decrypted message: \"{alteredMessage}\"");
                        }
                        break;
                    case "exit":
                        Console.WriteLine("Quiting program...");
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
