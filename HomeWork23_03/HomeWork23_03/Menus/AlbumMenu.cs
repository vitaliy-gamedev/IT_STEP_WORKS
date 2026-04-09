using System;
using System.Linq;

public class AlbumMenu
{
    AlbumService s;
    FileService f;

    public AlbumMenu(AlbumService s, FileService f)
    {
        this.s = s;
        this.f = f;
    }

    public void Run()
    {
        s.Data = f.Load<Album>("albums.json");

        while (true)
        {
            try
            {
                Console.WriteLine("\n1 Додати альбом");
                Console.WriteLine("2 Додати пісню");
                Console.WriteLine("3 Видалити альбом");
                Console.WriteLine("4 Пошук");
                Console.WriteLine("5 Зберегти");
                Console.WriteLine("6 Звіти");
                Console.WriteLine("0 Назад");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Назва: ");
                        string title = Console.ReadLine();

                        Console.Write("Артист: ");
                        string artist = Console.ReadLine();

                        Console.Write("Рік: ");
                        int year = int.Parse(Console.ReadLine());

                        Console.Write("Тривалість: ");
                        double dur = double.Parse(Console.ReadLine());

                        Console.Write("Студія: ");
                        string studio = Console.ReadLine();

                        s.Add(new Album(id, title, new(), artist, year, dur, studio));
                        break;

                    case "2":
                        Console.Write("Id альбому: ");
                        int aid = int.Parse(Console.ReadLine());

                        Console.Write("Пісня: ");
                        string st = Console.ReadLine();

                        Console.Write("Тривалість: ");
                        double sd = double.Parse(Console.ReadLine());

                        Console.Write("Шлях до тексту: ");
                        string path = Console.ReadLine();

                        s.AddSong(aid, new Song(st, sd, path));
                        break;

                    case "3":
                        Console.Write("Id: ");
                        s.Remove(int.Parse(Console.ReadLine()));
                        break;

                    case "4":
                        Console.Write("Пошук: ");
                        var q = Console.ReadLine();

                        foreach (var a in s.Search(q))
                            Console.WriteLine(a.Title);
                        break;

                    case "5":
                        f.Save("albums.json", s.Data);
                        break;

                    case "6":
                        Console.WriteLine("1 Artist 2 Year 3 Studio 4 Duration");
                        switch (Console.ReadLine())
                        {
                            case "1": AlbumReports.ByArtist(s.Data); break;
                            case "2": AlbumReports.ByYear(s.Data); break;
                            case "3": AlbumReports.ByStudio(s.Data); break;
                            case "4": AlbumReports.ByDuration(s.Data); break;
                        }
                        break;

                    case "0":
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Помилка вводу!");
            }
        }
    }
}