using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Models;
using Lab9.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace WebApplication1.Models
{
    internal class BookRepository
    {
        protected AppDbContext _dbcontext;
        public BookRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<Book> Create(Book value)
        {
            var Book = await _dbcontext.AddAsync(value);
            await _dbcontext.SaveChangesAsync();
            return Book.Entity;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _dbcontext.Library.ToListAsync();
        }
        public async Task<Book?> GetById(int id)
        {
            var Book = await _dbcontext.Library.FindAsync(id);
            return Book;
        }
        public async Task<Book?> Delete(int id)
        {
            var Book = await _dbcontext.Library.FindAsync(id);
            if (Book == null)
            {
                return null;
            }
            _dbcontext.Library.Remove(Book);
            await _dbcontext.SaveChangesAsync();
            return Book;
        }
        public async Task<Book?> Update(int id, Book value)
        {
            var Book = await _dbcontext.Library.FindAsync(id);
            if (Book == null)
            {
                return null;
            }
            Book.Title = value.Title;
            Book.Author = value.Author;
            Book.PublicationYear = value.PublicationYear;
            Book.AuthorAdress = value.AuthorAdress;
            Book.PublisherAddress = value.PublisherAddress;
            Book.Price = value.Price;
            Book.BookstoreFirm = value.BookstoreFirm;
            _dbcontext.Library.Entry(Book).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return Book;
        }
    }
}
