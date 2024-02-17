using Lab1.DataTypes.Classes;
using System;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        //TestEncryption.Test(new PolybeanSquare(), "ïóñòü êîíñóëû áóäóò áëèòåëüíû");
        //TestEncryption.Test(new ReshuffleByKey("ðåñïóáëèêà"), "ïóñòü êîíñóëû áóäóò áëèòåëüíû");
        //TestEncryption.Test(new BigramMethod("ðåñïóáëèêà"), "ïóñòüêîíñóëûáóäóòáëèòåëüíû");
        //TestEncryption.Test(new TwoTableMethod(), "ïóñòü êîíñóëû áóäóò áëèòåëüíû");
        TestEncryption.Test(new StencilMethod(), "priezhau sestovo");
    }
}
