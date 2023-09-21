using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task2
    {
        //Дано чергу цілих чисел, яка складається з n елементів.
        //Визначити середнє арифметичне значення елементів черги,
        //кратних восьми.Якщо таких елементів немає, вивести
        //повідомлення: «Елементів кратних 8 в черзі немає».

        static void Main()
        {
            const int n = 50;
            Queue<int> queue = new Queue<int>();
            Random randit = new Random();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(randit.Next(100));
            }
            int sum = 0;
            int count = 0;
            int average = 0;
            Console.Write("Queue: ");
            foreach (int a in queue)
            {
                Console.Write("{0}; ", a);
                if (a % 8 == 0)
                {
                    count++;
                    sum += a;
                    average = sum/count;

                }
            }
            Console.WriteLine();
            if (count == 0)
            {
                Console.WriteLine("Чисел, що кратні 8, у списку немає");
            }
            else
            {
                Console.WriteLine("Count: {0}\n Sum: {1}\n Average: {2}", count, sum, average);
            }
            Console.ReadKey();
        }
    }
}

