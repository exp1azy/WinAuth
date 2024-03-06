using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace IS_1
{
    public class CryptoHandler
    {
        private readonly IConfiguration _config;

        private byte[] _key = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10];
        private byte[] _IV = [0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F, 0x20];

        public CryptoHandler(IConfiguration config)
        {
            _config = config;
        }

        public void EncryptDecrypt(bool encrypt)
        {
            if (encrypt)
            {
                try
                {
                    var textFromJson = File.ReadAllText(_config["DbPath"]!);
                    var bytesFromJson = EncryptStringToBytes(textFromJson, _key, _IV);

                    using (var fStream = new FileStream(_config["EncryptedDbPath"]!, FileMode.OpenOrCreate))
                    {
                        fStream.Write(bytesFromJson);
                    }
                }
                catch 
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    var bytesFromTxt = File.ReadAllBytes(_config["EncryptedDbPath"]!);
                    var textFromTxt = DecryptStringFromBytes(bytesFromTxt, _key, _IV);

                    using (FileStream fs = File.Create(_config["DbPath"]!))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(textFromTxt);

                        fs.Write(data, 0, data.Length);
                    }
                }
                catch 
                {
                    throw;
                }
            }           
        }

        public bool CheckPassword(string password)
        {
            var insertedPass = HashCreator.CreateStringSHA256(password);
            var actualPass = _config["Hash"]!;

            return insertedPass == actualPass;
        }

        public void DeleteTempFile()
        {
            if (File.Exists(_config["DbPath"])) File.Delete(_config["DbPath"]!);
        }

        private string DecryptStringFromBytes(byte[] encrypted, byte[] key, byte[] IV)
        {
            string? plaintext = null;

            try
            {
                using (var rijAlg = Rijndael.Create())
                {
                    rijAlg.Key = key;
                    rijAlg.IV = IV;

                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                    using (var msDecrypt = new MemoryStream(encrypted))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return plaintext;
        }

        private byte[] EncryptStringToBytes(string original, byte[] key, byte[] IV)
        {
            byte[] encrypted;

            try
            {
                using (var rijAlg = Rijndael.Create())
                {
                    rijAlg.Key = key;
                    rijAlg.IV = IV;

                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(original);
                            }

                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
            } 
            catch
            {
                throw;
            }

            return encrypted;
        }
    }
}
