using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Threading;

namespace Task4
{
    internal class Program
    {
        
        /// <summary>
        /// Создание коллекции Diary
        /// </summary>
        /// <returns>Новая коллекция Diary</returns>
        static Diary DiaryCreate()
        {
            Diary dir = new Diary();
            dir.LoadFromFile();
            return dir;
        }

        /// <summary>
        /// Метод выбора режимов работы
        /// </summary>
        /// <param name="dir">Коллекция Diary</param>
        static void OperatingMode(Diary dir)
        {
            bool think = true;
            while (think)
            {
                Console.WriteLine("Режимы работы программы:\n" +
                                  "\"1\" - Вывод данных в консоль;\n" +
                                  "\"2\" - Добавление новой персоны;\n" +
                                  "\"3\" - Выход из программы.");
                Console.Write("Введите режим работы: ");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        dir.PrintList();
                        Console.WriteLine("\nНажмите Enter для продолжения работы");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        dir.AddNewNote();
                        dir.LoadFromFile();
                        Thread.Sleep(3000);
                        break;
                    case "3":
                        think = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка ввода, попробуйте еще раз.");
                        Thread.Sleep(500);
                        break;
                }
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("До свидания!");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        static void ProgramOn()
        {
            OperatingMode(DiaryCreate());
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
