
using System;

namespace ToeplitzMatrix
{
    class Program
    {
        public static bool IsToeplitzMatrix(int[][] matrix) 
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i > 0 && j > 0 && matrix[i - 1][j - 1] != matrix[i][j])
                        return false;
                }
            }

            return true;
        }
	
        public static void Main()
        {
            
            // tests
            var matrix = new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 1, 2, 3 },
                new int[] { 9, 5, 1, 2 }
            };
            Console.WriteLine(IsToeplitzMatrix(matrix).ToString()); // true
        }
    }
}