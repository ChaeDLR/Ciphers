using System;
using System.Collections.Generic;
using System.Text;

namespace Ciphers
{
    class CaesarsCipher
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!?.,";

        // Inputs: A string to encrypted or decrypted,
        // The int key used in the encryption method,
        // And the int of the encryption or decryption selection
        // Outputs: Encrypted or decrypted string
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
                    encryptedMessage.Append(characters[characterIndex]);
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
                        characterIndex += characters.Length;
                    }
                    decryptedMessage.Append(characters[characterIndex]);
                }
            }
            return Convert.ToString(decryptedMessage);
        }
    }
}

