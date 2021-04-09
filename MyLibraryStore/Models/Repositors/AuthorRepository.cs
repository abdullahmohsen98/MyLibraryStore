using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Models.Repositors
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author
                {
                     Id=1, FullName="Mostafa Mahmoud"
                },                 
                new Author
                {
                     Id=2, FullName="Ali Emad"
                }, 
                new Author
                {
                     Id=3, FullName="Abdullah Abdelmohsen"
                }
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author); 
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id==id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
        }
    }
}
