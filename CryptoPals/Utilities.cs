using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPals
{
    internal static class Utilities
    {
        #region Generic Test Extensions
        internal static bool IsFull(this string value) { return !string.IsNullOrEmpty(value); }
        #endregion

        #region Byte Conversions
        /// <summary>
        /// Take a hex encoded string and convert it to a byte array
        /// </summary>
        /// <param name="hex_string"></param>
        /// <returns>byte array</returns>
        internal static byte[] HexStringToBytes(this string hex_string)
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
        internal static string StringToHex(this string ascii_string)
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
        internal static string BytesToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        internal static byte[] Base64StringToBytes(this string base64)
        {
            return Convert.FromBase64String(base64);
        }
        #endregion

        #region XOR
        /// <summary>
        /// Overload for byte based xor.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="xor"></param>
        /// <returns>ascii string</returns>
        internal static string XOR(this string str, string xor)
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
        internal static string XOR(this byte[] bytes, byte[] xor)
        {
            string _ret = "";

            if (bytes.Length == xor.Length)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    _ret += (char)(bytes[i] ^ xor[i]);
                }
            }
            else if (xor.Length == 1)
            {
                byte _xor = xor[0];
                for (int i = 0; i < bytes.Length; i++)
                {
                    _ret += (char)(bytes[i] ^ _xor);
                }
            }
            else if (bytes.Length > xor.Length)
            {
                int _loop_max = xor.Length;
                int _loop = 0;
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (_loop >= _loop_max)
                        _loop = 0;
                    _ret += (char)(bytes[i] ^ xor[_loop]);
                    _loop++;
                }
            }
            else throw new NotSupportedException("This action is not supported. param1 < param2");

            return _ret;
        }
        #endregion

        #region Miscellaneous
        /// <summary>
        /// Uses common words/characters to do VERY VERY basic and quick detection of a string.
        /// Not to be relied upon for anything other than baaaasic character detection although we do check for some words
        /// </summary>
        /// <param name="value"></param>
        /// <param name="required_word_weight"></param>
        /// <param name="required_char_percent"></param>
        /// <returns></returns>
        internal static bool FrequencyAnalysis(string value, int required_word_count, int required_char_percent, double min_percent_ALPHANUM, out double character_score)
        {
            char[] common_chars = { 'e', 'a', 'i', 'r', 't', 'o', 'n', 's', 'l', 'c', ' ' };
            string[] common_words = { " a ", " an ", " it ", " of ", " the ", " i" , " you ", " we " };

            char[] check_chars = value.ToCharArray();

            int chars = 0;
            double language = 0;
            foreach (char c in check_chars)
            {
                if (char.IsLetterOrDigit(c))
                    language++;
                if (char.IsWhiteSpace(c))
                    language++;

                foreach (char cx in common_chars)
                {
                    if (cx == char.ToLower(c))
                        chars++;
                }
            }

            double percentage_of_ALPHANUM = (language / check_chars.Length) * 100;

            if (percentage_of_ALPHANUM < min_percent_ALPHANUM)
            {
                character_score = 0;
                return false;
            }

            int words = 0;
            foreach (string w in common_words)
            {
                if (value.Contains(w))
                    words++;
            }
            if (words >= required_word_count)
            {
                double perc = (value.Length * ((double)required_char_percent / 100));
                if (chars >= perc)
                {
                    character_score = chars;
                    return true;
                }
            }
            character_score = 0;
            return false;
        }
        internal static double Hamming(uint x, uint y)
        {
            int distance = 0;
            uint val = x ^ y;

            while (val != 0)
            {
                distance++;
                val &= val - 1;
            }

            return distance;
        }
        #endregion
    }

    internal class Block
    {
        internal int ID { get; set; }
        internal List<byte> Bytes { get; set; }
    }
}
