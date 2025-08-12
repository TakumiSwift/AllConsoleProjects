using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsTask1
{
    internal class Program
    {
        static string[] SplitTextMethod(string word)
        {
            string[] text = new string[(word.Split(' ')).Length];
            Array.Copy(word.Split(' '), text, word.Split(' ').Length);
            return text;
        }
        static void TextOutput(string[] text)
        {
            foreach (string line in text)
            {
                Console.WriteLine(line);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Использование метода разделения строки в массив слов."+
                              "\nВведите предложение, разделяя слова пробелом: ");
            TextOutput(SplitTextMethod(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
