using System;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        PolybeanSquare polybeanSquare = new PolybeanSquare();
        Console.WriteLine("тест");
        string r1 = polybeanSquare.Encrypt("тест");
        Console.WriteLine(r1);
        string r2 = polybeanSquare.Decrypt(r1);
        Console.WriteLine(r2);
    }
}
