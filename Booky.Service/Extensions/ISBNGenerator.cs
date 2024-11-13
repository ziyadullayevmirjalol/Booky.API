namespace Booky.Service.Extensions;

public static class ISBNGenerator
{
    public static string GenerateISBN13()
    {
        Random random = new Random();
        int[] isbn = Enumerable.Range(0, 12).Select(_ => random.Next(0, 10)).ToArray();

        int checkDigit = 10 - (isbn.Select((d, i) => d * (i % 2 == 0 ? 1 : 3)).Sum() % 10);
        checkDigit = checkDigit == 10 ? 0 : checkDigit;

        return string.Concat(isbn) + checkDigit;
    }
}


