using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission11_Chu.Models;

public partial class BookstoreContext : DbContext
{
    // Represents the database context for the bookstore application
    public BookstoreContext()
    {
    }

    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    // Method called when configuring the context
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuring the context to use SQLite as the database provider with a connection string
        // Note: The connection string should ideally be stored outside of the source code for security reasons
        optionsBuilder.UseSqlite("Data Source=Bookstore.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_Books_BookID").IsUnique();

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
