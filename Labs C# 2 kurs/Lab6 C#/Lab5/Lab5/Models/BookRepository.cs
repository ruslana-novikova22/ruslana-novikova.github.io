using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab5.Models
{
    internal class BookRepository : IRepository<Book>
    {
        protected SqlConnection _connection;
        public BookRepository(SqlConnection connection)
        {
            _connection=connection;
        }

        public List<Book> GetBooks(string author)
        {
            var books = new List<Book>();
            string query = $"SELECT Library.Title, Library.Price, Library.BookstoreFirm FROM Library WHERE TRIM(Library.Author) = '{author}';";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Title = Convert.ToString(reader["Title"]),
                        Price = Convert.ToInt32(reader["Price"]),
                        BookstoreFirm = Convert.ToString(reader["BookstoreFirm"])
                    };
                    books.Add(book);
                }
            }
            return books;
        }

        public List<Book> GetPrices(decimal minPrice, decimal maxPrice)
        {
            var books = new List<Book>();
            string query = $"SELECT * FROM Library WHERE Price BETWEEN '{minPrice}' AND '{maxPrice}';";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book b = new Book();

                        b.Title = Convert.ToString(reader["Title"]);
                        b.Author = Convert.ToString(reader["Author"]);
                        b.PublicationYear = Convert.ToInt32(reader["PublicationYear"]);
                        b.AuthorAdress = Convert.ToString(reader["AuthorAdress"]);
                        b.PublisherAddress = Convert.ToString(reader["PublisherAddress"]);
                        b.Price = Convert.ToDecimal(reader["Price"]);
                        b.BookstoreFirm = Convert.ToString(reader["BookstoreFirm"]);

                        books.Add(b);
                    }
                }
            }
            return books;
        }

        public List<Book> GetBooks1(int year, string firm)
        {
            var books = new List<Book>();
            string query = $"SELECT Library.Title, Library.Author, Library.Price FROM Library WHERE (PublicationYear > {year}) AND BookstoreFirm = '{firm}';";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book b = new Book();

                        b.Title = Convert.ToString(reader["Title"]);
                        b.Author = Convert.ToString(reader["Author"]);
                        b.Price = Convert.ToDecimal(reader["Price"]);

                        books.Add(b);
                    }
                }
            }
            return books;
        }

        public List<Book> GetAuthors(string author)
        {
            var books = new List<Book>();
            string query = $"SELECT DISTINCT Author FROM Library";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book b = new Book();

                        b.Author = Convert.ToString(reader["Author"]);

                        books.Add(b);
                    }
                }
            }
            return books;
        }

        public List<Book> GetNewPrice(string multiplier)
        {
            var books = new List<Book>();
            string query = $"UPDATE Library SET Price = Library.Price * '{multiplier}';";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
            string newQuery = "SELECT * FROM Library;";
            var updatedPrices = new List<Book>();

            using (SqlCommand selectCommand = new SqlCommand(newQuery, _connection))
            {
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Title = Convert.ToString(reader["Title"]),
                            Price = Convert.ToDecimal(reader["Price"])
                        };
                        updatedPrices.Add(book);
                    }
                }
            }
            return updatedPrices;
        }
        public List<Book> GetCount(string firm)
        {
            var books = new List<Book>();
            string query = $"SELECT COUNT(*) AS PublishingCount, BookstoreFirm FROM Library WHERE BookstoreFirm = '{firm}' GROUP BY BookstoreFirm HAVING COUNT(*) > 2; ";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book b = new Book();
                        {
                            b.BookstoreFirm = Convert.ToString(reader["BookstoreFirm"]);
                            b.PublishingCount = Convert.ToInt32(reader["PublishingCount"]);
                        };
                        books.Add(b);
                    }
                }
            }
            return books;
        }

        public List<Book> GetReversed()
        {
            var books = new List<Book>();
            string query = $"SELECT Library.Title, Library.Author, Library.PublicationYear FROM Library ORDER BY Library.PublicationYear;";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book b = new Book();

                        b.Title = Convert.ToString(reader["Title"]);
                        b.Author = Convert.ToString(reader["Author"]);
                        b.PublicationYear = Convert.ToInt32(reader["PublicationYear"]);

                        books.Add(b);
                    }
                }
            }
            return books;
        }

        public List<Book> Modification(string oldFirm, string newFirm)
        {
            var books = new List<Book>();
            string query = $"UPDATE Library SET BookstoreFirm = '{newFirm}' WHERE BookstoreFirm = '{oldFirm}';";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
            string newQuery = "SELECT * FROM Library;";
            var updatedBooks = new List<Book>();

            using (SqlCommand selectCommand = new SqlCommand(newQuery, _connection))
            {
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Title = Convert.ToString(reader["Title"]),
                            PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                            PublisherAddress = Convert.ToString(reader["PublisherAddress"]),
                            BookstoreFirm = Convert.ToString(reader["BookstoreFirm"])
                        };

                        updatedBooks.Add(book);

                    }                    
                }
            }

            return updatedBooks;
        }
    }
}
