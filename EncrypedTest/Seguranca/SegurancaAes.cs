using System.Security.Cryptography;
using System.Text;

namespace EncrypedTest.Seguranca
{
    public class SegurancaAes : ISegurancaAes
    {
        // Criptografar um texto utilizando o algoritmo AES
        public byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Verifica se os parâmetros são nulos ou vazios
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            // Cria uma instância da classe Aes
            using (Aes aesAlg = Aes.Create())
            {
                // Define a chave e o vetor de inicialização para o algoritmo Aes
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Cria um objeto de transformação de criptografia que será usado para criptografar os dados
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Cria um fluxo de memória para armazenar os dados criptografados
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Cria um fluxo de criptografia que transforma o fluxo de memória em um fluxo criptografado
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        // Cria um objeto StreamWriter para escrever no fluxo criptografado
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Escreve os dados de texto não criptografados no fluxo criptografado
                            swEncrypt.Write(plainText);
                        }

                        // Obtém o array de bytes criptografados do fluxo de memória
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Retorna os dados criptografados como array de bytes
            return encrypted;
        }

        // Descriptografar um texto utilizando o algoritmo AES
        public string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Verifica se os argumentos são válidos
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            // Cria uma nova instância do algoritmo AES
            using (Aes aesAlg = Aes.Create())
            {
                // Define a chave e o vetor de inicialização para o algoritmo
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Cria um objeto CryptoTransform para realizar a descriptografia
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Cria uma nova stream de memória para o texto criptografado
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    // Cria um objeto CryptoStream para processar a descriptografia
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        // Cria um objeto StreamReader para ler o texto descriptografado da stream
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            // Retorna o texto descriptografado
            return plaintext;
        }

    }
}
