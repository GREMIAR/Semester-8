using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2ib
{
    class lemer2
    {
        public float[] items;

        public lemer2(int size)
        {
            items = new float[size];
        }
        public void startlemer2()
        {
            Random xb = new Random();
            float b = (float)xb.NextDouble();
            items[0] = b;
            float c = 0.0f;
            float k = 16807;
            float m = 2147483647;
            for (int i = 1; i < items.Length; i++)
            {
                items[i] = (k * items[i - 1] + c) % m;
            }
        }
    }
}
