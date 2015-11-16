using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buff = File.ReadAllBytes("GameCoreEn.dll");
            byte key = 0x44;
            byte vi = 0xaa;
            byte[] decrypto = new byte[buff.Length];
            for (int i = 0; i < buff.Length; i++)
            {
                if (i == 0) buff[i] = (byte)(key ^ vi ^ buff[i]);
                else buff[i] = (byte)(key ^ (byte)(~buff[i - 1]) ^ buff[i]);
            }
            File.WriteAllBytes("GameCore.dll", buff);
        }
    }
}
