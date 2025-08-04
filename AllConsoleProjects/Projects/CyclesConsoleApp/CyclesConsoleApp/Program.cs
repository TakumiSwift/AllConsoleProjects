using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CyclesConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Task 1
            //Write("Введите целое число на проверку четности :");
            //int userNumber = Convert.ToInt32(Console.ReadLine());
            //if ((userNumber % 2) == 0) Write("\nЧисло четное");
            //else Write("Число нечетное");
            //ReadKey();
            //Clear();
            #endregion

            #region Task 2
            //WriteLine("Программа помощи подсчёта карт на руке в игре \"21\"." +
            //          "\nДля корректности работы имейте в виду обозначения карт :" +
            //          "\nВалет - J\nДама - Q\nКороль - K\nТуз - A" +
            //          "\n*все значения вводятся на латинице большими буквами");
            //Write("Введите кол-во ваших карт : ");
            //byte numberCards = Convert.ToByte(Console.ReadLine());
            //string scoreCard;
            //byte result = 0;
            //bool flag;
            //for (byte i = 1; i < numberCards + 1; i++)
            //{
            //    Write($"\nВведите значение {i}-й карты : ");
            //    scoreCard = Console.ReadLine();
            //    flag = (scoreCard == "J" || scoreCard == "Q" || scoreCard == "K" || scoreCard == "A");
            //    switch (scoreCard)
            //    {
            //        case "6":
            //            result += 6;
            //            break;
            //        case "7":
            //            result += 7;
            //            break;
            //        case "8":
            //            result += 8;
            //            break;
            //        case "9":
            //            result += 9;
            //            break;
            //        case "10":
            //            result += 10;
            //            break;
            //        default:
            //            if (flag)
            //            {
            //                result += 10;
            //            }
            //            else
            //            {
            //                WriteLine("Такого значения не может быть, попробуйте еще раз");
            //                --i;
            //            }
            //            break;
            //    }
            //}
            //Write("Сумма карт на руке = {0}", result);
            //ReadKey();
            #endregion

            #region Task 3
            //WriteLine("Проверка является ли число простым.");
            //Write("Введите целое положительное число для проверки : ");
            //bool flag = false;
            //int checkNumber = Convert.ToInt32(ReadLine());
            //if (checkNumber > 1)
            //{
            //    //for (int i = 2; i < checkNumber ; i++)
            //    //{
            //    //    if (checkNumber % i == 0)  // Вариант решения №1
            //    //    {
            //    //        flag = false;
            //    //        break;
            //    //    }
            //    //    else flag = true;
            //    //}
            //    int j = 2;
            //    while (j < checkNumber)
            //    {
            //        if (checkNumber % j == 0)  // Вариант решения №2
            //        {
            //            flag = false;
            //            break;
            //        }
            //        else flag = true;
            //        j++;
            //    }
            //    if (flag) WriteLine("Число простое");
            //    else WriteLine("Число составное");
            //    ReadKey();
            //}
            //else
            //{
            //    WriteLine("Введенное число не является ни простым, ни составным");
            //    ReadKey();
            //}
            #endregion

            #region Task 4
            //WriteLine("Нахождение наименьшего числа в последовательности целых чисел.");
            //int length = 0;
            //int minValue = int.MaxValue;
            //int enteredValue = 0;
            //bool flag = true;
            //while (flag)
            //{
            //    Write("Введите длину последовательности : ");
            //    length = Convert.ToInt32(ReadLine());
            //    if (length > 0)
            //    {
            //        for (int i = 0; i < length; i++)
            //        {
            //            Write("\nВведите число : ");
            //            enteredValue = Convert.ToInt32(ReadLine());
            //            if (enteredValue < minValue)
            //            {
            //                minValue = enteredValue;
            //            }
            //        }
            //        flag = false;
            //    }
            //    else
            //    {
            //        WriteLine("Ошибка ввода, попробуйте снова");
            //    }
            //}
            //WriteLine("\nНаименьшим числом в последовательности является {0}", minValue);
            //ReadKey();
            #endregion

            #region Task 5
            //Random gameEngine = new Random();
            //int rangeRandom;
            //int win;
            //int answer = -1;
            //bool flag = true;
            //byte decision;
            //WriteLine("Приветствую в игре \"Угадай число, битва с рандомом\"!");
            //while (flag)
            //{
            //    WriteLine("\n\nИгра будет для целых чисел в диапазоне от 0 до : ");
            //    rangeRandom = Convert.ToInt32(Console.ReadLine());
            //    win = gameEngine.Next(rangeRandom);
            //    WriteLine("Если вы устали играть, то вместо ввода числа введите пустую строку и нажмите Enter");
            //    WriteLine("Итак, число загадано, каков Ваш ответ?");
            //    while (win != answer)
            //    {
            //        string pause = ReadLine();
            //        if (pause != "")
            //        {
            //            answer = Convert.ToInt32(pause);
            //            if (answer > win)
            //            {
            //                WriteLine("К сожалению, вы не угадали, Ваше число больше загаданного." +
            //                          "\n Попробуйте еще раз!");
            //            }
            //            else
            //            {
            //                if (answer == win)
            //                {
            //                    WriteLine("Поздравляю, вы отгадали число, хотите попробовать еще раз?" +
            //                              "\n1 - да, 0 - нет");
            //                    decision = Convert.ToByte(Console.ReadLine());
            //                    if (decision == 0) flag = false;
            //                    else flag = true;
            //                }
            //                else
            //                {
            //                    WriteLine("К сожалению, вы не угадали, Ваше число меньше загаданного." +
            //                              "\n Попробуйте еще раз!");
            //                }
            //            }
            //        }
            //        else
            //        {
            //            WriteLine("На этом моменте игра останавливается. Вы признали поражение.\n" +
            //                      "Ответом было число : {0}", win);
            //            flag = false;
            //            break;
            //        }
            //    }
            //}
            #endregion
        }
    }
}
