using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Models
{
    public class MyLibraryStoreDbContext:DbContext
    {
        public MyLibraryStoreDbContext(DbContextOptions<MyLibraryStoreDbContext> options):base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
