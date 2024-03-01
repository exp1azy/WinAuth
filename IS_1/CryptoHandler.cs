using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace IS_1
{
    public class CryptoHandler
    {
        private readonly IConfiguration _config;

        public CryptoHandler(IConfiguration config)
        {
            _config = config;
        }

        public void EncryptDecryptCredentials(string password, bool encrypt)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(password));
                byte[] iv = new byte[aes.BlockSize / 8];
                Array.Copy(key, iv, iv.Length);

                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CFB;
                aes.Padding = PaddingMode.None;

                string sourceFileName = (encrypt ? _config["DbPath"] : _config["Encrypted"])!;
                string destinationFileName = (encrypt ? _config["Encrypted"] : _config["DbPath"])!;

                using (FileStream sourceFileStream = new FileStream(sourceFileName, FileMode.OpenOrCreate))
                using (FileStream destinationFileStream = new FileStream(destinationFileName, FileMode.OpenOrCreate))
                {
                    using (ICryptoTransform cryptoTransform = encrypt ? aes.CreateEncryptor() : aes.CreateDecryptor())
                    using (CryptoStream cryptoStream = new CryptoStream(destinationFileStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        sourceFileStream.CopyTo(cryptoStream);
                    }
                }
            }
        }

        public void DeleteTempFile()
        {
            if (File.Exists(_config["DbPath"])) File.Delete(_config["DbPath"]!);          
        }
    }
}
