/*Варіант 4. Створити таблицю бази даних про книги, які були куплені бібліотекою: назва, автор, рік видання,
адреса автора, адреса видавництва, ціна, книготорговельна фірма.

Використовуючи SqlCommand підготувати програмну оболонку для виконання завдань лабораторної роботи 5. 
Забезпечити користувачу можливість ввести значення параметрів запиту.

. Cтворити наступні види SQL-запитів:
a) простий запит на вибірку;
b) запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
c) запит зі складним критерієм;
d) запит з унікальними значеннями;
e) запит з використанням обчислювального поля;
f) запит з групуванням по заданому полю, використовуючи умову групування;
g) запит із сортування по заданому полю в порядку зростання та спадання значень;
h) запит з використанням дій по модифікації записів.*/

using Lab5.Models;
using Lab7.Models;
using System.Data.SqlClient;

namespace Lab6
{
    class Program
    {
        public static void Main()
        {
            const string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MegaNotik\Desktop\Універ\Лабораторні роботи C#\Labs C# 2 kurs\Lab6 C#\Lab5\Lab5\SA2_Novikova.mdf;Integrated Security=True";
            using (var db = new AppDbcontext())
            {
                var rep = new BookRepository(db);

                Console.Write("Enter the name of the author: ");
                string authorName = Convert.ToString(Console.ReadLine());
                var books = rep.GetBooksByAuthor(authorName);
                Console.WriteLine("Books by the author:");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} -- {book.Price} -- {book.BookstoreFirm}");
                }


                Console.Write("Enter minimal price: ");
                decimal minPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter maximum price: ");
                decimal maxPrice = Convert.ToDecimal(Console.ReadLine());

                List<Book> bs = rep.GetBooksByPriceRange(minPrice, maxPrice);

                if (bs.Count == 0)
                {
                    Console.WriteLine("No books found in the specified price range.");
                }
                else
                {
                    Console.WriteLine("List of books:");
                    foreach (Book book in bs)
                    {
                        Console.WriteLine($"{book.Title} -- {book.Price}");
                    }
                }



                Console.Write("Enter the publication year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the BookFirm: ");
                string firm = Convert.ToString(Console.ReadLine());
                List<Book> books1 = rep.GetBooks(year, firm);
                foreach (var book in books1)
                {
                    Console.WriteLine($"{book.Title} -- {book.Author}");
                }

                List<string> authors = rep.GetAuthors();

                if (authors.Count == 0)
                {
                    Console.WriteLine("No authors found.");
                }
                else
                {
                    Console.WriteLine("List of authors:");
                    foreach (string author in authors)
                    {
                        Console.WriteLine(author);
                    }
                }

                Console.Write("Enter the price multiplier: ");
                decimal multiplier = Convert.ToDecimal(Console.ReadLine());

                List<Book> updatedPrices = rep.UpdatePrices(multiplier);

                Console.WriteLine("Updated prices:");
                foreach (Book book in updatedPrices)
                {
                    Console.WriteLine($"{book.Title} -- {book.Price}");
                }


                var repos = new BookRepository(db);
                Console.Write("Enter the bookstore firm: ");
                string firm1 = Console.ReadLine();

                List<Book> result = repos.GetCount(firm1);



                Console.WriteLine($"Bookstore firm: {result.FirstOrDefault()?.BookstoreFirm}");
                Console.WriteLine($"Publishing count: {result.FirstOrDefault()?.PublishingCount}");


                var reversed = rep.GetReversed();

                Console.WriteLine("Books in reversed order by Publication Year:");
                foreach (var book in reversed)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} - {book.PublicationYear}");
                }


                Console.Write("Enter the old bookstore firm: ");
                string oldFirm = Console.ReadLine();

                Console.Write("Enter the new bookstore firm: ");
                string newFirm = Console.ReadLine();

                List<Book> updatedBooks = rep.Modification(oldFirm, newFirm);

                Console.WriteLine("Updated books:");
                foreach (Book book in updatedBooks)
                {
                    Console.WriteLine($"{book.Title} -- {book.PublicationYear} -- {book.BookstoreFirm}");
                }
            }
            Console.WriteLine("");
        }
    }
}