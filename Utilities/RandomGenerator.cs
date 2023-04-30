

namespace Finonex.Utilities
{
    public class RandomGenerator
    {
        public static string GenerateRandom(int length, string chars)
        {
            Random random = new Random();
            string randomString = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}
