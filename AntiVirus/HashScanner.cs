using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AntiVirus
{
    public class HashScanner
    {
        private string file;
        public HashScanner(string file)
        {
            this.file = file;
        }
        public string MD5
        { 
            get 
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    using (var stream = File.OpenRead(file))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }  
        }
        public string SHA256
        {
            get
            {
                using (var SHA256 = SHA256Managed.Create())
                {
                    using (FileStream fileStream = File.OpenRead(file))
                        return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
                }
            }
        }
    }
}
