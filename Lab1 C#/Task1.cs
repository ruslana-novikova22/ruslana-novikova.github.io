using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task1
    {
        //Stack. Назви типів даних мови C#. 10 елементів. Додати
        //зазначену кількість елементів, які описують відповідну предметну
        //область.Вивести всі елементи на консоль в прямому та зворотному
        //порядку.Вивести кількість елементів у колекції. Очистити колекцію.

        static Stack<string> GetStack()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("byte");
            stack.Push("int");
            stack.Push("float");
            stack.Push("bool");
            stack.Push("double");
            stack.Push("char");
            stack.Push("string");
            stack.Push("long");
            stack.Push("decimal");
            stack.Push("short");
            return stack;
        }

        static void Main()
        {
            var stack = GetStack();
            var reversed = new Stack<string>(stack);
            Console.WriteLine("----Stack contents----");

            foreach (string type in stack)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine("Reversed stack: ");
            while (reversed.Count != 0)
            {
                Console.WriteLine(reversed.Pop());
            }

            Console.WriteLine("Total element:");
            Console.WriteLine(stack.Count);

            stack.Clear();
            Console.WriteLine("Total element:");
            Console.WriteLine(stack.Count);
        }
    }
}
