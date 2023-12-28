using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.SqlServer;

namespace Lab5.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
        public string? AuthorAdress { get; set; }
        public string? PublisherAddress { get; set; }
        public decimal Price { get; set; }
        public string? BookstoreFirm { get; set; }

        [NotMapped] 
        public int PublishingCount { get; set; }
    }
}
