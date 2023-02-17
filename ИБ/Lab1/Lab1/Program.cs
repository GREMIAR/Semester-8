using System;
using System.Text;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        TestEncryption(new BigramMethod("республика"));
    }

    static void TestEncryption(IEncryption encryption)
    {
        string text = "пустьконсулыбудутбдительны";
        Console.WriteLine("Тестирование шифрования - "+encryption.Name);

        Console.WriteLine("Текст который будем шифровать - " + text);
        string en = encryption.Encrypt(text);
        Console.WriteLine("Зашифрованный текст - " + en);
        string de = encryption.Decrypt(en);
        Console.WriteLine("Расшифрованный текст - " + de);
    }
}
