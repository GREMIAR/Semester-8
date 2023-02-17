using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1
{
    internal class ReshuffleByKey : IEncryption
    {
        string key;

        Dictionary<char, char[]> matrix1;

        public string Name => "Перестановка по ключу";

        public ReshuffleByKey(string key)
        {
            this.key = key;
        }


        public string Decrypt(string text)
        {
            int f = text.Length;
            string keySorted = String.Concat(key.OrderBy(ch => ch));
            InitMatrix1(text, keySorted);

            Dictionary<char, char[]> matrix2 = new();

            for (int i=0;i<key.Length;i++)
            {
                char current = key[i];
                if(matrix1.TryGetValue(current, out char[] values))
                {
                    matrix2.Add(current, values);
                }
            }

            return MatrixToText(matrix2);

        }

        public string Encrypt(string text)
        {
            int i = text.Length;
            InitMatrix1(text, key);

            SortedDictionary<char, char[]> sortedMatrix = new SortedDictionary<char, char[]>(matrix1);
            
            return MatrixToText(sortedMatrix);
        }

        void InitMatrix1(string text, string key)
        {
            double number = text.Length;
            int rowsNumber = (int)(Math.Ceiling(number / key.Length));
            matrix1 = new Dictionary<char, char[]>();
            for (int i = 0; i < key.Length; i++)
            {
                char[] valueKey = new char[rowsNumber];
                for (int f = 0; f < rowsNumber; f++)
                {
                    int index = i * (rowsNumber) + f;
                    if (index>=text.Length)
                    {
                        valueKey[f] = ' ';
                    }
                    else
                    {
                        valueKey[f] = text[index];
                    }
                }
                matrix1.Add(key[i], valueKey);
            }
        }

        string MatrixToText(IDictionary<char, char[]> sortedMatrix)
        {
            string str = string.Empty;
            foreach(var value in sortedMatrix.Values)
            {
                str += new string(value);
            }
            return str;
        }
    }
}
