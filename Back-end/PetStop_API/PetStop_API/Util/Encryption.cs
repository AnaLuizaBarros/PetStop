using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetStop_API.Util
{
    public static class Encryption
    {
        public static string GerarHashMd5(string input)
        {
            StringBuilder sBuilder = new();
            foreach(byte b in MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input)))
                sBuilder.Append(b.ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
