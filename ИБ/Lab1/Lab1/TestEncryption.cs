using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal static class TestEncryption
    {
        public static void Test(IEncryption encryption)
        {
            string text = "НЕЯСНОЕ СТАНОВИТСЯ ЕЩЕ БОЛЕЕ НЕПОНЯТНЫМ";
            Console.WriteLine("Тестирование шифрования - " + encryption.Name);

            Console.WriteLine("Текст который будем шифровать - " + text);
            string en = encryption.Encrypt(text);
            Console.WriteLine("Зашифрованный текст - " + en);
            string de = encryption.Decrypt(en);
            Console.WriteLine("Расшифрованный текст - " + de);
        }
    }
}
