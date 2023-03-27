using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2ib
{
    class mz
    {
        public long[] items = new long[1000];
        public long[] results;
        public mz(int size)
        {
            results = new long[size];
            items[0] = 0;
            items[1] = 1;
            for(int i = 2; i < items.Length; i++)
            {
                items[i] = items[i - 2] + items[i - 1];
            }
        }
        public void startmz(int n)
        {
            for(int i = 0; i < items.Length; i++)
            {
                string tmp = Convert.ToString(items[i]);
                if (tmp.Length > 1)
                {
                    items[i] = items[i]%10;
                }
            }
            for (int j = 0; j < results.Length; j++)
            {
                Random xb = new Random();
                int b = xb.Next(0,999);
                for (int i = j+b; i < items.Length; i += n)
                {
                    results[j] =results[j]+ items[i];
                }
                if (results[j] < 0)
                {
                    results[j] *= -1;
                }
            }
        }
    }
}
