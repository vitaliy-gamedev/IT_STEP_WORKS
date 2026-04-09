using System;
using System.Linq;
using System.Collections.Generic;

public static class AlbumReports
{
    public static void ByArtist(List<Album> a) =>
        (from x in a group x by x.Artist)
        .ToList()
        .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));

    public static void ByYear(List<Album> a) =>
        (from x in a orderby x.Year select x)
        .ToList()
        .ForEach(x => Console.WriteLine($"{x.Title} - {x.Year}"));

    public static void ByStudio(List<Album> a) =>
        (from x in a group x by x.Studio)
        .ToList()
        .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));

    public static void ByDuration(List<Album> a) =>
        (from x in a orderby x.Duration descending select x)
        .ToList()
        .ForEach(x => Console.WriteLine($"{x.Title} - {x.Duration}"));
}