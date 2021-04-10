using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Models.Repositories
{
    public class AuthorRepository : IMyLibraryStoreRepository<Author>
    {
        IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author {Id=1, FullName="Abdallah"},
                new Author {Id=2, FullName="Ali"},
                new Author {Id=3, FullName="Mostafa"}

            };
        }
        public void Add(Author entity)
        {
            //entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);

            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);

            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a=>a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);

            author.FullName = newAuthor.FullName;
        }
    }
}
