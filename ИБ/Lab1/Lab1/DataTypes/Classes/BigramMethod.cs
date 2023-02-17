using System.Linq;
using System.Text;

namespace Lab1;

class BigramMethod : IEncryption
{
    public string Name => "Метод биграмм";

    public string key;

    public char[,] table;

    public BigramMethod(string key)
    {
        this.key = key;
        this.table = Table(key);
    }

    string EncryptBigram(string bigram)
    {
        TableCell bigram_1_cell = TableIndexOf(bigram[0]);
        TableCell bigram_2_cell = TableIndexOf(bigram[1]);
        if (bigram_1_cell.column == bigram_2_cell.column)
        {
            return new string(new char[] { TableCharBelow(bigram_1_cell), TableCharBelow(bigram_2_cell) });
        }
        else if (bigram_1_cell.row == bigram_2_cell.row)
        {
            return new string(new char[] { TableCharNext(bigram_1_cell), TableCharNext(bigram_2_cell) });
        }
        else
        {
            return new string(new char[] { table[bigram_1_cell.row, bigram_2_cell.column], table[bigram_2_cell.row, bigram_1_cell.column] });
        }
    }

    public char TableCharBelow(TableCell tableCell)
    {
        TableCell newCell = new TableCell(tableCell.row + 1, tableCell.column);
        if (newCell.row >= table.GetLength(0))
        {
            newCell.row = 0;
        }
        return table[newCell.row, newCell.column];
    }

    public char TableCharNext(TableCell tableCell)
    {
        TableCell newCell = new TableCell(tableCell.row, tableCell.column + 1);
        if (newCell.column >= table.GetLength(1))
        {
            newCell.column = 0;
        }
        return table[newCell.row, newCell.column];
    }

    public string Encrypt(string text)
    {
        StringBuilder str = new(text);

        for (int i = 0; i < str.Length; i += 2)
        {
            string newBigram = EncryptBigram(str.ToString(i, 2));
            str[i] = newBigram[0];
            str[i + 1] = newBigram[1];
        }
        return str.ToString();
    }

    char DecryptChar(char character)
    {
        
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

    public char[,] Table(string keyword)
    {
        string alphabet = "абвгдежзиклмнопрстуфхцчшщыьэюя";

        string with_keyword = RemoveDup(keyword + alphabet);

        const int rows = 5;
        const int columns = 6;
        char[,] table = new char[rows, columns];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                table[r, c] = with_keyword[r * 6 + c];
            }
        }

        return table;
    }

    public string RemoveDup(string originalString)
    {
        return string.Join("", originalString.ToCharArray().Distinct());
    }

    public TableCell TableIndexOf(char ch)
    {
        for (int r = 0; r < table.GetLength(0); r++)
        {
            for (int c = 0; c < table.GetLength(1); c++)
            {
                if (table[r,c] == ch)
                {
                    return new TableCell(r, c);
                }    
            }
        }

        return new TableCell();
    }

    public struct TableCell
    {
        public int row;
        public int column;

        public TableCell(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public TableCell()
        {
            this.row = -1;
            this.column = -1;
        }
    }
}
