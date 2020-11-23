//Chae DeLaRosa
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciphers
{
    class TranspositionCipher
    {
        public string Encrypt(string message, int key)
        {
            StringBuilder encryptedMessage = new StringBuilder("");
            Dictionary<string, List<char>> encryptionBoxes = new Dictionary<string, List<char>> { };

            List<string> rowCharList = new List<string> { };

            for (int column = 0; column < key; column++)
            {
                int currentIndex = column;

                while (currentIndex < message.Length)
                {
                    encryptedMessage.Append(message[currentIndex]);

                    currentIndex += key;
                }
            }
            return Convert.ToString(encryptedMessage);
        }
    }
}
