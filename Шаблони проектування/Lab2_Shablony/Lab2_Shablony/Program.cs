/*Варіант 4. Розробити систему опрацювання замовлень доставки їжі додому.
Врахувати що замовлення може складатись із:
a. Фастфуду.
b. Суші
c. Традиційної української кухні
Кожен тип їж має власні системи замовлення.
Нехай потрібно замовити 3 порції їжі з ІD 123, 1 порцію з ІD 500 та 2 порції з ІD 42.
а. для замовлення фастфуду вказується список, який складається з пар Код страви та кількість. [[123, 3], [500,1], [42,2]]
b. для замовлення суші вказуються два списки: в першому коди, в другому – кількість [123, 500, 42], [3, 1, 2]
c. для замовлення Традиційної української кухні вказується послідовність кодів страви. Код повторюється стільки разів, яку кількість необхідно замовити [123, 123, 123, 500, 42, 42]
Система повинна надати єдиний інтерфейс замовлення: вибір типу їжі (a, b чи с) та список пар [кількість, код страви]*/

using System;
using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

class FastFood
{
    public void PlaceOrder(List<int[]> foodList)
    {
        Console.WriteLine("Замовлення фастфуду:");
        foreach (var food in foodList)
        {
            Console.WriteLine($"Кількість: {food[0]}, Код страви: {food[1]}");
        }
    }
}

class Sushi
{
    public void PlaceOrder(List<int> Codes, List<int> quantity)
    {
        Console.WriteLine("Замовлення сушi:");
        for(int i = 0; i < Codes.Count; i++)
        {
            Console.WriteLine($"Кількість: {quantity[i]}, Код страви: {Codes[i]}");
        }
    }
}

class UkrainianFood
{
    public void PlaceOrder(List<int> codes)
    {
        var sets = new List<int>(codes);
        Console.WriteLine("Замовлення української кухнi");
        foreach (var element in sets)
        {
            var quantity = codes.Count(item => item == element);
            Console.WriteLine($"Id: {element}, Quantity: {quantity}");
        }
    }
}

class FoodDeliveryFacade
{
    private FastFood fastFood;
    private Sushi sushi;
    private UkrainianFood ukrainianFood;

    public FoodDeliveryFacade()
    {
        fastFood = new FastFood();
        sushi = new Sushi();
        ukrainianFood= new UkrainianFood();
    }
    public void PlaceOrder(char type, List<int[]> details)
    {
        switch (type)
        {
            case 'a':
                fastFood.PlaceOrder(details);
                break;

            case 'b':
                var codes = new List<int>();
                var quantities = new List<int>();
                foreach (var order in details)
                {
                    codes.Add(order[1]);
                    quantities.Add(order[0]);
                }
                sushi.PlaceOrder(codes, quantities);
                break;

            case 'c':
                var ukrainianOrders = new List<int>();
                foreach (var order in details)
                {
                    int code = order[1];
                    int quantity = order[0];
                    for (int i = 0; i < quantity; i++)
                    {
                        ukrainianOrders.Add(code);
                    }
                }
                ukrainianFood.PlaceOrder(ukrainianOrders);
                break;
            default:
                Console.WriteLine("Непiдтримуваний тип їжi або некоректнi данi.");
                break;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var facade = new FoodDeliveryFacade();

        Console.WriteLine("Оберiть тип їжi (фастфуд - 'a', сушi - 'b', українська кухня - 'c'): ");
        char foodType = Console.ReadKey().KeyChar;

        List<int[]> foodList = new List<int[]>();

        switch (foodType)
        {
            case 'a':
                foodList = new List<int[]>
                {
                    new int[] { 3, 123 },
                    new int[] { 1, 500 },
                    new int[] { 2, 42 }
                };
                break;
            case 'b':
                foodList = new List<int[]>
                {
                    new int[] { 4, 200 },
                    new int[] { 5, 300 },
                    new int[] { 6, 150 }
                };
                break;
            case 'c':
                foodList = new List<int[]>
                {
                    new int[] { 7, 50 },
                    new int[] { 8, 75 },
                    new int[] { 9, 100 }
                };
                break;
            default:
                Console.WriteLine("Непiдтримуваний тип їжi або некоректнi данi.");
                return;
        }

        facade.PlaceOrder(foodType, foodList);
    }
}





