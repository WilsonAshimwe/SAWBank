using SAWBank.BLL.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SAWBank.BLL.Infrastructures
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] Hash(string password)
        {
            return SHA512.HashData(Encoding.UTF8.GetBytes(password));

        }
    }
}