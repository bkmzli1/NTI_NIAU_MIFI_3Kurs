public class RC4My
{
    private byte[] S = new byte[256];
    private byte[] T = new byte[256];
    private int keyLength;

    public RC4My(byte[] key)
    {
        this.keyLength = key.Length;
        for (int i = 0; i < 256; i++)
        {
            this.S[i] = (byte)i;
            this.T[i] = key[i % keyLength];
        }

        int j = 0;
        for (int i = 0; i < 256; i++)
        {
            j = (j + S[i] + T[i]) % 256;
            Swap(i, j);
        }
    }

    public byte[] Encode(byte[] data)
    {
        byte[] output = new byte[data.Length];

        int i = 0, j = 0;
        for (int k = 0; k < data.Length; k++)
        {
            i = (i + 1) % 256;
            j = (j + S[i]) % 256;
            Swap(i, j);
            byte a = data[k];
            byte b = S[(S[i] + S[j]) % 256];
            output[k] = (byte)((int)a ^ (int)b);
        }

        return output;
    }

    private void Swap(int i, int j)
    {
        byte temp = S[i];
        S[i] = S[j];
        S[j] = temp;
    }
}