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
            byte[] buff = File.ReadAllBytes("Assembly-CSharp.dll");
            byte key = 0x44;
            byte vi = 0xaa;
            byte[] encrypto = new byte[buff.Length];
            for (int i = 0; i < buff.Length;i++ )
            {
                if (i == 0) encrypto[i] = (byte)(key ^ vi ^ buff[i]);
                else encrypto[i] = (byte)(key ^ (byte)(~buff[i-1]) ^ buff[i]);
            }
            File.WriteAllBytes("Assembly-CSharpEN.dll", encrypto);
            
            buff = File.ReadAllBytes("GameCore.dll");
            key = 0x44;
            vi = 0xaa;
            encrypto = new byte[buff.Length];
            for (int i = 0; i < buff.Length; i++)
            {
                if (i == 0) encrypto[i] = (byte)(key ^ vi ^ buff[i]);
                else encrypto[i] = (byte)(key ^ (byte)(~buff[i - 1]) ^ buff[i]);
            }
            File.WriteAllBytes("GameCoreEN.dll", encrypto);
        }
    }
}
