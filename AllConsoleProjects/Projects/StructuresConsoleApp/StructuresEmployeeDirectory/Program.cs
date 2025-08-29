using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StructuresEmployeeDirectory
{
    internal class Program
    {
        /// <summary>
        /// Метод создания экземпляра репозитория
        /// </summary>
        static Repository CreatingRepository()
        {
            Repository repository = new Repository();
            repository.GetAllEmployee();
            return repository;
        }

        /// <summary>
        /// Выбор режима работы программы
        /// </summary>
        /// <param name="repository">Экземпляр созданного репозитория</param>
        static void OperatingMode(Repository repository)
        {
            Console.Write("Есть следующие виды работы программы:\n" +
                          "\"1\" - Вывод списка всех сотрудников на экран;\n" +
                          "\"2\" - Добавление нового сотрудника в список;\n" +
                          "\"3\" - Поиск сотрудника по его ID;\n" +
                          "\"4\" - Удаление сотрудника из списка по его ID;\n" +
                          "\"5\" - Поиск сотрудников в диапазоне дат(не включая последнюю дату);\n\n" +
                          "Введите режим работы: ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    repository.DisplayAllEmployee();
                    break;
                case 2:
                    repository.AddNewEmployee();
                    break;
                case 3:
                    Console.Write("Для поиска сотрудника введите его ID: ");
                    repository.FindEmployeeById(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 4:
                    Console.Write("Для удаления сотрудника введите его ID: ");
                    repository.DeleteEmployeeById(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 5:
                    Console.WriteLine("Для поиска в диапазоне дат введите начальную и конечную даты:");
                    repository.SearchBetweenTwoDates(Convert.ToDateTime(Console.ReadLine()),
                                                     Convert.ToDateTime(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Произошла ошибка ввода, попробуйте еще раз.");
                    break;
            }
        }

        /// <summary>
        /// Основной блок программы
        /// </summary>
        static void ProgramEngine()
        {
            Repository repository = CreatingRepository();
            bool flag = true;
            string answer = "";
            Console.Write("\t\tПрограмма работы со списком сотрудников\n\n\r");
            while (flag)
            {
                OperatingMode(repository);
                while (true)
                {
                    Console.Write("Хотите продолжить работу в программе?" +
                                  "Введите \"да\"/\"нет\": ");
                    answer = Console.ReadLine();
                    if (answer == "нет")
                    {
                        flag = false;
                        break;
                    }
                    else if (answer == "да")
                    {
                        Console.Clear();
                        break;
                    }
                    else Console.WriteLine("Ошибка ввода, попробуйте еще раз.");
                }
            }
            Console.Clear();
            Console.WriteLine("До свидания!");
            Thread.Sleep(2000);
        }

        static void Main(string[] args)
        {
            ProgramEngine();
        }
    }
}
