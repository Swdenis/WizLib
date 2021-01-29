using System;
using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess.Data.FluentConfig;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<Category> Categories { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<FluentBook> FluentBook { get; set; }

        public DbSet<FluentAuthor> FluentAuthor { get; set; }

        public DbSet<FluentPublisher> FluentPublisher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            //Category
            modelBuilder.Entity<Category>().ToTable("tbl_category");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("Category");


            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailsConfig());

        }
    }
}
