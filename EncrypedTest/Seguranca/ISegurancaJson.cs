namespace EncrypedTest.Seguranca
{
    public interface ISegurancaJson
    {
        string Criptografar(string informacao, string chave);
        string DesCriptografar(string informacao, string chave);
        byte[] EncryptASCII(string informacao);
    }
}