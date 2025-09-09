using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        /// <summary>
        /// Метод создания Справочника
        /// </summary>
        /// <returns>Пустой Справочник</returns>
        static Dictionary <long, string> CreateDirectory ()
        {
            Dictionary <long, string> dir = new Dictionary <long, string> ();
            return dir;
        }

        /// <summary>
        /// Метод добавления новых клиентов в справочник
        /// </summary>
        /// <param name="dir">Справочник</param>
        static void AddToDirectory( Dictionary <long, string> dir )
        {
            Console.Write("Введите Ф.И.О. клиента, к кому будут прикрепляться " +
                          "последующие номера: ");
            string value = Console.ReadLine();
            Console.WriteLine("Вводите построчно номера клиента, разделяя их " +
                              "нажатием клавиши \"Enter\".\n" +
                              "Для завершения добавления введите \"0\" и нажмите \"Enter\"");
            while (true)
            {
                long key = Convert.ToInt64(Console.ReadLine());
                if (key != 0)
                {
                    dir.Add(key, value);
                }
                else break;
            }
        }

        /// <summary>
        /// Метод поиска клиента по его номеру
        /// </summary>
        /// <param name="dir">Справочник</param>
        static void FindByNumber( Dictionary <long, string> dir )
        {
            Console.Write("Введите номер телефона клиента для поиска: ");
            long key = Convert.ToInt64(Console.ReadLine());
            string value;
            if (dir.TryGetValue(key, out value) == true)
            {
                Console.WriteLine($"По номеру {key} найден клиент - {value}");
            }
            else
            {
                Console.WriteLine("Клиентов с таким номером телефона не найдено");
            }
        }

        /// <summary>
        /// Метод вывода списка клиентов в консоль
        /// </summary>
        /// <param name="dir">Справочник</param>
        static void PrintDirectory( Dictionary <long, string> dir )
        {
            foreach (var item in dir)
            {
                Console.WriteLine($"{item.Value}-{item.Key}");
            }
        }

        /// <summary>
        /// Основной блок программы
        /// </summary>
        static void ProgramOn()
        {
            Dictionary<long, string> dir = CreateDirectory();
            while (true)
            {
                Console.WriteLine("\t\tПрограмма-справочник номеров телефонов клиентов\n" +
                              "\rРежимы работы программы:\n" +
                              "\"1\"-добавление клиента;\n" +
                              "\"2\"-поиск клиентов по его номеру телефона\n" +
                              "\"3\"-вывод списка всех клиентов\n" +
                              "Для выхода из программы введите пустую строку");
                Console.Write("Введите режим работы: ");
                string choise = Console.ReadLine();
                if ( choise == "1" )
                {
                    AddToDirectory(dir);
                }
                else if ( choise == "2" )
                {
                    FindByNumber(dir);
                }
                else if ( choise =="3" )
                {
                    PrintDirectory(dir);
                }
                else if ( choise == "" )
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода, попробуйте еще раз.");
                }
                Console.ReadLine();
                Console.Clear();
            }
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
