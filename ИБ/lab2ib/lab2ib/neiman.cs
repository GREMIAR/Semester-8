using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2ib
{
    class neiman
    {
        public int[] items;

        public neiman(int size)
        {
            items = new int[size];
        }
        public void startneiman(int seed)
        {
            items[0] = seed;
            for (int i = 1; i < items.Length; i++)
            {
                int x = items[i - 1] * items[i - 1];
                items[i] = (x % 1000000) / 100;

            }
        }
    }
}
