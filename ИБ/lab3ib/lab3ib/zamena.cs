using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3ib
{
    class zamena
    {
        public string message = string.Empty;
        public string result = string.Empty;
        public string keys = string.Empty;
        public string result2 = string.Empty;
        public zamena(string text)
        {
            message = text;
            randomkey(message.Length);
        }
        public void startzamena()
        {
            for(int i = 0; i < message.Length; i++)
            {
                result += ((char)(message[i] ^ keys[i])).ToString();
            }
        }
        public void randomkey(int len)
        {
            Random xb = new Random();
            for (int i = 0; i < len; i++)
            {
                keys += ((char)xb.Next(35, 126)).ToString();
            }
        }
        public void startperestanovka()
        {
            char[] sort = result.ToCharArray();
            Array.Sort(sort);
            result2 = new string(sort);
        }
    }
}
