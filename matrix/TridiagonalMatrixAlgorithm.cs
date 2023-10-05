using System;

namespace matrix
{
    public class TridiagonalMatrixAlgorithm
    {
        private double[] a, b, c, d, x;
        private int n;

        public TridiagonalMatrixAlgorithm(double[] a, double[] b, double[] c, double[] d)
        {
            if (a == null || b == null || c == null || d == null)
                throw new ArgumentNullException();
            if (a.Length != b.Length || a.Length != c.Length || a.Length != d.Length)
                throw new ArgumentException();
            this.a = (double[])a.Clone();
            this.b = (double[])b.Clone();
            this.c = (double[])c.Clone();
            this.d = (double[])d.Clone();
            n = a.Length;
            x = new double[n];
        }

        public double[] Solve()
        {
            double m;

            for (int i = 1; i < n; i++)
            {
                m = a[i] / b[i - 1];
                b[i] = b[i] - m * c[i - 1];
                d[i] = d[i] - m * d[i - 1];
            }

            x[n - 1] = d[n - 1] / b[n - 1];

            for (int i = n - 2; i >= 0; --i)
                x[i] = (d[i] - c[i] * x[i + 1]) / b[i];

            return x;
        }
        public static void Main1()
        {
            double[] a = new double[] { 0, -1, -1 };
            double[] b = new double[] { -2, -2, -2 };
            double[] c = new double[] { -1, -1, 0 };
            double[] d = new double[] { -1, -2, -3 };

            TridiagonalMatrixAlgorithm tm = new TridiagonalMatrixAlgorithm(a, b, c, d);
            double[] res = tm.Solve();
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
    }


}