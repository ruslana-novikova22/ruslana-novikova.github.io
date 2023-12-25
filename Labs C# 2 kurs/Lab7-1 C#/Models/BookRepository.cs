using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.SqlServer;


namespace Lab7.Models
{
    internal class BookRepository
    {
        protected AppDbcontext _dbcontext;
        public BookRepository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Простий запит на вибірку
        public List<Book> GetBooksByAuthor(string authorName)
        {
            return _dbcontext.Library
                .AsEnumerable()
                .Where(library => library.Author.ToLower().Contains(authorName.ToLower()))
                .ToList();
        }

        //Запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
        public List<Book> GetBooksByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _dbcontext.Library
                .Where(book => book.Price >= minPrice && book.Price <= maxPrice)
                .ToList();
        }

        //Запит зі складним критерієм;
        public List<Book> GetBooks(int year, string firm)
        {
            return _dbcontext.Library
                .Where(book => book.PublicationYear >= year && book.BookstoreFirm == firm)
                .ToList();
        }

        //Запит з унікальними значеннями;
        public List<string> GetAuthors()
        {
            return _dbcontext.Library
                .Select(book => book.Author)
                .Distinct()
                .ToList();
        }

        //Запит з використанням обчислювального поля;
        public List<Book> UpdatePrices(decimal multiplier)
        {
            var books = _dbcontext.Library.ToList();

            foreach (var book in books)
            {
                book.Price *= multiplier;
            }

            _dbcontext.SaveChanges();

            return _dbcontext.Library.ToList();
        }

        //Запит з групуванням по заданому полю, використовуючи умову групування;
        public List<Book> GetCount(string firm)
        {
            var booksWithCount = _dbcontext.Library
                .Where(book => book.BookstoreFirm == firm)
                .GroupBy(book => book.BookstoreFirm)
                .Where(group => group.Count() > 2)
                .Select(group => new Book
                {
                    BookstoreFirm = group.Key,
                    PublishingCount = group.Count()
                })
                .ToList();

            return booksWithCount;
        }

        //Запит із сортування по заданому полю в порядку зростання та спадання значень;
        public List<Book> GetReversed()
        {
            var books = _dbcontext.Library
                .OrderBy(book => book.PublicationYear)
                .Select(book => new Book
                {
                    Title = book.Title,
                    Author = book.Author,
                    PublicationYear = book.PublicationYear
                })
                .ToList();

            return books;
        }

        //Запит з використанням дій по модифікації записів.
        public List<Book> Modification(string oldFirm, string newFirm)
        {
            // Оновіть дані у базі даних за допомогою LINQ
            _dbcontext.Library
                .Where(book => book.BookstoreFirm == oldFirm)
                .ToList()
                .ForEach(book => book.BookstoreFirm = newFirm);

            _dbcontext.SaveChanges(); // Збережіть зміни у базі даних

            // Отримайте оновлені дані з бази даних
            var updatedBooks = _dbcontext.Library
                .Where(book => book.BookstoreFirm == newFirm)
                .Select(book => new Book
                {
                    Title = book.Title,
                    PublicationYear = book.PublicationYear,
                    BookstoreFirm = book.BookstoreFirm
                })
                .ToList();

            return updatedBooks;
        }



    }
}
