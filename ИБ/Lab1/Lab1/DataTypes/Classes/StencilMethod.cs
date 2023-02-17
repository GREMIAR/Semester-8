using System;

namespace Lab1.DataTypes.Classes
{
    internal class StencilMethod : IEncryption
    {
        public string Name => "Трафаретный способ";

        public string Decrypt(string text)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string text)
        {
            throw new NotImplementedException();
        }
    }
}
