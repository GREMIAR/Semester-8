namespace Lab1;

public interface IEncryption
{
    string Name { get; }
    public string Encrypt(string text);

    public string Decrypt(string text);
}
