﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public static class Column
    {
        private static char[,] charMatrix;

        public static void Run()
        {
            Console.WriteLine("\n\nСтолбцовый метод: ");
            Console.WriteLine("\nВведите строку: ");
            string text = Console.ReadLine();
            Console.WriteLine("\nВведите ключ: ");
            String key = Console.ReadLine();
            if (key != null && text != null)
            {
                String upperText = text.ToUpperInvariant();
                String upperKey = key.ToUpperInvariant();
                upperText = upperText.Replace(" ", "");

                String encryption = columnEncrypt(upperText, upperKey);
                Console.WriteLine("Зашифрованный текст: " + encryption.Replace("*", ""));
                Console.WriteLine("Расшифрованный текст: " + columnDecrypt(encryption, upperKey));
            }
        }

        private static int[] GetKeyNumEncrypt(String key)
        {
            char c = (char)2000;
            int[] keyNumArr = new int[key.Length];

            StringBuilder _key = new StringBuilder(key);
            for (int i = 0; i < _key.Length; i++)
            {
                int min = i;
                for (int j = 0; j < _key.Length; j++)
                {
                    if (_key[j] != c)
                    {
                        min = j;
                        break;
                    }
                }

                for (int j = 0; j < _key.Length; j++)
                {
                    if ((int)_key[j] < (int)_key[min])
                    {
                        min = j;
                    }
                }

                keyNumArr[i] = min;
                _key[min] = c;
            }

            return keyNumArr;
        }

        private static int[] GetKeyNumDecrypt(String key)
        {
            int[] keyNumArr = new int[key.Length];
            StringBuilder _key = new StringBuilder(key);

            for (int i = 0; i < _key.Length; i++)
            {
                int min = 0;
                for (int j = 0; j < _key.Length; j++)
                {
                    if ((int)_key[i] > (int)_key[j])
                    {
                        min++;
                    }
                    else if (((int)_key[i] == (int)_key[j]) && (i > j))
                    {
                        min++;
                    }
                }

                keyNumArr[i] = min;
            }

            return keyNumArr;
        }

        private static String columnEncrypt(String text, String key)
        {
            int col = key.Length;
            int row = 0;
            String tempr = "";

            while (tempr.Length < text.Length)
            {
                tempr += key;
                row++;
            }

            var charMatrix = new char[row, col];

            while (text.Length % col != 0)
            {
                text += '*';
            }

            int index = 0;
            int m = 0;
            while (index < text.Length)
            {
                int n = 0;
                while (n < col && index < text.Length)
                {
                    charMatrix[m, n] = text[index];
                    n++;
                    index++;
                }

                m++;
            }

            String resultText = "";
            int[] keyNumArr = GetKeyNumEncrypt(key);
            for (int i = 0; i < keyNumArr.Length; i++)
            {
                int number = keyNumArr[i];
                for (int j = 0; j < row; j++) resultText += charMatrix[j, number];
            }

            return resultText;
        }

        private static String columnDecrypt(String text, String key)
        {
            int col = key.Length;

            int[] keyNumArr = GetKeyNumDecrypt(key);

            int row = text.Length / col;
            var charMatrix = new char[row, col];
            int m = 0;
            int index = 0;
            while (index < text.Length)
            {
                int n = 0;
                while (n < text.Length / col)
                {
                    charMatrix[n, m] = text[index];
                    n++;
                    index++;
                }

                m++;
            }

            char[,] charMatrix2 = new char[row, col];

            for (int i = 0; i < col; i++)
            {
                int number = keyNumArr[i];
                for (int j = 0; j < row; j++)
                {
                    charMatrix2[j, i] = charMatrix[j, number];
                }
            }

            String resultText = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    resultText += charMatrix2[i, j];
                }
            }

            return resultText.Replace("*", "");
        }
    }
}
