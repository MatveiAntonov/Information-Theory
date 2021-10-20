using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            string userChoice;

            do
            {
                Console.WriteLine("Выберите шифр: ");
                Console.WriteLine("1: Метод железнодорожной изгороди");
                Console.WriteLine("2: Столбцовый метод");
                Console.WriteLine("3: Метод поворачивающейся решетки");
                Console.WriteLine("4: Шифр Цезаря");
                Console.WriteLine("5: Выход");
                Console.Write("Введите номер шифра: ");
                userChoice = Console.ReadLine();

                if (!Int32.TryParse(userChoice, out num)) continue;

                if (userChoice == "5")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("Выбор = " + userChoice);

                if (userChoice == "1")
                {
                    Rail.Run();
                }

                if (userChoice == "2")
                {
                    Column.Run();
                }

                if (userChoice == "3")
                {
                    Rotate.Run();
                }

                if (userChoice == "4")
                {
                    Cezar.Run();
                }

            } while (true);
        }
    }
}
