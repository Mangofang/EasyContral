using System;
using System.IO;
using System.Security.Cryptography;

namespace Tools
{
    internal class Program
    {
        static public string Key = "jV5lO66M/CmXk3OP067sLbgfYTAanFcAT8oOhSzUYtw=";
        static public string IV = "rNQez1Kfq8OqujG5EuyrVA==";
        static void Main(string[] args)
        {
            Console.WriteLine("--------------加解密工具--------------");
            Console.WriteLine("使用说明：[de/en]:[密文/明文]");
            Console.WriteLine("例如：");
            Console.WriteLine("- 加密：en:Hello");
            Console.WriteLine("- 解密：de:X1NQrajSc0eYNCNia4i31w==\n");
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(':');
                    string cmd = input[0];
                    string txt = input[1];
                    string result = "";
                    if (cmd.ToLower() == "de")
                    {
                        result = AESDecrypt(txt);
                    }
                    else if (cmd.ToLower() == "en") { result = AESEncrypt(txt); }
                    Console.WriteLine(result);
                }
                catch (Exception ex) { Console.WriteLine("输入错误"); }
            }
        }
        public static string AESEncrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = Convert.FromBase64String(Key);
                byte[] iv = Convert.FromBase64String(IV);
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
        public static string AESDecrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = Convert.FromBase64String(Key);
                byte[] iv = Convert.FromBase64String(IV);
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
