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
                    }
                    catch
                    {
                        encryptedMessage.Append("x");
                    }

                    currentIndex += key;
                }
            }
            return Convert.ToString(encryptedMessage);
        }

        /// <summary>
        /// Reverse transpose a string
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string message, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder("");
            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage.Append(" ");
            }

            int encryptionBoxRows = message.Length / key;
            int index = 0;

            for (int row = 0; row < encryptionBoxRows; row++)
            {
                int matrixIndex = row;

                for (int i = 0; i <= key; i++)
                {
                    if (matrixIndex < message.Length)
                    {
                        decryptedMessage.Replace(
                            char.Parse(" "), message[matrixIndex], index++, 1
                            );
                    }
                    matrixIndex += encryptionBoxRows;
                }
            }
            return Convert.ToString(decryptedMessage);
            
        }
    }
}
