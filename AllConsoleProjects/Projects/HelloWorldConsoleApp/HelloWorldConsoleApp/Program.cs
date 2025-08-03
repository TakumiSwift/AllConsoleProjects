using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HelloWorldConsoleApp
{
    /// <summary>
    /// Класс программы
    /// </summary>
    internal class Program
    {/// <summary>
    /// Точка входа программы
    /// </summary>
    /// <param name="args">Параметры запуска программы</param>
        static void Main(string[] args)
        {
            WriteLine("Снова привет, мир!");
            ReadKey();
            Write("Снова ");
            Write("привет, ");
            Write("мир!");
            ReadKey();
            
        }
    }
}
