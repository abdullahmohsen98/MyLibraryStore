using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Models
{
    public class myLibraryDbContext:DbContext
    {
        public myLibraryDbContext(DbContextOptions<myLibraryDbContext> options ):base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
