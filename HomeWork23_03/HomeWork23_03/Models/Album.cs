using System.Collections.Generic;

public record Album(
    int Id,
    string Title,
    List<Song> Songs,
    string Artist,
    int Year,
    double Duration,
    string Studio
);