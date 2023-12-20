/*Варіант 22.
Створити таблицю БД “Kadry”, що містить інформацію про дані з полями: код, прізвище; цех; посада; стать;
стаж; заробітна плата.
 Вивести дані у консоль;
 За кодом Х вивести прізвище, посаду, стаж та заробітну плату працівника.
 Обчислити середню заробітну плату працівників-жінок цеху Х.*/

using Modul2.Modules;
using System.Data.SqlClient;
using static Modul2.Modules.Kadries;

namespace Lab6
{
    class Program
    {
        public static void Main()
        {
            const string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MegaNotik\Desktop\Універ\Лабораторні роботи C#\Labs C# 2 kurs\Модуль-2\Modul2\Modul2\Kadries.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                connection.Open();
                var rep = new KadryRepository(connection);

                // Вивести дані у консоль
                var kadry = rep.GetAll();
                Console.WriteLine("All kadry:");
                foreach (Kadry kadry1 in kadry)
                {
                    Console.WriteLine($"{kadry1.Id} -- {kadry1.Surname} -- {kadry1.Department} -- {kadry1.Job} -- {kadry1.Salary}");
                }

                //За кодом Х вивести прізвище, посаду, стаж та заробітну плату працівника.

                Console.Write("Введіть код користувача: ");
                string id = Console.ReadLine();
                var kadries = rep.GetById(id);
                foreach(Kadry kadry2 in kadries)
                {
                    Console.WriteLine($"{kadry2.Surname} -- {kadry2.Job} -- {kadry2.Experience} -- {kadry2.Salary}");
                }

                //Обчислити середню заробітну плату працівників-жінок цеху Х.
                Console.Write("Введіть цех: ");
                string department = Console.ReadLine();
                decimal averageSalary = rep.GetAverageSalaryForWomen(department);
                Console.WriteLine($"Середня заробітна плата жінок у цеху {department}: {averageSalary:C}");


            }
        }
    }
}