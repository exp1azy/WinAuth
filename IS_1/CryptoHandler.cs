using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace IS_1
{
    public class CryptoHandler
    {
        private readonly IConfiguration _config;

        public CryptoHandler(IConfiguration config)
        {
            _config = config;
        }   

        public void DeleteTemp() => File.Delete(_config["DbPath"]!);

        public void Encrypt(string password)
        {
            byte[] salt = GenerateSalt();

            using var aesAlg = Aes.Create();

            aesAlg.Key = GenerateBytes(password, salt, aesAlg.KeySize / 8);
            aesAlg.IV = GenerateBytes(password, salt, aesAlg.BlockSize / 8);

            using var inputFileStream = new FileStream(_config["DbPath"]!, FileMode.Open);
            using var outputFileStream = new FileStream(_config["EncryptedDbPath"]!, FileMode.OpenOrCreate);
            using var cryptoStream = new CryptoStream(outputFileStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write);

            outputFileStream.Write(salt, 0, salt.Length);
            inputFileStream.CopyTo(cryptoStream);
        }

        public void Decrypt(string password)
        {
            try
            {
                using Aes aesAlg = Aes.Create();

                byte[] salt = new byte[16];
                using (FileStream encryptedFileStream = new FileStream(_config["EncryptedDbPath"]!, FileMode.Open))
                {
                    encryptedFileStream.Read(salt, 0, salt.Length);
                }

                aesAlg.Key = GenerateBytes(password, salt, aesAlg.KeySize / 8);
                aesAlg.IV = GenerateBytes(password, salt, aesAlg.BlockSize / 8);

                using FileStream inputFileStream = new FileStream(_config["EncryptedDbPath"]!, FileMode.Open);
                inputFileStream.Seek(salt.Length, SeekOrigin.Begin);
                using FileStream outputFileStream = new FileStream(_config["DbPath"]!, FileMode.OpenOrCreate);
                using CryptoStream cryptoStream = new CryptoStream(inputFileStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);

                cryptoStream.CopyTo(outputFileStream);
            }
            catch
            {
                DeleteTemp();
                throw;
            }
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private byte[] GenerateBytes(string password, byte[] salt, int bytes)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000);
            return deriveBytes.GetBytes(bytes);
        }
    }
}
