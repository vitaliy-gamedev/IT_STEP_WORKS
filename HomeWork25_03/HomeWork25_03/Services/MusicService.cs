using System;
using NAudio.Wave;

public static class MusicService
{
    private static IWavePlayer waveOut;
    private static AudioFileReader audioFile;

    // Відтворює mp3 або wav всередині консолі
    public static void Play(string path)
    {
        Stop(); // зупиняємо попередній трек

        if (!System.IO.File.Exists(path))
        {
            Console.WriteLine($"Файл не знайдено: {path}");
            return;
        }

        try
        {
            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(path);
            waveOut.Init(audioFile);
            waveOut.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка відтворення музики: {ex.Message}");
        }
    }

    // Зупиняє музику
    public static void Stop()
    {
        try
        {
            waveOut?.Stop();
            audioFile?.Dispose();
            waveOut?.Dispose();
        }
        catch { }
        finally
        {
            waveOut = null;
            audioFile = null;
        }
    }
}