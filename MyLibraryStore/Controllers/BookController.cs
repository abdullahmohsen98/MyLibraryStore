using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibraryStore.Data;
using MyLibraryStore.Models;
using MyLibraryStore.Repository;

namespace MyLibraryStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly MyLibraryStoreContext _context ;

        public BookController(IBookRepository bookRepository, MyLibraryStoreContext context,
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;

            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("all-books")]
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        [Route("book-details/{id:int:min(1)}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);

            return View(data);
        }
        public async Task <ActionResult> Edit(int id)
        {
            var book = await _bookRepository.GetBookById(id);
           // var authorId = book.Author == null ? book.Author.id = 0 : book.Author.Id;

            var viewModel = new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Category = book.Category,
               // LanguageId=book.LanguageId,
                Language=book.Language,
                TotalPages=book.TotalPages,
                CoverPhoto=book.CoverPhoto,
                CoverImageUrl=book.CoverImageUrl,
                GalleryFiles=book.GalleryFiles,
                Gallery=book.Gallery,
               BookPdf=book.BookPdf,
               BookPdfUrl=book.BookPdfUrl
               
            };
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookModel viewModel)
        {
            //try
            //{

            //    string fileName = UploaFile(viewModel.File, viewModel.ImageUrl);

            //    var author = authorRepository.Find(viewModel.AuthorId);
            //    Book book = new Book
            //    {
            //        Id = viewModel.BookId,
            //        Title = viewModel.Title,
            //        Description = viewModel.Description,
            //        Author = author,
            //        ImageUrl = fileName
            //    };
            //    bookRepository.Update(viewModel.BookId, book);

            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            return View();
        }
        [Route("ConfirmDelete/{id:int:min(1)}", Name = "DeleteRoute")]

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var x = _context.Books.Find(id);

            return View(_context.Remove(x));
        }

        // POST: BookController/Delete/5
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id, IFormCollection collection)
        {
            try
            {
             
                _context.Remove(id);

                return RedirectToRoute(new { action = "Index", controller = "Home", area = "" });
            }
            catch
            {
                return View();
            }
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        [Authorize]
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImageUrl = await UploadImage(folder, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}