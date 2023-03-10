namespace EncrypedTest.Seguranca
{
    public interface ISegurancaAes
    {
        string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV);
        byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV);
    }
}