using System.Text;

namespace EncrypedTest.Seguranca
{
    public class SegurancaJson : ISegurancaJson
    {

        public string Criptografar(string informacao, string chave)
        {
            // Codifica a informação em Base64
            var codificado = EncodeTo64(informacao);

            // Concatena a chave com a informação codificada, separando-as por "====="
            var codificarComChave = string.Concat(chave, "=====", codificado);

            // Codifica novamente em Base64 a nova string resultante
            var codificado2X = EncodeTo64(codificarComChave);

            // Retorna a nova string codificada em Base64
            return EncodeTo64(codificado2X);
        }

        public string DesCriptografar(string informacao, string chave)
        {
            try
            {
                // Decodifica a informação em Base64
                var decodificar = DecodeFrom64(informacao);

                // Decodifica novamente a informação resultante em Base64
                var decodificar2XInformacaoCompleta = DecodeFrom64(decodificar);

                // Separa a informação decodificada em duas partes usando o separador "====="
                String[] separador = { "=====" };
                Int32 count = 2;
                var separadorInformacao = decodificar2XInformacaoCompleta.Split(separador, count, StringSplitOptions.None);

                // Verifica se a primeira parte da informação decodificada é igual à chave passada como parâmetro
                if (separadorInformacao[0].ToString() == chave)
                {
                    // Retorna a segunda parte da informação decodificada, que representa a informação original
                    return DecodeFrom64(separadorInformacao[1].ToString());
                }
            }
            catch (Exception)
            {

            }

            return string.Empty;
        }


        public byte[] EncryptASCII(string informacao)
        {
            return System.Text.ASCIIEncoding.UTF8.GetBytes(informacao);
        }

        static private string DecodeFrom64(string encodeData)
        {
            // Converte a string em base64 em um array de bytes
            byte[] encodeDataAsByte = System.Convert.FromBase64String(encodeData);

            // Converte o array de bytes em uma string ASCII e retorna o resultado
            string returnValue = System.Text.ASCIIEncoding.UTF8.GetString(encodeDataAsByte);
            return returnValue;
        }

        static private string EncodeTo64(string toEncode)
        {
            // Converte a string em ASCII para um array de bytes
            byte[] toEncodeAsByte = System.Text.ASCIIEncoding.UTF8.GetBytes(toEncode);

            // Converte o array de bytes em uma string em base64 e retorna o resultado
            string returnValue = System.Convert.ToBase64String(toEncodeAsByte);
            return returnValue;
        }


    }
}

