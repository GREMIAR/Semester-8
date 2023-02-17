using Lab1.DataTypes.Classes;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        string text = "неясное становится еще более непонятны";
        TestEncryption.Test(new PolybeanSquare(), text);

        TestEncryption.Test(new ReshuffleByKey("лунатик"), text);

        TestEncryption.Test(new TwoTableMethod(), text);
    }
}
