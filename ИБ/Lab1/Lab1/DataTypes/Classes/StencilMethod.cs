using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Lab1.DataTypes.Classes
{
    internal class StencilMethod : IEncryption
    {
        public string Name => "Трафаретный способ";

        private Table table;
        
        public string Decrypt(string text)
        {
            //throw new NotImplementedException();
            return text;
        }
        
        public string Encrypt(string text)
        {
            table = new Table();

            for (int i = 0; i < text.Length; i++)
            {
                table.Write(text[i]);
            }
            return TableToString(table.table); // backBack
        }
        // 3 8 10 13 - 1 6 12 15 - 4 7 9 14 - 2 5 11 16
        static char[,] RotateMatrix(char[,] oldMatrix)
        {
            char[,] newMatrix = oldMatrix;
            for (int i = 0; i < 1; i++)
            {
                newMatrix = RotateMatrixCounterClockwise(newMatrix);
            }
            return newMatrix;
        }

        public static string TableToString(char[,] table)
        {
            string str = "";
            for(int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    str += table[r, c];
                }
            }
            return str;
        }

        public class Table
        {
            public const int rows = 4;
            public const int columns = 4;
            public char[,] table;
            public Cell[] stencil;
            public int stencil_counter;

            public Table()
            {
                table = new char[rows, columns];
                InitStencil(new Cell(0,2), new Cell(1,3), new Cell(2,1), new Cell(3,0));
            }

            private void InitStencil(params Cell[] cells)
            {
                stencil = cells;
                stencil_counter = 0;
            }

            public void Write(char ch)
            {
                Cell cell = stencil[stencil_counter];
                table[cell.row, cell.column] = ch;
                UpdateStencilCounter();
            }

            private void UpdateStencilCounter()
            {
                stencil_counter++;
                if (stencil_counter >= stencil.Length)
                {
                    stencil_counter = 0;
                    table = RotateMatrix(table);
                }
            }

            public struct Cell
            {
                public int row;
                public int column;

                public Cell(int row, int column)
                {
                    this.row = row;
                    this.column = column;
                }
            }
        }

        static char[,] RotateMatrixCounterClockwise(char[,] oldMatrix)
        {
            char[,] newMatrix = new char[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }
    }
}
