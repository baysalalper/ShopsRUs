namespace Core.UnitTest.Helpers;

public static class TestHelper
{
    private const string Chars = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789";
    private static readonly Random Random = new Random();
    public static string RandomString(int length = 10)
    {
        return new string(Enumerable.Repeat(Chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static int RandomInteger(int min = 0, int max = 999)
    {
        return Random.Next(min, max);
    }
}