using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsTask2
{
    internal class Program
    {
        /// <summary>
        /// Метод разделения строки на массив слов
        /// </summary>
        /// <param name="word">Вводимая строка</param>
        /// <returns></returns>
        static string[] SplitTextMethod(string word)
        {
            string[] text = new string[(word.Split(' ')).Length];
            Array.Copy(word.Split(' '), text, word.Split(' ').Length);
            return text;
        }
        /// <summary>
        /// Метод инверсии массива слов
        /// </summary>
        /// <param name="text">Первоначальный массив слов</param>
        /// <returns></returns>
        static string[] InverseTextMethod(string[] text)
        {
            string[] reversedText = new string[text.Length];
            for (int i = text.Length-1; i >= 0; i--)
            {
                reversedText[i] = text[i];
            }
            return reversedText;
        }
        /// <summary>
        /// Метод для проверки работы метода инверсии массива слов
        /// </summary>
        /// <param name="text">Инверсированный массив слов</param>
        static void TextOutput(string[] text)
        {
            foreach (string line in text)
            {
                Console.WriteLine(line);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Использование метода разделения строки в массив слов и его перестановки." +
                          "\nВведите предложение, разделяя слова пробелом: ");
            string[] text = InverseTextMethod(SplitTextMethod(Console.ReadLine()));
            TextOutput(text);
            Console.ReadKey();
        }
    }
}
