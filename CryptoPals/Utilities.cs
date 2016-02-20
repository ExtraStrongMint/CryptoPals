using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPals
{
    public static class Utilities
    {
        #region Generic Test Extensions
        public static bool IsFull(this string value) { return !string.IsNullOrEmpty(value); }
        #endregion

        #region Byte Conversions
        /// <summary>
        /// Take a hex encoded string and convert it to a byte array
        /// </summary>
        /// <param name="hex_string"></param>
        /// <returns>byte array</returns>
        public static byte[] HexStringToBytes(this string hex_string)
        {
            StringBuilder _ret = new StringBuilder();
            for (int i = 0; i < hex_string.Length; i += 2)
            {
                string _char = hex_string.Substring(i, 2);
                _ret.Append(Convert.ToChar(Convert.ToUInt32(_char, 16)));
            }

            return Encoding.ASCII.GetBytes(_ret.ToString());
        }

        /// <summary>
        /// Convert ascii string into hexadecimal
        /// </summary>
        /// <param name="ascii_string"></param>
        /// <returns>hex string</returns>
        public static string StringToHex(this string ascii_string)
        {
            return BitConverter.ToString(Encoding.ASCII.GetBytes(ascii_string)).Replace("-", string.Empty).ToLower();
        }
        #endregion

        #region base64
        /// <summary>
        /// Take a byte array and convert it to a base64 encoded string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>base64 string</returns>
        public static string BytesToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        #endregion

        #region XOR
        /// <summary>
        /// Overload for byte based xor.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="xor"></param>
        /// <returns>ascii string</returns>
        public static string XOR(this string str, string xor)
        {
            byte[] _bytes = str.HexStringToBytes();
            byte[] _xor = xor.HexStringToBytes();

            return _bytes.XOR(_xor);
        }

        /// <summary>
        /// Take two byte arrays and XOR them
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="xor"></param>
        /// <returns>ascii string</returns>
        public static string XOR(this byte[] bytes, byte[] xor)
        {
            string _ret = "";

            if (bytes.Length == xor.Length)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    _ret += (char)(bytes[i] ^ xor[i]);
                }
            }
            else return null;

            return _ret;
        }
        #endregion
    }
}
