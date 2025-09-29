using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppTask2
{
    internal class Manager : Client, IClient
    {

        public override string FirstName { get => base.FirstName; set => base.FirstName = value; }

        public override string LastName { get => base.LastName; set => base.LastName = value; }

        public override string SurName { get => base.SurName; set => base.SurName = value; }

        public override ulong Phone { get => base.Phone; set => base.Phone = value; }

        public override string Passport { get => base.Passport; set => base.Passport = value; }

        public Manager (string FirstName, string LastName, string SurName, ulong Phone, string Passport)
            :base(FirstName, LastName, SurName, Phone, Passport)
        {
        }

        // IClient

        public string PrintClient(Client data)
        {
            return $"{data.FirstName} {data.LastName} {data.SurName} " +
                   $"{data.Phone} {data.Passport}";
        }

        public Client ChangeClientData(Client data, string newData)
        {
            List<string> lt = new List<string>();
            for (int i = 0; i < newData.Split(' ').Length - 1 ; i++)
            {
                lt.Add(newData.Split(' ')[i]);
            }
            for ( int i = 0; i < lt.Count; i++)
            {
                if (i == 0) (data).FirstName = lt[0];
                if (i == 1) (data).LastName = lt[1];
                if (i == 2) (data).SurName = lt[2];
                if (i == 3) (data).Phone = Convert.ToUInt64(lt[3]);
                if (i == 4)
                {
                    (data).Passport = $"{lt[4]} {lt[5]}";
                    i = lt.Count;
                }
            }
            return data;
        }

    }
}
