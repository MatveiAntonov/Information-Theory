using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Cezar
    {
        public static void Run()
        {
            Console.WriteLine("\n\nШифр Цезаря");
            var cipher = new Cezar();
            Console.Write("Введите строку: ");
            var message = Console.ReadLine();
            Console.Write("Введите ключ: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cipher.Encrypt(message, secretKey);
            Console.WriteLine("Зашифрованный текст: {0}", encryptedText);
            Console.WriteLine("Расшифрованный текст: {0}", cipher.Decrypt(encryptedText, secretKey));
            Console.ReadLine();
        }

        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }
}
