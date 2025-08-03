using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Zadanie 1
            string fullName = "Иванов Иван Иванович";
            byte age = 25;
            string email = "ivanov@gmail.dot";
            float progScore = 50.2f;
            float mathScore = 60.2f;
            float physScore = 55.2f;
            string pattern = "Ф.И.О. :{0}\n" +
                             "Возраст :{1}\n" +
                             "Email :{2}\n" +
                             "Баллы по программированию :{3}\n" +
                             "Баллы по математике :{4}\n" +
                             "Баллы по физике :{5}";
            Console.WriteLine(pattern,
                              fullName,
                              age,
                              email,
                              progScore,
                              mathScore,
                              physScore);
            Console.ReadKey();
            #endregion
            #region Zadanie 2
            float result = (progScore+mathScore+physScore)/3;
            Console.WriteLine($"\n{result}");
            Console.ReadKey();
            #endregion
        }
    }
}
