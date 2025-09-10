using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task4
{
    struct Person
    {
        #region Поля

        /// <summary>
        /// ФИО
        /// </summary>
        private string fullName;

        /// <summary>
        /// Улица
        /// </summary>
        private string street;

        /// <summary>
        /// Номер дома
        /// </summary>
        private int houseNumber;

        /// <summary>
        /// Номер квартиры
        /// </summary>
        private int flatNumber;

        /// <summary>
        /// Номер мобильного телефона
        /// </summary>
        private long phoneNumber;

        /// <summary>
        /// Номер домашнего телефона
        /// </summary>
        private long flatPhoneNumber;

        #endregion

        /// <summary>
        /// Конструктор Person
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <param name="street">Улица</param>
        /// <param name="houseNumber">Дом</param>
        /// <param name="flatNumber">Квартира</param>
        /// <param name="phoneNumber">Мобильный телефон</param>
        /// <param name="flatPhoneNumber">Домашний телефон</param>
        public Person (string fullName, string street, int houseNumber, int flatNumber, long phoneNumber, long flatPhoneNumber)
        {
            this.fullName = fullName;
            this.street = street;
            this.houseNumber = houseNumber;
            this.flatNumber = flatNumber;
            this.phoneNumber = phoneNumber;
            this.flatPhoneNumber = flatPhoneNumber;
        }

        /// <summary>
        /// Метод печати в консоль
        /// </summary>
        /// <returns>Person в строковом формате</returns>
        public string PrintToConsole()
        {
            return $"ФИО {this.fullName}\n{this.street} ул.\t{this.houseNumber} д.\t{this.flatNumber} кв.\n"+
                   $"Моб.тел. {this.phoneNumber}\tДом. тел.{this.flatPhoneNumber}";
        }

    }
}
