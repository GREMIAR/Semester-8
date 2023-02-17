using System.Text;

namespace Lab1;

class PolybeanSquare : IEncryption
{
    char[,] square = new char[,]
    {
        {'й','ц','у','к','е','н' },
        {'г','ш','щ','з','х','ъ' },
        {'ф','ы','в','а','п','р' },
        {'о','л','д','ж','э','я' },
        {'ч','с','м','и','т','ь' },
        {'б','ю','ё',' ','.',',' },
    };

    int FixIndexEn(int i)
    {
        if (i == 5)
        {
            return -1;
        }
        return i;
    }

    int FixIndexDe(int i)
    {
        if (i == 0)
        {
            return 6;
        }
        return i;
    }

    char EncryptChar(char character)
    {
        for (int j = 0; j < square.GetLength(0); j++)
        {
            for (int f = 0; f < square.GetLength(1); f++)
            {
                if (character == square[j, f])
                {
                    int fixIndex = FixIndexEn(j);
                    character = square[fixIndex + 1, f];
                    return character;
                }
            }
        }
        return character;
    }

    public string Encrypt(string text)
    {
        StringBuilder str = new(text);

        for (int i = 0; i < str.Length; i++)
        {
            str[i] = EncryptChar(str[i]);
        }
        return str.ToString();
    }

    char DecryptChar(char character)
    {
        for (int j = 0; j < square.GetLength(0); j++)
        {
            for (int f = 0; f < square.GetLength(1); f++)
            {
                if (character == square[j, f])
                {
                    int fixIndex = FixIndexDe(j);
                    character = square[fixIndex - 1, f];
                    return character;
                }
            }
        }
        return character;
    }

    public string Decrypt(string text)
    {
        StringBuilder str = new(text);
        for (int i = 0; i < str.Length; i++)
        {
            str[i] = DecryptChar(str[i]);
        }
        return str.ToString();
    }
}
