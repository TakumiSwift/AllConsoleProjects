using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppTask2
{

    internal class Consultant : Client, IClient
    {

        public override string FirstName { get => base.FirstName; set => base.FirstName = base.firstName; }

        public override string LastName { get => base.LastName; set => base.LastName = base.lastName; }

        public override string SurName { get => base.SurName; set => base.SurName = base.surName; }

        public override ulong Phone { get => base.Phone; set => base.Phone = value; }

        public override string Passport { get => "**** ******"; set => base.Passport = base.passport; }

        public Consultant(string FirstName, string LastName, string SurName, ulong Phone, string Passport)
        :base (FirstName, LastName, SurName, Phone, Passport)
        {
        }

        // IClient
        public string PrintClient(Client data)
        {
            return $"{data.FirstName} {data.LastName} {data.SurName} " +
                   $"{data.Phone} {(data as Consultant).Passport}";
        }

        public Client ChangeClientData(Client data, string newData)
        {
            data.Phone = Convert.ToUInt64(newData);
            return data;
        }

        /// <summary>
        /// Метод получения паспортных данных
        /// </summary>
        /// <param name="data">Экземпляр клиента</param>
        /// <returns>Строка с паспортными данными</returns>
        public string GetPassportData(Client data)
        {
            string line = (data as Consultant).passport;
            return line;
        }

    }


}
