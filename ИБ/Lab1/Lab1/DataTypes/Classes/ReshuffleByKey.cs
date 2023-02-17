using System;

namespace Lab1
{
    internal class ReshuffleByKey : IEncryption
    {
        string key;

        char[,] matrix;

        public ReshuffleByKey(string key)
        {
            this.key = key;
        }


        public string Decrypt(string text)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string text)
        {
            double number = text.Length;

            int rowsNumber = (int)(Math.Ceiling(number / key.Length));

            matrix = new char[rowsNumber, key.Length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = text[i * matrix.GetLength(1) + f];
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                //matrix.Sort([4, 7, 9, 0, 7, 6, 5])
            }
            return text;
        }
    }
}
