using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        var book = new TelephoneBook();
        book.Add(new Subscriber { Name = "Иванов", Phone = 1 });
        book.Add(new Subscriber { Name = "Иванова", Phone = 2 });
        book.Add(new Subscriber { Name = "Алла", Phone = 3 });
        book.Save("file.txt");
        book.Load("file.txt");
        book.Print("А", "Иванов");
        book[1] = new Subscriber { Name = "Петров", Phone = 2 };
        book.Remove("Петров");
    }
}

sealed class Subscriber
{
    public string Name { get; set; }
    public int Phone { get; set; }

    public override string ToString()
    {
        return $"{Name}: {Phone}";
    }
}

sealed class TelephoneBook
{
    private List<Subscriber> subscribers = new List<Subscriber>();

    public int Count => subscribers.Count;

    public Subscriber this[int index]
    {
        get => subscribers[index];
        set => subscribers[index] = value;
    }

    public void Add(Subscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Remove(string name = null, int? phone = null)
    {
        for (int i = subscribers.Count - 1; i >= 0; i--)
        {
            if (subscribers[i].Name == name || subscribers[i].Phone == phone)
            {
                subscribers.RemoveAt(i);
            }
        }
    }

    public Subscriber Find(string name = null, int? phone = null)
    {
        foreach (Subscriber subscriber in subscribers)
        {
            if (subscriber.Name == name || subscriber.Phone == phone)
            {
                return subscriber;
            }
        }

        return null;
    }

    public void Print(string fromName, string toName)
    {
        foreach (Subscriber subscriber in subscribers.OrderBy(x => x.Name))
        {
            if (string.CompareOrdinal(subscriber.Name, fromName) >= 0
                && string.CompareOrdinal(subscriber.Name, toName) <= 0)
            {
                Console.WriteLine(subscriber);
            }
        }
    }

    public void Print(int fromPhone, int toPhone)
    {
        foreach (Subscriber subscriber in subscribers.OrderBy(x => x.Name))
        {
            if (subscriber.Phone >= fromPhone && subscriber.Phone <= toPhone)
            {
                Console.WriteLine(subscriber);
            }
        }
    }

    public void Save(string file)
    {
        var buffer = new StringBuilder();
        foreach (Subscriber subscriber in subscribers)
        {
            buffer.AppendLine($"{subscriber.Name}|{subscriber.Phone}");
        }

        File.WriteAllText(file, buffer.ToString());
    }

    public void Load(string file)
    {
        subscribers = File.ReadAllLines(file)
            .Select(x => x.Split('|'))
            .Select(data => new Subscriber { Name = data[0], Phone = int.Parse(data[1]) })
            .ToList();
    }
}