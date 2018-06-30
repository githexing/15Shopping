using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Library
{
    public class AESEncrypt
    {
        private static string AESKey = "27026a9191a3ddff3b089d67c715c028";
        /// <summary>
        /// 加密-128-ECB
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, AESKey);
        }
        /// <summary>
        /// 有密码的AES加密
        /// </summary>
        /// <param name="toEncrypt">加密字符</param>
        /// <param name="key">加密的密码</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt,string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.None;// PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray,0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, AESKey);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="toDecrypt">解密字符</param>
        /// <param name="key">解密的密码</param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
          //  byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toDecrypt);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);


            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.None;// PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
