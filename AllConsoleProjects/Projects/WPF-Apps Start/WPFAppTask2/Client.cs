using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppTask2
{
    abstract class Client
    {
        #region Поля
        /// <summary>
        /// Имя
        /// </summary>
        protected string firstName;
        /// <summary>
        /// Фамилия
        /// </summary>
        protected string lastName;
        /// <summary>
        /// Отчество
        /// </summary>
        protected string surName;
        /// <summary>
        /// Номер мобильного телефона
        /// </summary>
        protected ulong phone;
        /// <summary>
        /// Данные паспорта
        /// </summary>
        protected string passport;
        #endregion

        #region Свойства
        /// <summary>
        /// Имя (свойство)
        /// </summary>
        public virtual string FirstName { get => this.firstName; set => this.firstName = value; }
        /// <summary>
        /// Фамилия (свойство)
        /// </summary>
        public virtual string LastName { get => this.lastName; set => this.lastName = value; }
        /// <summary>
        /// Отчество (свойство)
        /// </summary>
        public virtual string SurName { get => this.surName; set => this.surName = value; }
        /// <summary>
        /// Номер мобильного телефона (свойство)
        /// </summary>
        public virtual ulong Phone { get => this.phone; set => this.phone = value; }
        /// <summary>
        /// Данные паспорта (свойство)
        /// </summary>
        public virtual string Passport { get => this.passport; set => this.passport = value; }
        #endregion

        public Client(string FirstName, string LastName, string SurName, ulong Phone, string Passport)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.surName = SurName;
            this.phone = Phone;
            this.passport = Passport;
        }
    }

    interface IClient
    {
        /// <summary>
        /// Метод вывода данных о клиенте на экран
        /// </summary>
        /// <returns>Строка данных о клиенте</returns>
        public string PrintClient(Client data);

        /// <summary>
        /// Метод изменения данных клиента
        /// </summary>
        /// <returns>Измененный экземпляр клиента</returns>
        public Client ChangeClientData(Client data, string newData);

    }

}
