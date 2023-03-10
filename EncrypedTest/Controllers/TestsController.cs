using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EncrypedTest.Data;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using EncrypedTest.Models;
using EncrypedTest.Seguranca;

namespace EncrypedTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly EncrypedTestContext _context;
        private readonly ISegurancaAes _segurancaAes;
        private readonly ISegurancaJson _segurancaJson;
        public TestsController(EncrypedTestContext context, ISegurancaAes segurancaAes, ISegurancaJson segurancaJson)
        {
            _context = context;
            _segurancaAes = segurancaAes;
            _segurancaJson = segurancaJson;
        }


        /// <summary>
        /// Utiliza a encriptação AES e inserida em Byte na BD
        /// Também é guardada duas chaves Key e IV para a desecriptação de cada linha da BD
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>

        // POST: api/Tests
        [HttpPost("PostTestAes")]
        public async Task<ActionResult<String>> PostTestAes(TestString testString)
        {
            
            try
            {
                TesteTempo testeTempo1 = new TesteTempo();
                testeTempo1.Inicio = DateTime.UtcNow;

                using (Aes myAes = Aes.Create())
                {
                    Test test = new Test();
                    // Encrypt the string to an array of bytes.

                    test.Campo1 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo1, myAes.Key, myAes.IV);
                    test.Campo2 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo2, myAes.Key, myAes.IV);
                    test.Campo3 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo3, myAes.Key, myAes.IV);
                    test.Campo4 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo4, myAes.Key, myAes.IV);
                    test.Campo5 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo5, myAes.Key, myAes.IV);
                    test.Campo6 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo6, myAes.Key, myAes.IV);
                    test.Campo7 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo7, myAes.Key, myAes.IV);
                    test.Campo8 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo8, myAes.Key, myAes.IV);
                    test.Campo9 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo9, myAes.Key, myAes.IV);
                    test.Campo10 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo10, myAes.Key, myAes.IV);
                    test.Campo11 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo11, myAes.Key, myAes.IV);
                    test.Campo12 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo12, myAes.Key, myAes.IV);
                    test.Campo13 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo13, myAes.Key, myAes.IV);
                    test.Campo14 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo14, myAes.Key, myAes.IV);
                    test.Campo15 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo15, myAes.Key, myAes.IV);
                    test.Campo16 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo16, myAes.Key, myAes.IV);
                    test.Campo17 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo17, myAes.Key, myAes.IV);
                    test.Campo18 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo18, myAes.Key, myAes.IV);
                    test.Campo19 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo19, myAes.Key, myAes.IV);
                    test.Campo20 = _segurancaAes.EncryptStringToBytes_Aes(testString.Campo20, myAes.Key, myAes.IV);
                    test.Key = myAes.Key;
                    test.IV = myAes.IV;

                    _context.Test.Add(test);


                }
                testeTempo1.Fim = DateTime.UtcNow;
                testeTempo1.Teste = "myAes";
                _context.TesteTempo.Add(testeTempo1);

                await _context.SaveChangesAsync();

                return "The file was encrypted.";
            }
            catch (Exception)
            {
                return "Fail";
            }

        }

        /// <summary>
        /// Utiliza a encriptação AES e inserida em Byte na BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Classe TestStringM com 20 campos de string </returns>
        [HttpGet("GetTestAes{id}")]
        public async Task<ActionResult<TestString>> GetTestAes(int id)
        {
            TesteTempo testeTempo1 = new TesteTempo();
            testeTempo1.Inicio = DateTime.UtcNow;
            TestString testString1 = new TestString();
            using (Aes myAes = Aes.Create())
            {

                var test = await _context.Test.FindAsync(id);
                var Key = test.Key;
                var IV = test.IV;
                // Decrypt the bytes to a string.
                testString1.Campo1 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo1, Key, IV);
                testString1.Campo2 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo2, Key, IV);
                testString1.Campo3 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo3, Key, IV);
                testString1.Campo4 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo4, Key, IV);
                testString1.Campo5 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo5, Key, IV);
                testString1.Campo6 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo6, Key, IV);
                testString1.Campo7 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo7, Key, IV);
                testString1.Campo8 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo8, Key, IV);
                testString1.Campo9 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo9, Key, IV);
                testString1.Campo10 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo10, Key, IV);
                testString1.Campo11 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo11, Key, IV);
                testString1.Campo12 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo12, Key, IV);
                testString1.Campo13 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo13, Key, IV);
                testString1.Campo14 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo14, Key, IV);
                testString1.Campo15 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo15, Key, IV);
                testString1.Campo16 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo16, Key, IV);
                testString1.Campo17 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo17, Key, IV);
                testString1.Campo18 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo18, Key, IV);
                testString1.Campo19 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo19, Key, IV);
                testString1.Campo20 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo20, Key, IV);


            }
            testeTempo1.Fim = DateTime.UtcNow;
            testeTempo1.Teste = "myAesGet";
            _context.TesteTempo.Add(testeTempo1);

            await _context.SaveChangesAsync();

            if (testString1 == null)
            {
                return NotFound();
            }

            return testString1;
        }

        /// <summary>
        /// Utiliza a encriptação AES e inserida em Byte na BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Classe TestStringM com 10 campos de string </returns>
        [HttpGet("GetAesMetade{id}")]
        public async Task<ActionResult<TestStringM>> GetAesMetade(int id)
        {
            TesteTempo testeTempo1 = new TesteTempo();
            testeTempo1.Inicio = DateTime.UtcNow;
            TestStringM testString1 = new TestStringM();
            using (Aes myAes = Aes.Create())
            {

                var test = await _context.Test.FindAsync(id);
                var Key = test.Key;
                var IV = test.IV;
                // Decrypt the bytes to a string.
                testString1.Campo1 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo1, Key, IV);
                testString1.Campo2 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo2, Key, IV);
                testString1.Campo3 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo3, Key, IV);
                testString1.Campo4 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo4, Key, IV);
                testString1.Campo5 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo5, Key, IV);
                testString1.Campo6 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo6, Key, IV);
                testString1.Campo7 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo7, Key, IV);
                testString1.Campo8 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo8, Key, IV);
                testString1.Campo9 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo9, Key, IV);
                testString1.Campo10 = _segurancaAes.DecryptStringFromBytes_Aes(test.Campo10, Key, IV);



            }
            testeTempo1.Fim = DateTime.UtcNow;
            testeTempo1.Teste = "GetTestAesMetade";
            _context.TesteTempo.Add(testeTempo1);

            await _context.SaveChangesAsync();

            if (testString1 == null)
            {
                return NotFound();
            }

            return testString1;
        }

        /// <summary>
        /// Utiliza a encriptação AES com a classe convertida em Json e inserida em Byte, num só campo na BD
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>

        [HttpPost("PostAesJson")]
        public async Task<ActionResult<String>> PostAesJson(TestString testString)
        {

            try
            {

                // metodo Json
                TesteTempo testeTempo = new TesteTempo();
                testeTempo.Inicio = DateTime.UtcNow;



                using (Aes myAes = Aes.Create())
                {

                    // Encrypt the string to an array of bytes.
                    var mensagemJson = JsonConvert.SerializeObject(testString);

                    TestAesJson testAesJson = new()
                    {
                        CampoJson = _segurancaAes.EncryptStringToBytes_Aes(mensagemJson, myAes.Key, myAes.IV),
                        Key = myAes.Key,
                        IV = myAes.IV,
                    };

                    _context.TestAesJson.Add(testAesJson);

                }

                testeTempo.Fim = DateTime.UtcNow;
                testeTempo.Teste = "PostAesJson";
                _context.TesteTempo.Add(testeTempo);

                await _context.SaveChangesAsync();


                return "The file was encrypted.";
            }
            catch (Exception)
            {
                return "Fail";
            }

        }
        /// <summary>
        /// Utiliza a encriptação AES com a classe convertida em Json e inserida em Byte, num só campo na BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Classe TestString com 20 campos de string </returns>

        [HttpGet("GetAesJson{id}")]
        public async Task<ActionResult<TestString>> GetAesJson(int id)
        {

            TesteTempo testeTempo = new TesteTempo();
            testeTempo.Inicio = DateTime.UtcNow;

            var testJson = await _context.TestAesJson.FindAsync(id);

            TestString testString = new TestString();

            var valorDecriptografado = _segurancaAes.DecryptStringFromBytes_Aes(testJson.CampoJson, testJson.Key, testJson.IV);

            if (!string.IsNullOrWhiteSpace(valorDecriptografado))
            {
                testString = JsonConvert.DeserializeObject<TestString>(valorDecriptografado);
            }

            testeTempo.Fim = DateTime.UtcNow;
            testeTempo.Teste = "GetAesJson";
            _context.TesteTempo.Add(testeTempo);

            await _context.SaveChangesAsync();

            if (testString == null)
            {
                return NotFound();
            }

            return testString;
        }



        // Encriptação ASCIIEncoding 

        /// <summary>
        /// Utiliza a encriptação do ASCIIEncoding com a classe convertida em Json e inserida como String num só campo na BD
        /// É criada uma Chaves randon que é guardada na BD, uma chave para cada codificação 
        /// Este metodo codifica 3 vezes a string
        /// 1- Codifica a string com a classe em Json
        /// 2- Codifica a concatenação da string codificada e com a chave randon e uma chave fixa
        /// 3- Codificar outra vez
        /// Por fim converte a codificação que está em bytes para string
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>
        [HttpPost("PostTestJson")]
        public async Task<ActionResult<String>> PostTestJson(TestString testString)
        {

            try
            {

                // metodo Json
                TesteTempo testeTempo = new TesteTempo();
                testeTempo.Inicio = DateTime.UtcNow;

                Random rnd = new Random();
                string chave = rnd.Next(111111, 999999).ToString();
                var mensagemJson = JsonConvert.SerializeObject(testString);

                TestJson testJson = new TestJson()
                {
                    CampoJason = _segurancaJson.Criptografar(mensagemJson, chave),
                    Chave = chave
                };

                _context.TestJson.Add(testJson);

                testeTempo.Fim = DateTime.UtcNow;
                testeTempo.Teste = "TestJson";
                _context.TesteTempo.Add(testeTempo);

                await _context.SaveChangesAsync();


                return "The file was encrypted.";
            }
            catch (Exception)
            {
                return "Fail";
            }

        }

        /// <summary>
        /// Utiliza a encriptação do ASCIIEncoding com a classe convertida em Json e inserida como String num só campo na BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetTestJson{id}")]
        public async Task<ActionResult<TestString>> GetTestJson(int id)
        {

            TesteTempo testeTempo = new TesteTempo();
            testeTempo.Inicio = DateTime.UtcNow;

            var testJson = await _context.TestJson.FindAsync(id);

            TestString testString = new TestString();

            var valorDecriptografado = _segurancaJson.DesCriptografar(testJson.CampoJason, testJson.Chave);

            if (!string.IsNullOrWhiteSpace(valorDecriptografado))
            {
                testString = JsonConvert.DeserializeObject<TestString>(valorDecriptografado);
            }

            testeTempo.Fim = DateTime.UtcNow;
            testeTempo.Teste = "TestJsonGet";
            _context.TesteTempo.Add(testeTempo);

            await _context.SaveChangesAsync();

            if (testString == null)
            {
                return NotFound();
            }

            return testString;
        }

 

   

        /// <summary>
        /// Utiliza a encriptação do ASCIIEncoding com a classe convertida em Json e inserida num só campo na BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Classe TestStringM com 10 campos de string </returns>

        [HttpGet("GetJsonMetade{id}")]
        public async Task<ActionResult<TestStringM>> GetJsonMetade(int id)
        {

            TesteTempo testeTempo = new TesteTempo();
            testeTempo.Inicio = DateTime.UtcNow;

            var testJson = await _context.TestJson.FindAsync(id);

            TestString testString = new TestString();

            var valorDecriptografado = _segurancaJson.DesCriptografar(testJson.CampoJason, testJson.Chave);

            if (!string.IsNullOrWhiteSpace(valorDecriptografado))
            {
                testString = JsonConvert.DeserializeObject<TestString>(valorDecriptografado);
            }

            TestStringM testStringM = new()
            {
                Campo1 = testString.Campo1,
                Campo2 = testString.Campo2,
                Campo3 = testString.Campo3,
                Campo4 = testString.Campo4,
                Campo5 = testString.Campo5,
                Campo6 = testString.Campo6,
                Campo7 = testString.Campo7,
                Campo8 = testString.Campo8,
                Campo9 = testString.Campo9,
                Campo10 = testString.Campo10,
            };


            testeTempo.Fim = DateTime.UtcNow;
            testeTempo.Teste = "GetTestJsonMetade";
            _context.TesteTempo.Add(testeTempo);

            await _context.SaveChangesAsync();

            if (testStringM == null)
            {
                return NotFound();
            }

            return testStringM;
        }

        [HttpPost("PostJsonASCII")]
        public async Task<ActionResult<String>> PostJsonASCII(TestString testString)
        {

            try
            {

                // metodo Json
              //  TesteTempo testeTempo = new TesteTempo();
                //testeTempo.Inicio = DateTime.UtcNow;

                TestASCII testASCII = new TestASCII();
                testASCII.CampoJson = _segurancaJson.EncryptASCII( JsonConvert.SerializeObject(testString));


                _context.TestASCII.Add(testASCII);

                //testeTempo.Fim = DateTime.UtcNow;
                //testeTempo.Teste = "TestJson";
                //_context.TesteTempo.Add(testeTempo);

                await _context.SaveChangesAsync();


                return "The file was encrypted.";
            }
            catch (Exception)
            {
                return "Fail";
            }


        }

    }
}
