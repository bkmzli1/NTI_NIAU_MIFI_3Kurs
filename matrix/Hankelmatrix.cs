using System;

namespace matrix
{
    public class Hankelmatrix
    {
        public static void Main3()
        {
            //  Создаем Ганкелеву матрицу
            int n = 5;
            int[,] matrix = GetHankelMatrix(n);

            //  Печать матрицы
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            } 
        }

        public static int[,] GetHankelMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i + j + 1;
                }
            }
        
            return matrix;
        }
    }
}