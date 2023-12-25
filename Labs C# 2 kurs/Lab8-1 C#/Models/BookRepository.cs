using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Models
{
    internal class BookRepository
    {
        protected AppDbcontext _dbcontext;

        public BookRepository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Book>> GetBooksByAuthorAsync(string authorName)
        {
            return await _dbcontext.Library
                .Where(library => library.Author.ToLower().Contains(authorName.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbcontext.Library
                .Where(book => book.Price >= minPrice && book.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksAsync(int year, string firm)
        {
            return await _dbcontext.Library
                .Where(book => book.PublicationYear >= year && book.BookstoreFirm == firm)
                .ToListAsync();
        }

        public async Task<List<string>> GetAuthorsAsync()
        {
            return await _dbcontext.Library
                .Select(book => book.Author)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Book>> UpdatePricesAsync(decimal multiplier)
        {
            var books = await _dbcontext.Library.ToListAsync();

            foreach (var book in books)
            {
                book.Price *= multiplier;
            }

            await _dbcontext.SaveChangesAsync();

            return await _dbcontext.Library.ToListAsync();
        }

        public async Task<List<Book>> GetCountAsync(string firm)
        {
            var booksWithCount = await _dbcontext.Library
                .Where(book => book.BookstoreFirm == firm)
                .GroupBy(book => book.BookstoreFirm)
                .Where(group => group.Count() > 2)
                .Select(group => new Book
                {
                    BookstoreFirm = group.Key,
                    PublishingCount = group.Count()
                })
                .ToListAsync();

            return booksWithCount;
        }

        public async Task<List<Book>> GetReversedAsync()
        {
            var books = await _dbcontext.Library
                .OrderBy(book => book.PublicationYear)
                .Select(book => new Book
                {
                    Title = book.Title,
                    Author = book.Author,
                    PublicationYear = book.PublicationYear
                })
                .ToListAsync();

            return books;
        }

        public async Task<List<Book>> ModificationAsync(string oldFirm, string newFirm)
        {
            _dbcontext.Library
                .Where(book => book.BookstoreFirm == oldFirm)
                .ToList()
                .ForEach(book => book.BookstoreFirm = newFirm);

            await _dbcontext.SaveChangesAsync();

            var updatedBooks = await _dbcontext.Library
                .Where(book => book.BookstoreFirm == newFirm)
                .Select(book => new Book
                {
                    Title = book.Title,
                    PublicationYear = book.PublicationYear,
                    BookstoreFirm = book.BookstoreFirm
                })
                .ToListAsync();

            return updatedBooks;
        }
    }
}
