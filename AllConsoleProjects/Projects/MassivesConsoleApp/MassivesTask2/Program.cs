using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MassivesTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int str, stl;
            int sum = 0;
            Write("Введите количество строк матриц : ");
            str = Convert.ToInt32(Console.ReadLine());
            Write("\nВведите количество столбцов матриц : ");
            stl = Convert.ToInt32(Console.ReadLine());
            int[,] matrixFirst = new int[str, stl];
            int[,] matrixSecond = new int[str, stl];
            int[,] matrixSummary = new int[str, stl];
            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFirst.GetLength(1); j++)
                {
                    matrixFirst[i, j] = r.Next(1,10);
                    Write($"{matrixFirst[i, j]} ");
                }
                Write("\t");
                for (int k = 0; k < matrixFirst.GetLength(1); k++)
                {
                    matrixSecond[i, k] = r.Next(1,10);
                    Write($"{matrixSecond[i,k]} ");
                }
                WriteLine();
            }
            WriteLine("Их сумма :");
            for (int j = 0; j < matrixFirst.GetLength(0); j++)
            {
                for (int k = 0; k < matrixFirst.GetLength(1); k++)
                {
                    sum = matrixFirst[j,k] + matrixSecond[j,k];
                    matrixSummary[j, k] = sum;
                    Write($"{matrixSummary[j,k]} ");
                }
                WriteLine();
            }    
            ReadKey();
        }
    }
}
