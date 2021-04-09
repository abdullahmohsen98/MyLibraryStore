using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Models.Repositors
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books; //list of Book names books
        public BookRepository() //constructor that will initialize that list
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1, Title="C# Programming",
                    Description="no description" ,
                    Author = new Author{Id = 2 }
                },
                new Book
                {
                    Id=2,
                    Title="Java Programming",
                    Description="no description",
                    Author = new Author()
                },
                new Book
                {
                    Id=3,
                    Title="Python Programming",
                    Description="no description",
                    Author = new Author()
                }
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book newBook)
        {
            var book = Find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
        }
    }
}
