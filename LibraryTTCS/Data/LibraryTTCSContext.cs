using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Libraby.Models;
using LibraryTTCS.Models;

namespace LibraryTTCS.Data
{
    public class LibraryTTCSContext : DbContext
    {
        public LibraryTTCSContext (DbContextOptions<LibraryTTCSContext> options)
            : base(options)
        {
        }

        public DbSet<Libraby.Models.Author> Author { get; set; } = default!;
        public DbSet<Libraby.Models.Genre> Genre { get; set; } = default!;
        public DbSet<Libraby.Models.Book> Book { get; set; } = default!;
        public DbSet<LibraryTTCS.Models.User> User { get; set; } = default!;
        public DbSet<LibraryTTCS.Models.Borrowing> Borrowing { get; set; } = default!;
        public DbSet<LibraryTTCS.Models.BorrowedBook> BorrowedBook { get; set; } = default!;
    }
}
