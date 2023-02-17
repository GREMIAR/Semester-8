using Lab1.DataTypes.Classes;
using System;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        TestEncryption.Test(new PolybeanSquare());

        TestEncryption.Test(new ReshuffleByKey("лунатик"));

        TestEncryption.Test(new TwoTableMethod());
    }
}
