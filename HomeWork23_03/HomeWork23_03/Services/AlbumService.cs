using System.Collections.Generic;
using System.Linq;

public class AlbumService : IService<Album>
{
    public List<Album> Data { get; set; } = new();

    // Отримати всі
    public List<Album> GetAll() => Data;

    // Додати альбом
    public void Add(Album a) => Data.Add(a);

    // Видалити альбом
    public void Remove(int id) =>
        Data.RemoveAll(a => a.Id == id);

    // Додати пісню
    public void AddSong(int albumId, Song s) =>
        Data.FirstOrDefault(a => a.Id == albumId)?.Songs.Add(s);

    // Видалити пісню
    public void RemoveSong(int albumId, string title) =>
        Data.FirstOrDefault(a => a.Id == albumId)?.Songs.RemoveAll(s => s.Title == title);

    // Оновити альбом
    public void Update(int id, string newTitle)
    {
        var a = Data.FirstOrDefault(x => x.Id == id);
        if (a != null)
            Data[Data.IndexOf(a)] = a with { Title = newTitle };
    }

    // Пошук (по всім основним полям)
    public IEnumerable<Album> Search(string q) =>
        from a in Data
        where a.Title.Contains(q)
           || a.Artist.Contains(q)
           || a.Studio.Contains(q)
        select a;
}