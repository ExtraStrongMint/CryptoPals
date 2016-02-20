using CryptoPals.Properties;
using System;
using System.Collections.Generic;
using System.IO;
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
            string str = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
            byte[] raw_bytes = str.HexStringToBytes();

            Dictionary<string, double> candidates = new Dictionary<string, double>();

            int[] ascii = Enumerable.Range('\x1', 127).ToArray();
            for (int i = 0; i < ascii.Length; i++)
            {
                char c = (char)ascii[i];
                string result = raw_bytes.XOR(Encoding.ASCII.GetBytes(new char[] { c }));
                double cscore;
                if (true == Utilities.FrequencyAnalysis(result, 1, 30, out cscore))
                    candidates.Add(result, cscore);
            }

            // Highest scoring
            return candidates.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

        private static string Four()
        {
            string str = Resources.Set1_C4;
            str = str.Replace("\r", string.Empty);
            List<string> strings = str.Split('\n').ToList();

            Dictionary<string, double> candidates = new Dictionary<string, double>();

            foreach (string enc in strings)
            {
                byte[] raw_bytes = enc.HexStringToBytes();
                int[] ascii = Enumerable.Range('\x1', 127).ToArray();

                for (int i = 0; i < ascii.Length; i++)
                {
                    char c = (char)ascii[i];
                    string result = raw_bytes.XOR(Encoding.ASCII.GetBytes(new char[] { c }));
                    double cscore;
                    if (true == Utilities.FrequencyAnalysis(result, 2, 35, out cscore))
                        candidates.Add(result, cscore);
                }
            }

            return candidates.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

        private static string Five()
        {
            string str = "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal";
            string key = "ICE";
            string known_result = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";

            str = str.StringToHex();
            key = key.StringToHex();
            string result = str.XOR(key).StringToHex();
            
            if (result == known_result)
                return result;
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
