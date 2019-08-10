using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class AESAlgorithm
    {
        static string key = "1334567890" +
             "1234567890" +
             "1234567890" +
             "12";

        static string iv = "1334567890" +
        "abcdef";

        /// <summary>
        /// 使用AES 256 加密
        /// </summary>
        /// <param name="source">本文</param>
        /// <param name="key">因為是256 所以你密碼必須為32英文字=32*8=256</param>
        /// <param name="iv">IV為128 所以為 16 * 8= 128</param>
        /// <returns></returns>
        public static string EncryptAES256(string source)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            var aes = new RijndaelManaged();
            aes.Key = Encoding.UTF8.GetBytes(AESAlgorithm.key);
            aes.IV = Encoding.UTF8.GetBytes(AESAlgorithm.iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform transform = aes.CreateEncryptor();

            return Convert.ToBase64String(transform.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length));

        }

        /// <summary>
        /// 使用AES 256 解密
        /// </summary>
        /// <param name="encryptData">Base64的加密後的字串</param>
        /// <param name="key">因為是256 所以你密碼必須為32英文字=32*8=256</param>
        /// <param name="iv">IV為128 所以為 16 * 8= 128</param>
        /// <returns></returns>
        public static string DecryptAES256(string encryptData)
        {
            var encryptBytes = Convert.FromBase64String(encryptData);
            var aes = new RijndaelManaged();
            aes.Key = Encoding.UTF8.GetBytes(AESAlgorithm.key);
            aes.IV = Encoding.UTF8.GetBytes(AESAlgorithm.iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = aes.CreateDecryptor();

            return Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));

        }
    }
}
