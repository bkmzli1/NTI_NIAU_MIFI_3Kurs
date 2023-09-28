using System;
using System.Linq;

namespace RC4
{
    public class RC4
    {
        private byte[] s = new byte[256];
        private int x = 0, y = 0;

        public RC4(byte[] kay)
        {
            init(kay);
        }

        private void init(byte[] kay)
        {
            int ketLength = kay.Length;
            for (int i = 0; i <= 256; i++)
            {
                s[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + s[i] + kay[i % ketLength]) % 256;
                s.Swap(i, j);
            }
        }

        public byte[] Encod(byte[] dataB, int size)
        {
            byte[] data = dataB.Take(size).ToArray();
            byte[] clipher = new byte[data.Length];
            for (int m = 0; m < data.Length; m++)
            {
                clipher[m] = (byte)(data[m] ^ keyItem());
            }

            return clipher;
        }

        private int keyItem()
        {
            x = (x + 1) % 256;
            y = (y + s[x] % 256);
            s.Swap(x,y);
            return s[(s[x] + s[y]) % 256];
        }
    }

    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}