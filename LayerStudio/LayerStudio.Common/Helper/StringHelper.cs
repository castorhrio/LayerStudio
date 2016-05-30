using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LayerStudio.Common.Helper
{
    public class StringHelper
    {
        //mysql不支持guid
        public static string ConvertGuid()
        {
           return Guid.NewGuid().ToString("B");
        }

        //Md5加密
        public static string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2.ToUpper();
        }
    }
}
