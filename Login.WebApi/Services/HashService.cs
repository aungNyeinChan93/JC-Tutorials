using Effortless.Net.Encryption;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Login.WebApi.Services
{
    public class HashService
    {
        private byte[] Key = Encoding.UTF8.GetBytes("SGVsbG8gV29ybGQhSGVsbG8gV29ybGQh");
        private byte[] Iv = Encoding.UTF8.GetBytes("SGVsbG8gV29ybGQh");

        public string Encrypt(string value)
        {
            return Strings.Encrypt(value,Key,Iv);
        }

        public string Decrypt(string value) 
        {
            return Strings.Decrypt(value,Key,Iv);
        }
    }
}
