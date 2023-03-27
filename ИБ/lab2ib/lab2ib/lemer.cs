using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2ib
{
    class lemer
    {
        public float[] Q;
        public float[] I;
        public lemer(int size)
        {
            Q = new float[size];
            I = new float[size];
        }

        public void startlemeri()
        {
            float m = 3.0f;
            Random xb = new Random();
            float b = (float)xb.NextDouble();
            I[0] = b;
            float a = 0.25f;
            float c = 0.5f;
            for (int i = 1; i < I.Length; i++)
            {
                I[i] = (a * I[i-1]+c) % b;
            }
        }
        public void startlemerq()
        {
            float m = 3.0f;
            Random xb = new Random();
            float b = (float)xb.NextDouble();
            Q[0] = b;
            for (int i = 1; i < Q.Length; i++)
            {
                Q[i] = ((float)Math.Sqrt(2) * I[i-1]+ (float)Math.Sqrt(5)) % b;
            }
        }
    }
}
