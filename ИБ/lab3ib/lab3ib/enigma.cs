using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3ib
{
    class enigma
    {
        public string[] rotor1=new string[32];
        public int[] rkey1=new int[32];
        public string[] rotor2 = new string[32];
        public int[] rkey2 = new int[32];
        public string[] rotor3 = new string[32];
        public int[] rkey3 = new int[32];
        public string[] rotor12 = new string[32];
        public string[] rotor22 = new string[32];
        public string[] rotor32 = new string[32];
        public string result = string.Empty;

        public enigma()
        {
            startrandomarr(rkey1,rkey2,rkey3);
            startrandletters(rotor1,rotor2,rotor3);
            startrandletters(rotor12, rotor22, rotor32);
        }
        public void startenigma(string text, int num1, int num2, int num3){
            num1 = num1 - 1;
            num2 = num2 - 1;
            num3 = num3- 1;
            int r1 = num1;
            int r2 = num2;
            int r3 = num3;
            for(int i = 0; i < text.Length; i++)
            {
                string tmp = string.Empty;
                if(text[i]==' ')
                {
                    result += ' ';
                }
                else
                {
                    tmp = rotor1[num1];
                    tmp = rotor12[rkey1[num1]-1];
                    int tmpx2 = 0;
                    if (rkey1[num1]-1 > num2)
                    {
                        tmpx2 = rkey1[num1] - 1 + num2;
                        if (tmpx2 > 31)
                        {
                            tmpx2 = tmpx2 - 32;
                        }
                    }
                    else if(rkey1[num1]-1 < num2)
                    {
                        tmpx2 = rkey1[num1] - 1 - num2;
                        if (tmpx2 < 0)
                        {
                            tmpx2 = tmpx2 + 32;
                        }
                    }
                    tmp = rotor2[tmpx2];
                    tmp = rotor22[rkey2[tmpx2]-1];
                    if (rkey2[tmpx2] - 1 > num3)
                    {
                        tmpx2 = rkey2[tmpx2] - 1 + num3;
                        if (tmpx2 > 31)
                        {
                            tmpx2 = tmpx2 - 32;
                        }
                    }
                    else if (rkey2[tmpx2] - 1 < num3)
                    {
                        tmpx2 = rkey2[tmpx2] - 1 - num3;
                        if (tmpx2 < 0)
                        {
                            tmpx2 = tmpx2 + 32;
                        }
                    }
                    tmp = rotor3[tmpx2];
                    tmp = rotor32[rkey3[tmpx2] - 1];
                    result += tmp;
                    num1++;
                    if (num1 > 31)
                    {
                        num1 = 0;
                    }
                    if (num1 == r1)
                    {
                        num2++;
                        if (num2 > 31)
                        {
                            num2 = 0;
                        }
                        if (num2 == r2)
                        {
                            num3++;
                        }
                    }
                }
            }
        }
        public void startrandomarr(int[] arr,int[] arr1,int[] arr2)
        {
            List<int> list = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32 };
            List<int> list1 = new List<int> {  18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            List<int> list2 = new List<int> { 23, 24, 25, 1, 2, 3, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 26, 27, 28, 29, 30, 31, 32, 4, 5, 6, 7, 8 };
            Random random = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                int x = random.Next(1, list.Count);
                arr[i] = list[x-1];
                list.RemoveAt(x-1);
                int x1 = random.Next(1, list1.Count);
                arr1[i] = list1[x1 - 1];
                list1.RemoveAt(x1 - 1);
                int x2 = random.Next(1, list2.Count);
                arr2[i] = list2[x2 - 1];
                list2.RemoveAt(x2 - 1);
            }
        }
        public void startrandletters(string[] arr,string[] arr1,string[] arr2)
        {
            List<string> list=new List<string> { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            List<string> list1 = new List<string> { "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я", "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "м", "н", "о", "п", "р", "с" };
            List<string> list2 = new List<string> { "а",  "и", "й", "к", "м", "н", "б", "в", "г", "д", "е", "ё", "ж", "з", "о", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "п", "р", "с", "т", "у", "э", "ю", "я" };
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int x = random.Next(1, list.Count);
                arr[i] = list[x - 1];
                list.RemoveAt(x - 1);
                int x1 = random.Next(1, list1.Count);
                arr1[i] = list1[x1 - 1];
                list1.RemoveAt(x1 - 1);
                int x2 = random.Next(1, list2.Count);
                arr2[i] = list2[x2 - 1];
                list2.RemoveAt(x2 - 1);
            }
        }
    }
}
