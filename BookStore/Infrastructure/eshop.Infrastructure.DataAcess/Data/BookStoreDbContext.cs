using BookStore.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.DataAcess.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired()
                                                              .HasMaxLength(150);


            modelBuilder.Entity<Book>().HasOne(b => b.Genre)
                                       .WithMany(g => g.Books)
                                       .HasForeignKey(b => b.GenreId)
                                       .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Felsefe" },
                new Genre { Id = 2, Name = "Psikoloji" },
                new Genre { Id = 3, Name = "Edebiyat" });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Felix'in evide ne oldu?",
                    Author = "Cara Hunter",
                    Price = 210,
                    DiscountRate = 0.2m,
                    GenreId = 3,
                    Description = "Poloisiye-Kurgu"
                },
                new Book
                {
                    Id = 2,
                    Title = "Yılanlar Bahçesi",
                    Author = "N. Crawford",
                    Price = 205,
                    DiscountRate = 0.15m,
                    GenreId = 2,
                    Description = "Psikoloji....."
                },
                new Book
                {
                    Id = 3,
                    Title = "Felix'in evide ne oldu 2?",
                    Author = "Cara Hunter",
                    Price = 210,
                    DiscountRate = 0.2m,
                    GenreId = 3,
                    Description = "Poloisiye-Kurgu"
                },
                new Book
                {
                    Id = 4,
                    Title = "Sokrat'ın savunması",
                    Author = "Platon",
                    Price = 110,
                    DiscountRate = 0.15m,
                    GenreId = 1,
                    Description = "Süper klitap"
                },
                new Book
                {
                    Id = 5,
                    Title = "Felix'in evide ne oldu?",
                    Author = "Cara Hunter",
                    Price = 210,
                    DiscountRate = 0.2m,
                    GenreId = 1,
                    Description = "Poloisiye-Kurgu"
                },
                new Book
                {
                    Id = 6,
                    Title = "Felix'in evide ne oldu?",
                    Author = "Cara Hunter",
                    Price = 210,
                    DiscountRate = 0.2m,
                    GenreId = 3,
                    Description = "Poloisiye-Kurgu"
                },
                new Book
                {
                    Id = 7,
                    Title = "Felix'in evide ne oldu?",
                    Author = "Cara Hunter",
                    Price = 210,
                    DiscountRate = 0.2m,
                    GenreId = 2,
                    Description = "Poloisiye-Kurgu"
                }



                );


        }


    }
}
