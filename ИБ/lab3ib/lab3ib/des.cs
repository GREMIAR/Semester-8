using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3ib
{
    class des
    {
        public string l1 = string.Empty;
        public string r1 = string.Empty;
        public string l2 = string.Empty;
        public string r2 = string.Empty;
        public string result = string.Empty;
        public des(string text)
        {
            if (text.Length % 2 != 0)
            {
                text += "@";
            }
            for(int i = 0; i < text.Length/2; i++)
            {
                l1 += text[i];
            }
            for(int i = text.Length / 2; i < text.Length; i++)
            {
                r1 += text[i];
            }
        }
        public void startdes()
        {
            l2 = r1;
            for(int i = 0; i < l2.Length; i++)
            {
                r2+= ((char)(l1[i] ^ r1[i])).ToString();
            }
            result += l2;
            result += r2;
        }
    }
}
