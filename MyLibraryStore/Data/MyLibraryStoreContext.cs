using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibraryStore.Models;

namespace MyLibraryStore.Data
{
    public class MyLibraryStoreContext : IdentityDbContext<ApplicationUser>
    {
        public MyLibraryStoreContext(DbContextOptions<MyLibraryStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        public DbSet<BookGallery> BookGallery { get; set; }

        public DbSet<Language> Language { get; set; }
    }
}
