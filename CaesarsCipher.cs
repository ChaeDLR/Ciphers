// Chae DeLaRosa
// Caesar Cipher class with methods to encrypt, decrypt, and brute force messages
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciphers
{
    public static class CaesarsCipher
    {
        private const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz !?.,";

        /// <summary>
        /// The int key used in the encryption method to shift the character
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns> encrypted string </returns>
        public static string Encrypt(string message, int key)
        {
            message = message.Trim();
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

        /// <summary>
        /// Decrypt a string using a key
        /// </summary>
        /// <param name="encryptedMessage"></param>
        /// <param name="key"></param>
        /// <returns> decrypted string </returns>
        public static string Decrypt(string encryptedMessage, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder("");
            foreach (char letter in encryptedMessage)
            {
                if (characters.Contains(letter))
                {
                    int characterIndex = characters.IndexOf(letter) - key;
                    while (characterIndex <= 0)
                    {
                        characterIndex += characters.Length;
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

        /// <summary>
        /// Bruteforce a string
        /// </summary>
        /// <param name="encryptedMessage"></param>
        /// <returns> List of all possible decryptions </returns>
        public static List<string> BruteForce(string encryptedMessage)
        {
            List<string> decryptedTextList = new List<string> { };

            for(int i = 1; i < characters.Length; i++)
            {
                decryptedTextList.Add(Decrypt(encryptedMessage, i));
            }

            return decryptedTextList;
        }
    }
}

