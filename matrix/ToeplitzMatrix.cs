using System;

namespace matrix
{
    public class ToeplitzMatrix
    {
        public static void Main2()
        {
            // Создаем и выводим теплицеву матрицу
            int size = 5;
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            int[,] matrix = CreateToeplitzMatrix(size, array);
            PrintMatrix(matrix, size);

            // Решаем систему линейных уравнений методом Гаусса
            double[,] coefficients = { { 1, -2, 2 }, { 3, -4, 1 }, { 1, -1, 1 } }; // коэффициенты линейных уравнений
            double[] vector = { 3, 2, 1 }; // вектор результатов
            double[] result = SolveSystemGaussian(coefficients, vector);
            foreach (double res in result)
                Console.WriteLine(res);
        }

        static int[,] CreateToeplitzMatrix(int size, int[] array)
        {
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = array[Math.Abs(i - j)];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static double[] SolveSystemGaussian(double[,] coefficients, double[] vector)
        {
            int length = vector.Length;

            for (int i = 0; i < length; i++)
            {
                double coef = coefficients[i, i];
                for (int j = 0; j < length; j++)
                {
                    coefficients[i, j] = coefficients[i, j] / coef;
                }

                vector[i] = vector[i] / coef;

                for (int j = 0; j < length; j++)
                {
                    if (i != j)
                    {
                        coef = coefficients[j, i];
                        for (int k = 0; k < length; k++)
                            coefficients[j, k] = coefficients[j, k] - coef * coefficients[i, k];

                        vector[j] = vector[j] - coef * vector[i];
                    }
                }
            }

            return vector;
        }
    }
}