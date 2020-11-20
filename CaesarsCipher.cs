// Chae DeLaRosa
// Caesar Cipher class with methods to encrypt, decrypt, and brute force messages
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciphers
{
    class CaesarsCipher
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!?.,";

        // Inputs: A string to be encrypted
        // The int key used in the encryption method to shift the character
        // Outputs: Encrypted string
        public string Encrypt(string message, int key)
        {
            StringBuilder encryptedMessage = new StringBuilder("");

            foreach (char letter in message)
            {
                if (characters.Contains(letter))
                {
                    int characterIndex = characters.IndexOf(letter) + key;
                    while (characterIndex >= characters.Length)
                    {
                        characterIndex -= characters.Length;
                    }

                    try
                    {
                        encryptedMessage.Append(characters[characterIndex]);
                    }
                    catch
                    {
                        Console.WriteLine($"Index {characterIndex} out of bounds");
                    }
                }
            }
            return Convert.ToString(encryptedMessage);
        }

        public string Decrypt(string encryptedMessage, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder("");
            foreach (char letter in encryptedMessage)
            {
                if (characters.Contains(letter))
                {
                    int characterIndex = characters.IndexOf(letter) - key;
                    while (characterIndex <= 0)
                    {
                        characterIndex += characters.Length-1;
                    }
                    try
                    {
                        decryptedMessage.Append(characters[characterIndex]);
                    }
                    catch
                    {
                        Console.WriteLine($"Index {characterIndex} out of bounds.");
                    }
                }
            }
            return Convert.ToString(decryptedMessage);
        }

        public List<string> BruteForce(string encryptedMessage)
        {
            List<string> decryptedTextList = new List<string> { };
            string decryptedMessage;

            for(int i = 1; i < characters.Length; i++)
            {
                decryptedTextList.Add(decryptedMessage = Decrypt(encryptedMessage, i));
            }

            return decryptedTextList;
        }
    }
}

