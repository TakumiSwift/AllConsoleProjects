using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MassivesTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int str, stl;
            int sum = 0;
            Write("Введите количество строк матрицы : ");
            str = Convert.ToInt32(Console.ReadLine());
            Write("\nВведите количество столбцов матрицы : ");
            stl = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[str, stl];
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(10);
                    Write($"{matrix[i,j]} ");
                    sum += matrix[i, j];
                }
                WriteLine();
            }
            WriteLine("Сумма элементов матрицы : {0}", sum);
            ReadKey();
        }
    }
}
