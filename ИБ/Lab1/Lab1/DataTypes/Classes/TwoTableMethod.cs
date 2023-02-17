namespace Lab1.DataTypes.Classes
{
    public class TwoTableMethod : IEncryption
    {
        char[,] square1 = new char[,]
        {
            {'й','ц','у','к','е','н' },
            {'г','ш','щ','з','х','ъ' },
            {'ф','ы','в','а','п','р' },
            {'о','л','д','ж','э','я' },
            {'ч','с','м','и','т','ь' },
            {'б','ю','ё',' ','.',',' },
        };

        char[,] square2 = new char[,]
        {
            {'я','ф','й','ц','ы','ч' },
            {'м','а','к','у','в','с' },
            {'и','п','е','н','р','т' },
            {'б','л','ш','г','о','ь' },
            {'ю','.','д','щ','з','ж' },
            {'э','ъ',' ',',','ё','х' },
        };

        public string Name => "Метод двух таблиц";

        public string Decrypt(string text)
        {
            string encryptedText = string.Empty;
            for (int i = 0; i < text.Length - 1; i += 2)
            {
                Cell(text[i], out int row1, out int column1, square1);
                Cell(text[i + 1], out int row2, out int column2, square2);
                encryptedText += square2[row1, column2];
                encryptedText += square1[row2, column1];
            }
            return encryptedText;
        }

        public string Encrypt(string text)
        {
            string encryptedText = string.Empty;
            for (int i = 0; i < text.Length - 1; i += 2)
            {
                Cell(text[i], out int row1, out int column1, square2);
                Cell(text[i + 1], out int row2, out int column2, square1);
                encryptedText += square1[row1, column2];
                encryptedText += square2[row2, column1];
            }
            return encryptedText;
        }

        void Cell(char c, out int row, out int column, char[,] square)
        {
            row = -1;
            column = -1;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int f = 0; f < square.GetLength(1); f++)
                {
                    if (c == square[i, f])
                    {
                        row = i;
                        column = f;
                        return;
                    }
                }
            }
        }
    }
}
