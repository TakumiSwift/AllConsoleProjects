using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresEmployeeDirectory
{
    class Repository
    {
        #region Поля

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string pathToFile;

        /// <summary>
        /// Массив экземпляров сотрудника
        /// </summary>
        Employee[] employeeArray;

        /// <summary>
        /// Индекс элемента массива сотрудников
        /// </summary>
        int index;

        /// <summary>
        /// Строковый массив заголовков программы
        /// </summary>
        string[] titles;

        #endregion

        /// <summary>
        /// Инициализация репозитория
        /// </summary>
        public Repository()
        {
            this.index = 0;
            this.pathToFile = @"F:\Visual Studio\Projects\AllConsoleProjects"+
                              @"\AllConsoleProjects\Projects\StructuresConsoleApp"+
                              @"\StructuresEmployeeDirectory\data\repository.txt";
            this.titles = new string[7];
            employeeArray = new Employee[2];
        }

        /// <summary>
        /// Проверка существования файла
        /// </summary>
        public void ExistingFile()
        {
            if (File.Exists(pathToFile) != true)
            {
                File.WriteAllText(pathToFile, "ID#Дата создания записи"+
                                              "#Ф.И.О.#Возраст#Рост"+
                                              "#Дата рождения#Место рождения\n");
            }
        }
        
        /// <summary>
        /// Проверка массива экземпляров сотрудников на переполненность
        /// </summary>
        /// <param name="flag">Условие переполнения массива</param>
        /// <returns></returns>
        public bool RepositoryResize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref employeeArray, employeeArray.Length * 2);
            }
            return flag;
        }

        /// <summary>
        /// Получение списка сотрудников из файла
        /// </summary>
        /// <returns>Массив экземпляров сотрудника</returns>
        public Employee[] GetAllEmployee()
        {            
            ExistingFile();
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                string[] lines = sr.ReadToEnd().Split('\n');
                string[] fields = new string[7];
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        titles = lines[i].Split('#');
                    }
                    else if (lines[i] != "")
                    {
                        fields = lines[i].Split('#');
                        Employee employee = new Employee(Convert.ToInt32(fields[0]),
                                                         Convert.ToDateTime(fields[1]),
                                                         fields[2],
                                                         Convert.ToByte(fields[3]),
                                                         Convert.ToByte(fields[4]),
                                                         Convert.ToDateTime(fields[5]),
                                                         fields[6]);
                        employeeArray[i - 1] = employee;
                        index++;
                        RepositoryResize(index >= employeeArray.Length);
                    }
                }
            }
            return employeeArray;
        }

        /// <summary>
        /// Запись в файл нового сотрудника
        /// </summary>
        public void AddNewEmployee()
        {
            RepositoryResize(index >= employeeArray.Length);
            using (StreamWriter sr = File.AppendText(pathToFile))
            {                
                string[] fields = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    while (true)
                    {
                        Console.Write($"Введите {titles[i + 2]}: ");
                        fields[i] = Console.ReadLine();
                        if (fields[i] == "")
                        {
                            Console.WriteLine("Вы ввели пустое значение, попробуйте еще раз.");
                        }
                        else break;
                    }
                }                
                Employee employee = new Employee(index + 1,
                                                 fields[0],
                                                 Convert.ToByte(fields[1]),
                                                 Convert.ToByte(fields[2]),
                                                 Convert.ToDateTime(fields[3]),
                                                 fields[4]);
                employeeArray[index] = employee;
                sr.WriteLine($"{employee.PrintToFile()}");
                index++;
            }
            RepositoryResize(index >= employeeArray.Length);
        }

        /// <summary>
        /// Вывод всех сотрудников в консоль
        /// </summary>
        public void DisplayAllEmployee()
        {
            Console.Write($"{titles[0],5}\t{titles[1],16}\t" +
                          $"{titles[2],35}{titles[3],5}{titles[4],5}" +
                          $"{titles[5],15}{titles[6],15}");
            Console.WriteLine();
            for (int i = 0; i < index; i++)
            {
                Employee employee = employeeArray[i];
                Console.WriteLine(employee.PrintToConsole());
            }
        }

        /// <summary>
        /// Поиск сотрудника по ID
        /// </summary>
        /// <param name="id">ID искомого сотрудника</param>
        public void FindEmployeeById(int id)
        {
            while (true)
            {
                if (id <= index && id > 0)
                {
                    Employee employee = employeeArray[id - 1];
                    Console.WriteLine(employee.PrintToConsole());
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно введён ID сотрудника." +
                                       "Попробуйте еще раз");
                    Console.Write("Введите ID для поиска: ");
                    id = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        /// <summary>
        /// Удаление сотрудника по ID
        /// </summary>
        /// <param name="id">ID удаляемого сотрудника</param>
        public void DeleteEmployeeById(int id)
        {
            Employee[] newEmployeeArray = new Employee[employeeArray.Length - 1];
            while (true)
            {
                if (id <= index && id > 0)
                {
                    Array.ConstrainedCopy(employeeArray, 0, newEmployeeArray, 0, id - 1);
                    string[] param = new string[7];
                    for(int i = id; i < newEmployeeArray.Length; i++)
                    {
                        param = employeeArray[i].PrintToFile().Split('#');
                        Employee newEmployee = new Employee(i, Convert.ToDateTime(param[1]),
                                                            param[2], Convert.ToByte(param[3]),
                                                            Convert.ToByte(param[4]),
                                                            Convert.ToDateTime(param[5]),
                                                            param[6]);
                        newEmployeeArray[i-1] = newEmployee;
                    }
                    index--;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно введён ID сотрудника." +
                                       "Попробуйте еще раз");
                    Console.Write("Введите ID для удаления: ");
                    id = Convert.ToInt32(Console.ReadLine());
                }
            }
            Array.Copy(newEmployeeArray, employeeArray, employeeArray.Length - 1);
            Array.Resize(ref employeeArray, index);
            SaveChanges();
        }

        /// <summary>
        /// Метод сохранения изменений в файл
        /// </summary>
        public void SaveChanges()
        {
            File.Delete(pathToFile);
            ExistingFile();
            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                Employee emp = new Employee();
                for (int i = 0; i < index; i++)
                {
                    emp = employeeArray[i];
                    sw.Write(emp.PrintToFile());
                }
            }
        }

        /// <summary>
        /// Метод поиска среди двух дат
        /// </summary>
        /// <param name="fDate">Начальная дата в поиске</param>
        /// <param name="sDate">Конечная дата в поиске</param>
        public void SearchBetweenTwoDates(DateTime fDate, DateTime sDate)
        {
            string[] line = new string[7];
            int ind = 0;
            Employee[] array = new Employee[index];
            for (int i = 0; i < index; i++)
            {
                Employee emp = employeeArray[i];
                line = emp.PrintToFile().Split('#');
                if (Convert.ToDateTime(line[1]) > fDate && Convert.ToDateTime(line[1]) < sDate)
                {
                    array[ind] = emp;
                    ind++;
                }                
                else if (Convert.ToDateTime(line[1]) > sDate)
                {
                    i = index;
                }
            }
            Console.Write($"{titles[0],5}\t{titles[1],16}\t" +
                          $"{titles[2],35}{titles[3],5}{titles[4],5}" +
                          $"{titles[5],15}{titles[6],15}");
            Console.WriteLine();
            for (int i = 0; i < ind; i++)
            {
                Employee employee = array[i];
                Console.WriteLine(employee.PrintToConsole());
            }
        }

    }
}
