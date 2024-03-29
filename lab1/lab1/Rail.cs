﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public static class Rail
    {
        public static void Run()
        {
            Console.WriteLine("\n\nМетож железнодорожной изгороди");
            Console.WriteLine("\nВведите строку: ");
            string clearText = Console.ReadLine(); ;
            Console.WriteLine("\nВведите ключ: ");
            var key = int.Parse(Console.ReadLine());

            string cipherText = Cipher(clearText, key);
            Console.WriteLine("Зашифрованный текст: {0}", cipherText);

            Console.WriteLine();

            string decipherText = Decipher(cipherText, key);
            Console.WriteLine("Расшифрованный текст: {0}", decipherText);

            Console.ReadKey();
        }

        private static char[][] BuildCleanMatrix(int rows, int cols)
        {
            char[][] result = new char[rows][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new char[cols];
            }

            return result;
        }

        private static string BuildStringFromMatrix(char[][] matrix)
        {
            string result = string.Empty;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != '\0')
                    {
                        result += matrix[row][col];
                    }
                }
            }

            return result;
        }

        private static char[][] Transpose(char[][] matrix)
        {
            char[][] result =
                BuildCleanMatrix(matrix[0].Length, matrix.Length);

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    result[col][row] = matrix[row][col];
                }
            }

            return result;
        }

        private static string Cipher(string clearText, int key)
        {
            string result = string.Empty;

            char[][] matrix = BuildCleanMatrix(key, clearText.Length);

            int rowIncrement = 1;
            for (int row = 0, col = 0; col < matrix[row].Length; col++)
            {
                if (
                    row + rowIncrement == matrix.Length ||
                    row + rowIncrement == -1
                    )
                {
                    rowIncrement *= -1;
                }

                matrix[row][col] = clearText[col];

                row += rowIncrement;
            }

            result = BuildStringFromMatrix(matrix);

            return result;
        }

        private static string Decipher(string cipherText, int key)
        {
            string result = string.Empty;

            char[][] matrix = BuildCleanMatrix(key, cipherText.Length);

            int rowIncrement = 1;
            int textIdx = 0;

            for (
                int selectedRow = 0;
                selectedRow < matrix.Length;
                selectedRow++
                )
            {
                for (
                    int row = 0, col = 0;
                    col < matrix[row].Length;
                    col++
                    )
                {
                    if (
                        row + rowIncrement == matrix.Length ||
                        row + rowIncrement == -1
                        )
                    {
                        rowIncrement *= -1;
                    }

                    if (row == selectedRow)
                    {
                        matrix[row][col] = cipherText[textIdx++];
                    }

                    row += rowIncrement;
                }
            }

            matrix = Transpose(matrix);
            result = BuildStringFromMatrix(matrix);

            return result;
        }
    }
}
