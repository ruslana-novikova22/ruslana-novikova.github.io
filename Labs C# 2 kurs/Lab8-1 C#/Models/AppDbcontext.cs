using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.SqlServer;

namespace Lab7.Models
{
    internal class AppDbcontext : DbContext
    {
        public AppDbcontext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Library { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Визначте первинний ключ для сутності Book
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MegaNotik\Desktop\Універ\Лабораторні роботи C#\Labs C# 2 kurs\Lab6 C#\Lab5\Lab5\SA2_Novikova.mdf;Integrated Security=True");
        }

    }
}
