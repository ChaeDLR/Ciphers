//Chae DeLaRosa
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciphers
{
    public static class TranspositionCipher
    {
        /// <summary>
        /// Transpose message using key as the number of columns
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns>encrypted message as a string</returns>
        public static string Encrypt(string message, int key)
        {
            string fixedMessage = message.Trim();
            fixedMessage = fixedMessage.Replace(" ", string.Empty);
            Console.WriteLine($"Fixed string : {fixedMessage}");

            StringBuilder encryptedMessage = new StringBuilder("");
            int encryptionBoxRows = fixedMessage.Length / key;
            for (int column = 0; column < key; column++)
            {
                int currentIndex = column;

                for (int i = 0; i <= encryptionBoxRows; i++)
                {
                    try
                    {
                        encryptedMessage.Append(fixedMessage[currentIndex]);
                        Console.WriteLine($"Current Index = {currentIndex}");
                    }
                    catch
                    {
                        encryptedMessage.Append("x");
                    }

                    currentIndex += key;
                }
            }
            Console.WriteLine(fixedMessage.Length);
            return Convert.ToString(encryptedMessage);
        }

        public static string Decrypt(string message, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder("");

            return Convert.ToString(decryptedMessage);
            
        }
    }
}
