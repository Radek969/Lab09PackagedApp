using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class AnalizatorLogow
{
    [GeneratedRegex(@"\b(?:\d{1,3}\.){3}\d{1,3}\b")]
    private static partial Regex RegexIp();

    [GeneratedRegex(
        @"(?<typ>brute-force|SQL injection|Port scan|DDoS)",
        RegexOptions.IgnoreCase)]
    private static partial Regex RegexAtak();

    private static readonly SearchValues<char> _znakiSpecjalne =
        SearchValues.Create("!@#$%^&*()[]{}<>?/\\|");

    public static List<string> WydobadzAdresyIp(string tekst)
    {
        var wynik = new List<string>();

        foreach (Match m in RegexIp().Matches(tekst))
        {
            wynik.Add(m.Groups[0].Value);
        }

        return wynik;
    }

    public static int ZliczZnakiSpecjalne(
        ReadOnlySpan<char> tekst)
    {
        int licznik = 0;
        var reszta = tekst;

        while (true)
        {
            int idx = reszta.IndexOfAny(_znakiSpecjalne);

            if (idx < 0)
                break;

            licznik++;
            reszta = reszta[(idx + 1)..];
        }

        return licznik;
    }

    public static List<string> WykryjTypyAtakow(string tekst)
    {
        var wynik = new List<string>();

        foreach (Match m in RegexAtak().Matches(tekst))
        {
            wynik.Add(m.Groups["typ"].Value);
        }

        return wynik;
    }
}

public static class ParserBezAlokacji
{
    public static bool CzyPodejrzanaLinia(
        ReadOnlySpan<char> linia,
        int progZnakoSpecjalnych = 3)
    {
        int znakiSpec =
            AnalizatorLogow.ZliczZnakiSpecjalne(linia);

        return znakiSpec >= progZnakoSpecjalnych;
    }

    public static int PoliczPoziomie(
        ReadOnlySpan<char> logi,
        ReadOnlySpan<char> poziom)
    {
        int licznik = 0;

        while (!logi.IsEmpty)
        {
            int koniec = logi.IndexOf('\n');

            ReadOnlySpan<char> linia =
                koniec >= 0
                    ? logi[..koniec]
                    : logi;

            if (linia.Contains(
                poziom,
                StringComparison.OrdinalIgnoreCase))
            {
                licznik++;
            }

            if (koniec < 0)
                break;

            logi = logi[(koniec + 1)..];
        }

        return licznik;
    }
}