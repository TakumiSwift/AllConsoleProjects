using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        
        /// <summary>
        /// Метод создания List'а
        /// </summary>
        /// <returns>List целых чисел</returns>
        static List <int> CreateList()
        {
            List <int> numbers = new List<int>();
            return numbers;
        }

        /// <summary>
        /// Метод наполнения List'а
        /// </summary>
        /// <param name="numbers">Заранее созданный List целых чисел</param>
        /// <returns>Наполненный числами List</returns>
        static List <int> FillList(List <int> numbers)
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(r.Next(0, 101));
            }
            return numbers;
        }

        /// <summary>
        /// Метод вывода List'а на экран
        /// </summary>
        /// <param name="numbers">Заполненный List</param>
        static void PrintList(List <int> numbers)
        {
            for (int i = 0; i < numbers.Count; i += 3)
            {
                if (i < numbers.Count - 2)
                { Console.WriteLine($"{numbers[i]}\t{numbers[i + 1]}\t{numbers[i + 2]}"); }
                else
                {
                    Console.WriteLine($"{numbers[i]}\t");
                    i -= 2;
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Метод удаления чисел, не входящих в указанные границы
        /// </summary>
        /// <param name="numbers">Заполненный List</param>
        /// <returns>Отредактированный List</returns>
        static List <int> ChangeList(List <int> numbers)
        {
            numbers.RemoveAll(x => x > 25 && x < 50);
            return numbers;
        }

        /// <summary>
        /// Запуск программы для пользователя
        /// </summary>
        static void ProgramOn()
        {
            List <int> block = CreateList();
            FillList(block);
            PrintList(block);
            ChangeList(block);
            PrintList(block);
        }

        /// <summary>
        /// Клиентский блок программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ProgramOn();
        }
    }
}
