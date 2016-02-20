using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPals
{
    public static class Utilities
    {
        #region Byte Conversions
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
        #endregion
    }
}
