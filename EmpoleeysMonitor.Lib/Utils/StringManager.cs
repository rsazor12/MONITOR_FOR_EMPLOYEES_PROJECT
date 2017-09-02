using System.Security.Cryptography;
using System.Text;

namespace EmployeesMonitor.Lib
{
    static class StringManager
    {
        public static string GetHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            StringBuilder hashString = new StringBuilder(string.Empty);
            foreach (byte x in hash)
            {
                hashString.Append(string.Format("{0:x2}", x));
            }
            return hashString.ToString();
        }
    }
}