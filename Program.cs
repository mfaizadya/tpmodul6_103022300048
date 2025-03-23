// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul video tidak valid");
        }
        this.title = title;
        this.id = GenerateRandomId();
        this.playCount = 0;
    }

    private int GenerateRandomId()
    {
        Random random = new Random();
        return random.Next(10000, 99999); 
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count >= 0, "Jumlah penambahan play count tidak boleh negatif");
        Debug.Assert(count <= 10000000, "Jumlah penambahan play count tidak boleh lebih dari 10.000.000");
        this.playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – MUHAMMAD FAIZ ADYA");
            video.IncreasePlayCount(1000);
            video.PrintVideoDetails();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
