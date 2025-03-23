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
        Debug.Assert(!string.IsNullOrEmpty(title), "Judul video tidak boleh null atau kosong");
        Debug.Assert(title.Length <= 100, "Judul video tidak boleh lebih dari 100 karakter");
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
        Debug.Assert(count <= 10000000, "Input penambahan play count tidak boleh lebih dari 10.000.000");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Terjadi overflow pada penambahan play count: " + ex.Message);
        }
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

            for (int i = 0; i < 100; i++)
            {
                video.IncreasePlayCount(10000000); 
            }
        
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
