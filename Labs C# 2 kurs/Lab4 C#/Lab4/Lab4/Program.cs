/*Варіант 4.
Сформувати файл “Halereya.json”, що містить інформацію про дані з полями: код; прізвище
художника; назва картини; ціна; ознака: 1 – картина в експозиції; 2 – картина в запаснику; 3 – картина на “виїзді”.

 Переглянути файл на консолі;
 За кодом вивести на консоль прізвище художника, назву картини та її ціну.
 Обчислити сумарну ціну усіх картин, що містяться в запаснику.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Paint
{
    public int Code { get; set; }
    public string Surname { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public int Feature { get; set; }
}

class Program
{
    static void Main()
    {
        // Створення списку картин
        List<Paint> paints = new List<Paint>
        {
            new Paint { Code = 1, Surname = "Williams", Title = "Sunrise", Price = 567438, Feature = 2 },
            new Paint { Code = 2, Surname = "Smith", Title = "Apples", Price = 937284, Feature = 1 },
            new Paint { Code = 3, Surname = "Jameson", Title = "Sea", Price = 1648293, Feature = 1 },
            new Paint { Code = 4, Surname = "Atlas", Title = "Lady", Price = 6382904, Feature = 3 },
            new Paint { Code = 5, Surname = "Miller", Title = "Dance", Price = 2657313, Feature = 2 },
            new Paint { Code = 6, Surname = "Cora", Title = "Fantasy", Price = 5372812, Feature = 3 },
            new Paint { Code = 7, Surname = "Wilder", Title = "Magic", Price = 427184, Feature = 1 },
            new Paint { Code = 8, Surname = "Jones", Title = "Moves", Price = 184632, Feature = 3 },
            new Paint { Code = 9, Surname = "Watson", Title = "Night", Price = 748294, Feature = 2 }
        };

        // Запис у файл
        string jsonFile = JsonSerializer.Serialize(paints);
        File.WriteAllText("Halereya.json", jsonFile);

        // Читання файлу
        string readFromFile = File.ReadAllText("Halereya.json");
        List<Paint> paintsFromFile = JsonSerializer.Deserialize<List<Paint>>(readFromFile);

        // Вивід даних
        foreach (var p in paintsFromFile)
        {
            Console.WriteLine($"Код: {p.Code}, Прiзвище художника: {p.Surname}, Назва картини: {p.Title}, Цiна: {p.Price}, Ознака: {p.Feature}");
        }

        //За кодом вивести на консоль прізвище художника, назву картини та її ціну.
        Console.Write("Введiть код з клавiатури: ");
        int inputCode = int.Parse(Console.ReadLine());

        Paint selected = paintsFromFile.Find(p => p.Code== inputCode);
        if(selected != null)
        {
            Console.WriteLine($"Прiзвище художника: {selected.Surname}, Назва картини: {selected.Title}, Цiна: {selected.Price}");
        }
        else
        {
            Console.WriteLine("Картину з таким кодом не знайдено");
        }

        //Обчислити сумарну ціну усіх картин, що містяться в запаснику.
        int sum = 0;
        foreach (var paint in paintsFromFile)
        {
            if (paint.Feature == 2)
                sum += paint.Price;
        }
        Console.WriteLine($"Сума картин в запаснику: {sum} ");
    }
}

