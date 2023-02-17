using Lab1.DataTypes.Classes;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        TestEncryption.Test(new PolybeanSquare(), "пусть консулы будут блительны");
        TestEncryption.Test(new ReshuffleByKey("республика"), "пусть консулы будут блительны");
        TestEncryption.Test(new BigramMethod("республика"), "пустьконсулыбудутблительны");
        TestEncryption.Test(new TwoTableMethod(), "пусть консулы будут блительны");
    }
}
