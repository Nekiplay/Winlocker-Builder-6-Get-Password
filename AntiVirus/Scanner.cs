using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AntiVirus
{
    public class AntiVirus_Utils
    {
        public byte[] GetFileBytes(string file)
        {
            return File.ReadAllBytes(file);
        }
        public string GetBytesText(byte[] bytes)
        {
            string text = Encoding.Default.GetString(bytes);
            return text;
        }
        public string GetBytesHex(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes).Replace("-", string.Empty);
            return hex;
        }
        public string GetBytesBase64(byte[] bytes)
        {
            string hex = Convert.ToBase64String(bytes);
            return hex;
        }
    }
}
