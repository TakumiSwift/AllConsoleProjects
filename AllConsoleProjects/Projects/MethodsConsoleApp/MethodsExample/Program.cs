using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MethodsExample
{
    internal class Program
    {
        static void Engine (int engineWorktime)
        {
            Console.Clear();
            bool flag = true;
            int count = 0;
            int cycleTime = DateTime.Now.Minute + engineWorktime;
            while (flag)
            {
                if (DateTime.Now.Minute != cycleTime)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case (0):
                                Console.WriteLine("_   _\n" +
                                                  "|\\_/|\n" +
                                                  "||_||\n" +
                                                  "| | |\n" +
                                                  "|_|_|");
                                break;
                            case (1):
                                Console.WriteLine("_   _\n" +
                                                  "|\\ /|\n" +
                                                  "| _ |\n" +
                                                  "||_||\n" +
                                                  "|_\\_|");
                                break;
                            case (2):
                                Console.WriteLine("_   _\n" +
                                                  "|\\ /|\n" +
                                                  "|   |\n" +
                                                  "| _ |\n" +
                                                  "||_||");
                                break;
                            case (3):
                                Console.WriteLine("_   _\n" +
                                                  "|\\ /|\n" +
                                                  "| _ |\n" +
                                                  "||_||\n" +
                                                  "|_/_|");
                                break;
                        }
                        Console.Write($"Время работы двигателя : {cycleTime-DateTime.Now.Minute} мин.\n Количесвто оборотов={count}");
                        Thread.Sleep(200);
                        Console.Clear();
                    }
                    count++;
                }
                else flag = false;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите время работы двигателя в минутах: ");
            Engine(Convert.ToInt32(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
