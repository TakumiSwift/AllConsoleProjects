using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesEmployeeDirectory
{
    internal class Program
    {
        /// <summary>
        /// Проверка наличия файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        static void FileExist(string path)
        {
            if (File.Exists(path) != true)
            {
                File.Create(path).Close();
            }
        }

        /// <summary>
        /// Приветствие пользователя
        /// </summary>
        static void Greeting()
        {
            Console.WriteLine("Программа-справочник о Сотрудниках");
        }
        
        /// <summary>
        /// Выбор режима работы программы
        /// </summary>
        static void SelectMode(string path)
        {
            while (true)
            {
                Console.Write("Выберите режим работы:\n" +
                              "1 - Вывод данных справочника на экран\n" +
                              "2 - Внесение данных нового сотрудника\n"+
                              "Введите 1\\2: ");
                string choise = Console.ReadLine();
                if (choise == "1")
                {
                    DataOutput(path);
                    break;
                }
                else if (choise == "2")
                { 
                    DataInput(path);
                    break;
                }
                else
                {
                    Console.WriteLine("Произошла ошибка ввода, попробуйте еще раз");
                }
            }
        }

        /// <summary>
        /// Вывод данных о сотрудниках
        /// </summary>
        /// <returns>Массив строк для вывода на экран</returns>
        static void DataOutput(string path)
        {
            Console.WriteLine("ID Дата добавления Ф.И.О.\tВозраст Рост Дата рождения\tМесто рождения");
            using (StreamReader output = new StreamReader(path))
            {
                string[] dataAll = output.ReadToEnd().Split('\n');
                string[] dataParam = new string[7];
                for (int i = 0; i<dataAll.Length; i++)
                {
                    dataParam = dataAll[i].Split('\t');
                    OutputToConsole(dataParam);
                }
            }
        }

        /// <summary>
        /// Ввод данных нового сотрудника с внесением в файл
        /// </summary>
        static void DataInput(string path)
        {
            Console.WriteLine("Для создания нового сотрудника введите даннные и нажмите Enter:");
            using (StreamWriter input = File.AppendText(path))
            {
                string[] param = new string[] { "ID", "Дата добавления", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };
                for (int i = 0; i < param.Length; i++)
                {
                    Console.Write($"Введите {param[i]}: ");
                    input.Write($"{Console.ReadLine()}\t");
                }
                input.Write("\n");
            }
        }

        /// <summary>
        /// Вывод информации в консоль
        /// </summary>
        /// <param name="args">Массив строк из файла</param>
        static void OutputToConsole(params string[] args)
        {
            foreach (string line in args)
            {
                Console.Write(line+" ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Зацикливание работы программы
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        static void ProgramCycling(string path)
        {
            while (true)
            {
                SelectMode(path);
                Console.WriteLine("Для продолжения работы программы введите \"+\", иначе любой другой символ");
                if (Console.ReadLine() != "+") break;
            }
        }
        
        static void Main(string[] args)
        {
            string pathToFile = @"F:\Visual Studio\Projects\AllConsoleProjects\AllConsoleProjects\Projects\FilesConsoleApp\FilesEmployeeDirectory\directory.rtf";
            FileExist(pathToFile);
            Greeting();
            ProgramCycling(pathToFile);
        }
    }
}
