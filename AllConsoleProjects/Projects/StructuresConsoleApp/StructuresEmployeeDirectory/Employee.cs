using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresEmployeeDirectory
{
    struct Employee
    {
        #region Поля
        
        /// <summary>
        /// ID сотрудника
        /// </summary>
        int id;

        /// <summary>
        /// Дата создания записи
        /// </summary>
        DateTime dateOfCreation;

        /// <summary>
        /// Ф.И.О. сотрудника
        /// </summary>
        string fullName;

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        byte age;

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        byte height;

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        DateTime dateOfBirth;

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        string placeOfBirth;

        #endregion

        #region Конструкторы Employee

        /// <summary>
        /// Экземпляр сотрудника (Полный)
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="dateOfCreation">Дата создания записи</param>
        /// <param name="fullName">Ф.И.О. сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="height">Рост сотрудника</param>
        /// <param name="dateOfBirth">Дата рождения сотрудника</param>
        /// <param name="placeOfBirth">Место рождения сотрудника</param>
        public Employee (int id, DateTime dateOfCreation, string fullName, byte age, byte height, DateTime dateOfBirth, string placeOfBirth)
        {
            this.id = id;
            this.dateOfCreation = dateOfCreation;
            this.fullName = fullName;
            this.age = age;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
        }

        /// <summary>
        /// Экземпляр сотрудника (6 Параметров)
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="fullName">Ф.И.О. сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="height">Рост сотрудника</param>
        /// <param name="dateOfBirth">Дата рождения сотрудника</param>
        /// <param name="placeOfBirth">Место рождения сотрудника</param>
        public Employee(int id, string fullName, byte age, byte height, DateTime dateOfBirth, string placeOfBirth):
            this (id, DateTime.Now, fullName, age, height, dateOfBirth, placeOfBirth) { }
        
        /// <summary>
        /// Экземпляр сотрудника (5 Параметров)
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="fullName">Ф.И.О. сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="height">Рост сотрудника</param>
        /// <param name="dateOfBirth">Дата рождения сотрудника</param>
        public Employee (int id, string fullName, byte age, byte height, DateTime dateOfBirth):
            this (id, DateTime.Now, fullName, age, height, dateOfBirth, "Не указано") { }

        /// <summary>
        /// Экземпляр сотрудника (4 Параметра)
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="fullName">Ф.И.О. сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="dateOfBirth">Дата рождения сотрудника</param>
        public Employee(int id, string fullName, byte age, DateTime dateOfBirth) :
            this(id, DateTime.Now, fullName, age, 0, dateOfBirth, "Не указано") { }

        /// <summary>
        /// Экземпляр сотрудника (3 Параметра)
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="fullName">Ф.И.О. сотрудника</param>
        /// <param name="dateOfBirth">Дата рождения сотрудника</param>
        public Employee(int id, string fullName, DateTime dateOfBirth) :
            this(id, DateTime.Now, fullName, 0, 0, dateOfBirth, "Не указано") { }

        #endregion

        #region Методы
        
        /// <summary>
        /// Метод вывода данных о сотруднике в файл
        /// </summary>
        /// <returns>Данные сотрудника в строковом формате</returns>
        public string PrintToFile()
        {
            return $"{this.id}#{this.dateOfCreation.ToString("g")}"+
                   $"#{this.fullName}#{this.age}#{this.height}"+
                   $"#{this.dateOfBirth.ToString("d")}#{this.placeOfBirth}";
        }

        /// <summary>
        /// Метод вывода данных о сотруднике в консоль
        /// </summary>
        /// <returns>Данные сотрудника в строковом формате</returns>
        public string PrintToConsole()
        {
            return $"{this.id,5}\t{this.dateOfCreation.ToString("g"),16}\t" +
                   $"{this.fullName,35}{this.age,5}{this.height,5}" +
                   $"{this.dateOfBirth.ToString("d"),15}{this.placeOfBirth,15}";
        }

        #endregion
    }
}
