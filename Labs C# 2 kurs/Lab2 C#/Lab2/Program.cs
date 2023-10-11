/*15) Елементи колекції «Товари» мають наступну структуру: код товару, назва товару (коди унікальні, назви можуть повторюватися), 
 * ціна одиниці товару. Елементи колекції «Поставки» містять код товару, дату поставки, обсяг поставки (кількість одиниць товару у поставці). 
 * а) Вивести без повторів назви товарів.
 * b) Вивести максимальний обсяг поставок товару із заданою назвою.
 * с) Вивести середні загальні вартості поставок товарів по кожному року (загальна вартість - це добуток ціни одиниці товару на обсяг поставки).*/

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Створення колекції товарів
        List<Goods> goods = new List<Goods>
        {
            new Goods { Code = 1, Name = "Товар1", Price = 10.0 },
            new Goods { Code = 2, Name = "Товар2", Price = 15.0 },
            new Goods { Code = 3, Name = "Товар1", Price = 12.0 },
        };

        // Створення колекції поставок
        List<Deliveries> postavky = new List<Deliveries>
        {
            new Deliveries { Code = 1, DateOfDel= new DateTime(2023, 1, 5), Scope = 100 },
            new Deliveries { Code = 2, DateOfDel = new DateTime(2023, 2, 10), Scope = 50 },
            new Deliveries { Code = 1, DateOfDel = new DateTime(2023, 3, 15), Scope = 75 },
        };

        // a) Вивести без повторів назви товарів.
        var unicName = goods.Select(t => t.Name).Distinct();
        Console.WriteLine("Без повторiв назви товарiв:");
        foreach (var name in unicName)
        {
            Console.WriteLine(name);
        }

        // b) Вивести максимальний обсяг поставок товару із заданою назвою.
        string thisName = "Товар1";
        var maxScope = postavky
            .Where(p => goods.Any(t => t.Code == p.Code && t.Name == thisName))

            .Max(p => p.Scope);
        Console.WriteLine($" Максимальний обсяг поставок товару '{thisName}': {maxScope}");

        // c) Вивести середні загальні вартості поставок товарів по кожному року.
        var averageSum = postavky
            .GroupBy(p => p.DateOfDel.Year)
            .Select(group => new
            {
                Rik = group.Key,
                averageSum = group.Sum(p => goods.First(t => t.Code == p.Code).Price * p.Scope) / group.Count()
            });

        Console.WriteLine(" Середнi загальнi вартостi поставок товарiв по кожному року:");
        foreach (var item in averageSum)
        {
            Console.WriteLine($"Рiк: {item.Rik}, Середня Вартiсть: {item.averageSum}");
        }
    }
}

class Goods
{
    public int Code { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Deliveries
{
    public int Code { get; set; }
    public DateTime DateOfDel { get; set; }
    public int Scope { get; set; }
}
