using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPals.Modules
{
    public static class Basics
    {
        public static string Solve(int challenge)
        {
            switch (challenge)
            {
                case 1:
                    return One();
                case 2:
                    return Two();
                case 3:
                    return Three();
                case 4:
                    return Four();
                case 5:
                    return Five();
                case 6:
                    return Six();
                case 7:
                    return Seven();
                case 8:
                    return Eight();
                default:
                    return "Unknown";
            }
        }

        private static string One()
        {
            string str = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            byte[] raw_bytes = str.HexStringToBytes();

            string known_ret = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";
            string result = raw_bytes.BytesToBase64String();

            if (result == known_ret)
            {
                return result;
            }

            return "Unsolved!";
        }

        private static string Two()
        {
            string str = "1c0111001f010100061a024b53535009181c";
            string xor = "686974207468652062756c6c277320657965";

            string result = str.XOR(xor).StringToHex();
            string known_ret = "746865206b696420646f6e277420706c6179";

            if (result == known_ret)
            {
                return result;
            }

            return "Unsolved!";
        }

        private static string Three()
        {
            return "Unsolved";
        }

        private static string Four()
        {
            return "Unsolved";
        }

        private static string Five()
        {
            return "Unsolved";
        }

        private static string Six()
        {
            return "Unsolved";
        }

        private static string Seven()
        {
            return "Unsolved";
        }

        private static string Eight()
        {
            return "Unsolved";
        }
    }
}
