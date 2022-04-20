using HashidsNet;

namespace Catalog.Core.Services
{
    internal static class TenantHelper
    {
        public static string GenerateHashedCode()
        {
            var hashed = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            hashed = hashed.Replace("=", "");
            hashed = hashed.Replace("+", "");
            var sequence = hashed.GetHashCode();
            if (sequence < 0)
                sequence *= -1;
            var hashId = new Hashids("b14ca5898a4e4133bbce2ea2315a1916");
            return hashId.Encode(sequence);
        }
    }
}
