namespace Chat
{
    public class PlayfairCipher
    {
        static char[,] GenerateKeyTable(string key)
        {
            char[,] keyTable = new char[5, 5];
            int[] dicty = new int[26];
            int k = 0;

            key = key.ToLower().Replace(" ", "");

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] != 'j')
                    dicty[key[i] - 'a'] = 2;
            }

            dicty['j' - 'a'] = 1;

            int row = 0, col = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (dicty[key[i] - 'a'] == 2)
                {
                    dicty[key[i] - 'a'] -= 1;
                    keyTable[row, col] = key[i];
                    col = (col + 1) % 5;
                    if (col == 0)
                        row++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (dicty[i] == 0)
                {
                    keyTable[row, col] = (char)(i + 'a');
                    col = (col + 1) % 5;
                    if (col == 0)
                        row++;
                }
            }

            return keyTable;
        }

        static void Search(char[,] keyTable, char a, char b, int[] arr)
        {
            int i, j;

            if (a == 'j')
                a = 'i';
            else if (b == 'j')
                b = 'i';

            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    if (keyTable[i, j] == a)
                    {
                        arr[0] = i;
                        arr[1] = j;
                    }
                    else if (keyTable[i, j] == b)
                    {
                        arr[2] = i;
                        arr[3] = j;
                    }
                }
            }
        }

        static int Mod5(int a)
        {
            return (a % 5);
        }

        static int Prepare(char[] str, int ptrs)
        {
            if (ptrs % 2 != 0)
            {
                str[ptrs++] = 'z';
                str[ptrs] = '\0';
            }
            return ptrs;
        }

        static void Encrypt(char[] str, char[,] keyTable, int ps)
        {
            int[] a = new int[4];

            for (int i = 0; i < ps; i += 2)
            {
                Search(keyTable, str[i], str[i + 1], a);

                if (a[0] == a[2])
                {
                    str[i] = keyTable[a[0], Mod5(a[1] + 1)];
                    str[i + 1] = keyTable[a[0], Mod5(a[3] + 1)];
                }
                else if (a[1] == a[3])
                {
                    str[i] = keyTable[Mod5(a[0] + 1), a[1]];
                    str[i + 1] = keyTable[Mod5(a[2] + 1), a[1]];
                }
                else
                {
                    str[i] = keyTable[a[0], a[3]];
                    str[i + 1] = keyTable[a[2], a[1]];
                }
            }
        }

        static void Decrypt(char[] str, char[,] keyTable, int ps)
        {
            int[] a = new int[4];

            for (int i = 0; i < ps; i += 2)
            {
                Search(keyTable, str[i], str[i + 1], a);

                if (a[0] == a[2])
                {
                    str[i] = keyTable[a[0], Mod5(a[1] - 1)];
                    str[i + 1] = keyTable[a[0], Mod5(a[3] - 1)];
                }
                else if (a[1] == a[3])
                {
                    str[i] = keyTable[Mod5(a[0] - 1), a[1]];
                    str[i + 1] = keyTable[Mod5(a[2] - 1), a[1]];
                }
                else
                {
                    str[i] = keyTable[a[0], a[3]];
                    str[i + 1] = keyTable[a[2], a[1]];
                }
            }
        }

        public static void EncryptByPlayfairCipher(char[] str, string key)
        {
            char[,] keyTable = GenerateKeyTable(key);

            // Plaintext
            int ps = Prepare(str, str.Length);
            Encrypt(str, keyTable, ps);
        }

        public static void DecryptByPlayfairCipher(char[] str, string key)
        {
            char[,] keyTable = GenerateKeyTable(key);

            // Plaintext
            int ps = Prepare(str, str.Length);
            Decrypt(str, keyTable, ps);
        }
    }
}
