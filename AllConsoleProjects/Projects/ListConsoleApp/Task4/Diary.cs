using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Task4
{
    class Diary
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;

        /// <summary>
        /// Коллекция Person
        /// </summary>
        private List<Person> personList;

        /// <summary>
        /// Экземпляр Diary
        /// </summary>
        public Diary()
        {
            personList = new List<Person>();
            path = @"data\diary.xml";
        }

        /// <summary>
        /// Метод проверки существования файла
        /// </summary>
        /// <returns>Логический ответ наличия файла</returns>
        public bool ExistingFile()
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Метод выгрузки данных из файла
        /// </summary>
        public void LoadFromFile()
        {
            personList.Clear();
            if (!ExistingFile())
            {
                File.Create(path);
                Console.WriteLine("Файл пустой.");
            }
            else
            {
                string text = File.ReadAllText(path);
                var xml = XDocument.Parse(text)
                                   .Descendants("Notes")
                                   .Descendants("Person")
                                   .ToList();
                foreach ( var person in xml )
                {
                    Person newPerson = new Person(person.Attribute("name").Value,
                                                  person.Element("Address").Element("Street").Value,
                                                  Convert.ToInt32(person.Element("Address").Element("HouseNumber").Value),
                                                  Convert.ToInt32(person.Element("Address").Element("FlatNumber").Value),
                                                  Convert.ToInt64(person.Element("Phones").Element("MobilePhone").Value),
                                                  Convert.ToInt64(person.Element("Phones").Element("FlatPhone").Value));
                    personList.Add(newPerson);
                }                
            }            
        }

        /// <summary>
        /// Метод вывода в консоль всех экземпляров в коллекции Diary
        /// </summary>
        public void PrintList()
        {
            foreach ( var person in personList )
            {
                Console.WriteLine($"{person.PrintToConsole()}\n");
            }
        }

        /// <summary>
        /// Метод добавления новой записи
        /// </summary>
        public void AddNewNote()
        {
            string[] titles = new string[6]
            {
                "ФИО","Улицу","Номер Дома","Номер Квартиры","Мобильный телефон","Домашний телефон"
            };
            string[] lines = new string[6];
            for ( int i = 0; i < titles.Length; i++ )
            {
                Console.WriteLine($"Введите {titles[i]}:");
                lines[i] = Console.ReadLine();
            }
            XDocument xml = XDocument.Load(path);            
            XElement personX = new XElement("Person", new XAttribute("name", $"{lines[0]}"));
            XElement address = new XElement("Address");
            XElement street = new XElement("Street", lines[1]);
            XElement houseNumber = new XElement("HouseNumber", lines[2]);
            XElement flatNumber = new XElement("FlatNumber", lines[3]);
            XElement phones = new XElement("Phones");
            XElement mobilePhone = new XElement("MobilePhone", lines[4]);
            XElement flatPhone = new XElement("FlatPhone", lines[5]);
            address.Add(street, houseNumber, flatNumber);
            phones.Add(mobilePhone, flatPhone);
            personX.Add(address,phones);
            xml.Root.Add(personX);
            xml.Save(path);
        }

    }
}
