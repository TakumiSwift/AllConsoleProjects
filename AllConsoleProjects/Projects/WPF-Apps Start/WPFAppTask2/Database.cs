using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace WPFAppTask2
{
    class Database
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;

        /// <summary>
        /// Коллекция Client'ов
        /// </summary>
        private ObservableCollection<Client> cData;

        /// <summary>
        /// Коллекция ID Client'ов
        /// </summary>
        private List<string> clientID = new List<string>();

        private string callingWindow;

        public Database(string window)
        {
            path = @"data\database.xml";
            cData = new ObservableCollection<Client>();
            callingWindow = window;
            ExistingFile();
            LoadData(cData);
        }
        
        /// <summary>
        /// Метод проверки существования файла
        /// </summary>
        /// <returns>Логический ответ наличия файла</returns>
        private bool ExistingFile()
        {
            bool flag = File.Exists(path);
            if (flag) {}
            else
            {
                File.Create(path).Close();
                CreateStructureOfXML(true);
            }
            return flag;
        }

        /// <summary>
        /// Метод создания структуры XML-файла
        /// </summary>
        /// <param name="flag">Логический признак создания структуры
        ///                    с базовыми параметрами или нет</param>
        /// <returns>Dictionary с созданной структурой XML-файла</returns>
        private Dictionary<string,XElement> CreateStructureOfXML(bool flag)
        {

            #region Создание XElement'ов
            Dictionary<string,XElement> newDictionary = new Dictionary<string,XElement>();
            newDictionary.Add("clients", new XElement("Clients"));
            newDictionary.Add("client", new XElement("Client", new XAttribute("id", "")));
            newDictionary.Add("fullName", new XElement("FullName"));
            newDictionary.Add("firstName", new XElement("FirstName"));
            newDictionary.Add("lastName", new XElement("LastName"));
            newDictionary.Add("surName", new XElement("SurName"));
            newDictionary.Add("documents", new XElement("Documents"));
            newDictionary.Add("passport", new XElement("Passport"));
            newDictionary.Add("phones", new XElement("Phones"));
            newDictionary.Add("mobilePhone", new XElement("MobilePhone"));            
            #endregion

            newDictionary["fullName"].Add(newDictionary["firstName"],
                                          newDictionary["lastName"],
                                          newDictionary["surName"]);
            newDictionary["documents"].Add(newDictionary["passport"]);
            newDictionary["phones"].Add(newDictionary["mobilePhone"]);
            newDictionary["client"].Add(newDictionary["fullName"],
                                        newDictionary["documents"],
                                        newDictionary["phones"]);
            newDictionary["clients"].Add(newDictionary["client"]);

            if (flag)
            {
                newDictionary["firstName"].Value = "Имя";
                newDictionary["lastName"].Value = "Фамилия";
                newDictionary["surName"].Value = "Отчество";
                newDictionary["passport"].Value = "Паспорт";
                newDictionary["mobilePhone"].Value = "0";
                newDictionary["client"].Attribute("id").Value = "0";
                newDictionary["clients"].Save(path);
            }

            return newDictionary;
        }

        /// <summary>
        /// Метод выгрузки данных из файла
        /// </summary>
        /// <param name="data">Коллекция, куда будут загружаться экземпляры</param>
        /// <returns>Загруженная из файла коллекция</returns>
        private ObservableCollection<Client> LoadData(ObservableCollection<Client> data)
        {
            string text = File.ReadAllText(path);
            var xml = XDocument.Parse(text)
                               .Descendants("Clients")
                               .Descendants("Client")
                               .ToList();
            if (callingWindow == "Consultant")
            {
                foreach (var item in xml)
                {
                    clientID.Add(item.Attribute("id").Value);
                    Client client = new Consultant(item.Element("FullName").Element("FirstName").Value,
                                                   item.Element("FullName").Element("LastName").Value,
                                                   item.Element("FullName").Element("SurName").Value,
                                                   Convert.ToUInt64(item.Element("Phones").Element("MobilePhone").Value),
                                                   item.Element("Documents").Element("Passport").Value);
                    data.Add(client);
                }
                return data;
            }
            else
            {
                foreach (var item in xml)
                {
                    clientID.Add(item.Attribute("id").Value);
                    Client client = new Manager(item.Element("FullName").Element("FirstName").Value,
                                                   item.Element("FullName").Element("LastName").Value,
                                                   item.Element("FullName").Element("SurName").Value,
                                                   Convert.ToUInt64(item.Element("Phones").Element("MobilePhone").Value),
                                                   item.Element("Documents").Element("Passport").Value);
                    data.Add(client);
                }
                return data;
            }
        }

        /// <summary>
        /// Метод получения коллекции экземпляров из Database
        /// </summary>
        /// <returns>Коллекция экземпляров</returns>
        public ObservableCollection<Client> TakeData()
        {
            ObservableCollection<Client> newData = new ObservableCollection<Client>();
            foreach (var item in cData)
            {
                newData.Add(item);
            }
            return newData;
        }

        /// <summary>
        /// Метод сохранения изменений в файл
        /// </summary>
        /// <param name="data">Измененная коллекция экземпляров</param>
        /// <returns>Измененная коллекция экземпляров</returns>
        public ObservableCollection<Client> SaveData(ObservableCollection<Client> data)
        {
            cData.Clear();
            cData = data;
            File.Delete(path);
            File.Create(path).Close();

            Dictionary<string,XElement> nD = CreateStructureOfXML(false);

            nD["firstName"].Value = cData[0].FirstName;
            nD["lastName"].Value = cData[0].LastName;
            nD["surName"].Value = cData[0].SurName;
            if (cData[0].GetType() == typeof(Consultant))
            {
                nD["passport"].Value = (cData[0] as Consultant).GetPassportData(cData[0]);
            }
            else
            {
                nD["passport"].Value = (cData[0] as Manager).Passport;
            }
            nD["mobilePhone"].Value = Convert.ToString(cData[0].Phone);
            nD["client"].Attribute("id").Value = Convert.ToString(clientID[0]);

            nD["clients"].Save(path);

            XDocument xml = XDocument.Load(path);

            for (int i = 1; i < cData.Count; i++)
            {
                nD["firstName"].Value = cData[i].FirstName;
                nD["lastName"].Value = cData[i].LastName;
                nD["surName"].Value = cData[i].SurName;
                if (cData[i].GetType() == typeof(Consultant))
                {
                    nD["passport"].Value = (cData[i] as Consultant).GetPassportData(cData[i]);
                }
                else
                {
                    nD["passport"].Value = (cData[i] as Manager).Passport;
                }
                nD["mobilePhone"].Value = Convert.ToString(cData[i].Phone);
                nD["client"].Attribute("id").Value = Convert.ToString(clientID[i]);
                xml.Root.Add(nD["client"]);
            }
            xml.Save(path);
            return data;
        }

    }
}
