using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainApp.Code
{
    internal class Block
    {
        internal int Index { get; set; }
        internal DateTime Timestamp { get; set; }
        internal string Hash { get; set; } = string.Empty;
        internal string Data { get; set; } = string.Empty;
        internal string PreviousHash { get; set; } = string.Empty;
        internal int Nonce { get; set; }

        internal Block(int index, DateTime timestamp, string data, string previousHash)
        {
            Index = index;
            Timestamp = timestamp;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        internal string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{Index}-{Timestamp}-{Data}-{PreviousHash}-{Nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        internal void MineBlock(int difficulty)
        {
            string leadingZeros = new string('0', difficulty);

            while (Hash.Substring(0, difficulty) != leadingZeros)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
