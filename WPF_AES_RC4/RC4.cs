namespace WPF_AES_RC4
{
    public class RC4
    {
        public static byte[] Encrypt(byte[] pwd, byte[] data)
        {
            int a, i, j, k;
            byte[] key, box, cipher;
            key = new byte[256];
            box = new byte[256];
            cipher = new byte[data.Length];
            for (i = 0; i < 256; i++)
            {
                key[i] = pwd[i % pwd.Length];
                box[i] = (byte)i;
            }

            for (i = j = 0; i < 256; i++)
            {
                j = (j + box[i] + key[i]) % 256;
                byte temp = box[i];
                box[i] = box[j];
                box[j] = temp;
            }

            for (a = i = j = 0; i < data.Length; i++)
            {
                a++;
                a %= 256;
                j += box[a];
                j %= 256;
                byte temp = box[a];
                box[a] = box[j];
                box[j] = temp;
                k = box[((box[a] + box[j]) % 256)];
                cipher[i] = (byte)(data[i] ^ k);
            }

            return cipher;
        }

        public static byte[] Decrypt(byte[] pwd, byte[] data)
        {
            return Encrypt(pwd, data);
        }
    }
}