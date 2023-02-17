using System;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        TestEncryption(new PolybeanSquare());
    }

    static void TestEncryption(IEncryption encryption)
    {
        string text = "тест? ещё и много";
        Console.WriteLine("Тестирование шифрования - "+encryption.Name);

        Console.WriteLine("Текст который будем шифровать - " + text);
        string en = encryption.Encrypt(text);
        Console.WriteLine("Зашифрованный текст - " + en);
        string de = encryption.Decrypt(en);
        Console.WriteLine("Расшифрованный текст - " + de);
    }
}
