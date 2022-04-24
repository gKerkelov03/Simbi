using System.Security.Cryptography;
using System.Text;

namespace Simbi.Common;

public class UtilityMethods
{
    private static readonly SHA256 sha = SHA256.Create();

    public static string Hash(string password) => string.Join("", sha.ComputeHash(Encoding.UTF8.GetBytes(password)));    
}
