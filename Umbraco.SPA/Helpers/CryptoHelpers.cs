using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Umbraco.Extensions.Helpers
{
    /// <summary> 
    /// Perform crypto calculations 
    /// </summary> 
    static class CryptoHelpers
    {
        /// <summary> 
        /// Calculates MD5 hash from the provided string input. 
        /// </summary> 
        /// <param name="input">String to hash</param> 
        public static string GetMD5StringSum(string input)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary> 
        /// CreateCheckHash 
        /// </summary> 
        public static string GetHMACSHA256(string secretcode, string message)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(secretcode);

            var hasher = new HMACSHA256(secretBytes);

            byte[] result = hasher.ComputeHash(Encoding.UTF8.GetBytes(message));

            string checkhash = BitConverter.ToString(result).Replace("-", "");

            return checkhash;
        }

        /// <summary> 
        /// SHA 256 sum of input stream 
        /// </summary> 
        public static string GetSHASum(Stream input)
        {
            var hasher = new SHA256Managed();
            byte[] result = hasher.ComputeHash(input);

            string checkhash = BitConverter.ToString(result).Replace("-", "");

            return checkhash;
        }
    }
}
