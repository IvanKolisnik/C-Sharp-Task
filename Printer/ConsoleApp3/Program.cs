using System;
using System.Collections.Generic;
using System.Linq;

namespace PrinterPrint
{
    internal static class Program
    {
        private static readonly User[] _users = new[]
        {
            new User() {Name = "Vasya", Surname = "Osborn", Age = 29, NumberSheets = 35, Time = new TimeSpan(12, 52, 35), Priority = 15},
            new User() {Name = "Stas", Surname = "Petrov", Age = 28, NumberSheets = 78, Time = new TimeSpan(10, 24, 27), Priority = 25},
            new User() {Name = "Petro", Surname = "Ivanov", Age = 35, NumberSheets = 15, Time = new TimeSpan(12, 52, 35), Priority = 8},
        };

        private static void Main(string[] args)
        {
            foreach (var user in _users)
                Console.WriteLine($"{user}\n");

            Console.WriteLine("Send document to printer enter [y]:");
            if (Console.ReadLine() == "y")
            {
                var queue = new Queue<User>(_users.OrderByDescending(user => user.Priority));
                while (queue.Count != 0)
                {
                    foreach (var user in queue)
                        Console.WriteLine(user.Priority);
                    Console.WriteLine();
                    queue.Dequeue();
                }
            }
            else
            {
                Console.WriteLine("Error input!");
            }
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int NumberSheets { get; set; }
        public TimeSpan Time { get; set; }
        public int Priority { get; set; }

        public override string ToString()
        {
            return $"User\nName -> {Name}\nSurname -> {Surname}\nAge -> {Age}\nSent to printer -> {NumberSheets}\nTime -> {Time:hh\\:mm\\:ss}\nPriority -> {Priority}";
        }
    }
}