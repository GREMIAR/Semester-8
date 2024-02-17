using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2ib
{
    class mnogochlen
    {
        public float[] Q;
        public float[] I;
        public mnogochlen(int size)
        {
            Q = new float[size];
            I = new float[size];
        }

        public void startmnogochleni()
        {
            float a=0.25f;
            Random xb = new Random();
            float b = (float)xb.NextDouble();
            for (int i = 0; i < I.Length; i++)
            {
                I[i] = (a * (i + 1) + b)%1;
            }
        }
        public void startmnogochlenr()
        {
            Random xb = new Random();
            float b = (float)xb.NextDouble();
            for (int i = 0; i < Q.Length; i++)
            {
                Q[i] = ((float)Math.Sqrt(2) * (i + 1) + b) % 1;
            }
        }
    }
}
