using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        /// <summary>
        /// Метод создания коллекции HashSet
        /// </summary>
        /// <returns>Новая коллекция HashSet</returns>
        static HashSet<int> CollectionCreate()
        {
            HashSet<int> result = new HashSet<int>();
            return result;
        }

        /// <summary>
        /// Метод добавления уникального числа в коллекцию HashSet
        /// </summary>
        /// <param name="col">Исходная коллекция HashSet</param>
        /// <param name="userNumber">Пользовательское число</param>
        static void AddNewNumber(int userNumber,HashSet<int> col)
        {
            col.Add(userNumber);
        }

        /// <summary>
        /// Метод проверки уникальности пользовательского числа
        /// </summary>
        /// <param name="userNumber">Пользовательское число</param>
        /// <param name="col">Исходная коллекция HashSet</param>
        /// <returns>Логический ответ проверки на уникальность пользовательского числа</returns>
        static bool OriginalityCheck(int userNumber, HashSet<int> col)
        {
            return col.Contains(userNumber);
        }

        /// <summary>
        /// Метод вывода в консоль коллекции
        /// </summary>
        /// <param name="col">Коллекция HashSet</param>
        static void PrintCollection(HashSet<int> col)
        {
            foreach(var item in col)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Основной блок программы
        /// </summary>
        static void ProgramOn()
        {
            HashSet<int> col = CollectionCreate();
            while (true)
            {
                Console.Write("Введите число, для добавления в коллекцию HashSet: ");
                int result = Convert.ToInt32(Console.ReadLine());
                if (OriginalityCheck(result, col))
                {
                    Console.WriteLine("Число уже присутствует в коллекции HashSet");
                    PrintCollection(col);
                }
                else
                {
                    AddNewNumber(result, col);
                    Console.WriteLine("Число успешно добавлено");
                    PrintCollection(col);
                }
                Console.Write("Для продолжения введите \"1\", для остановки программы \"2\": ");
                if (Console.ReadLine() == "2") break;
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            ProgramOn();
        }
    }
}
