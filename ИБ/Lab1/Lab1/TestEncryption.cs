using System;

namespace Lab1
{
    internal static class TestEncryption
    {
        public static void Test(IEncryption encryption, string text)
        {
            text = text.ToLower();
            Console.WriteLine("Тестирование шифрования - " + encryption.Name);

            Console.WriteLine("Текст который будем шифровать - " + text);
            string en = encryption.Encrypt(text);
            Console.WriteLine("Зашифрованный текст - " + en);
            string de = encryption.Decrypt(en);
            Console.WriteLine("Расшифрованный текст - " + de);
        }
    }
}
