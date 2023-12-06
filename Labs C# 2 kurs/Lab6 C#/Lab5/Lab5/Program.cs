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
using System.Data.SqlClient;

namespace Lab6
{
    class Program
    {
        public static void Main()
        {
            const string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MegaNotik\Desktop\Універ\Лабораторні роботи C#\Labs C# 2 kurs\Lab5 C#\Lab5\Lab5\SA2_Novikova.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                connection.Open();
                var rep = new BookRepository(connection);

                //Простий запит на вибірку
                Console.Write("Enter the name of author: ");
                string authorName = Console.ReadLine();
                var books = rep.GetBooks(authorName);
                Console.WriteLine("Books by author:");
                foreach (Book book in books )
                {
                    Console.WriteLine($"{book.Title}-{book.Price}-{book.BookstoreFirm}");
                }

                //Запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
                Console.Write("Enter minimal price: ");
                decimal minPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter maximum price: ");
                decimal maxPrice = Convert.ToDecimal(Console.ReadLine());
                books = rep.GetPrices(minPrice, maxPrice);
                if (books.Count == 0)
                {
                    Console.WriteLine("No books found in the specified price range.");
                }
                else
                {
                    Console.WriteLine("List of books:");
                    foreach (Book book in books)
                    {
                        Console.WriteLine($"{book.Title}-{book.Author}-{book.PublicationYear}-{book.AuthorAdress}-{book.PublisherAddress}-{book.Price}-{book.BookstoreFirm}");
                    }
                }

                //Запит зі складним критерієм;
                Console.Write("Enter year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter bookstore firm: ");
                string firm = Convert.ToString(Console.ReadLine());
                var books = rep.GetBooks1(year, firm);
                Console.WriteLine("List of books:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"{book.Title}-{book.Author}- {book.Price}");
                }

                //Запит з унікальними значеннями;
                Console.WriteLine("The List of authors:");
                string author = Console.ReadLine();
                var authors = rep.GetAuthors(author);
                foreach(var au in authors)
                {
                    Console.WriteLine(au.Author);
                }

                //Запит з використанням обчислювального поля
                decimal multiplier;

                Console.Write("Enter the price multiplier: ");

                while (!decimal.TryParse(Console.ReadLine(),
                    /*Використання System.Globalization.CultureInfo.InvariantCulture дозволяє ігнорувати локальні 
                     * налаштування та використовувати крапку як роздільник десяткових чисел. 
                     * Такий код буде працювати для введення чисел у форматі decimal незалежно від локальних налаштувань.*/
                System.Globalization.NumberStyles.AllowDecimalPoint,
                    System.Globalization.CultureInfo.InvariantCulture, out multiplier))
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                    Console.Write("Enter the price multiplier: ");
                }
                var prices = rep.GetNewPrice(multiplier);
                Console.WriteLine("New prices:");
                foreach (var p in prices)
                {
                    Console.WriteLine($"{p.Title} - {p.Price}");
                }

                //Запит з групуванням по заданому полю, використовуючи умову групування;
                Console.Write("Enter the firm: ");
                string firm = Console.ReadLine();
                int count = 0;

                var counts = rep.GetCount(firm);
                foreach (var item in counts)
                {
                    count++;
                    Console.WriteLine($"{item.BookstoreFirm}: {item.PublishingCount}");
                }

                if (count == 0)
                {
                    Console.WriteLine("No information found for the specified firm.");
                }

                //Запит із сортування по заданому полю в порядку зростання та спадання значень;
                var books = rep.GetReversed();
                Console.WriteLine("List of Books ordered by Publication Year (Descending):");
                foreach (Book book in books)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} - {book.PublicationYear}");
                }

                //Запит з використанням дій по модифікації записів
                Console.Write("Enter the new firm name: ");
                string newFirm = Console.ReadLine();
                Console.Write("Enter the old firm name: ");
                string oldFirm = Console.ReadLine();

                var list = rep.Modification(oldFirm, newFirm);
                Console.WriteLine("New list:");
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Title}-{item.Author}-{item.PublicationYear}-{item.AuthorAdress}-{item.PublisherAddress}-{item.Price}-{item.BookstoreFirm}");
                }
            }
            Console.WriteLine("");
        }
    }
}