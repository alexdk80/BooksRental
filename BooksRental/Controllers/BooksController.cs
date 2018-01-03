using BooksRental.Models;
//using BooksRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BooksRental.ViewModels;
using System.Data.Entity.Validation;

namespace BooksRental.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }

        public ActionResult NewBook()
        {
            var genres = _context.BookGenres.ToList();
            var viewModel = new BookFormViewModel
            {
                BookGenres = genres
            };
            return View("BookForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (book.Id==0)
            {
                _context.Books.Add(book);
            }
            //else
            //{
            //    var bookIsInDb = _context.Books.Single(b => b.Id == book.Id);
            //    bookIsInDb.Name = book.Name;
            //    bookIsInDb.Author = book.Author;
            //    bookIsInDb.NumberInStock = book.NumberInStock;
            //    bookIsInDb.ReleaseDate = book.ReleaseDate;
            //    bookIsInDb.DateAdded = book.DateAdded;
            //    bookIsInDb.BookGenreId = book.BookGenreId;
            //}
            
                _context.SaveChanges();           

            return RedirectToAction("Index","Books");
        }
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var viewModel = new BookFormViewModel()
            {
                Book = book,
                BookGenres = _context.BookGenres.ToList()
            };
            return View("BookForm", viewModel);
        }
        public ActionResult Random()
        {
            
            //var book = new Book() { Name = "Karlson", Author="Astrid Lingren" };
            var books = new List<Book>
            {
                new Book{ Id=1, Name="Shrek 1", Author = "Author 1"},
                new Book{Id= 2, Name="Shrek 2",Author = "Author 2"}
            };
            return View(books);
            //var viewModel = new RandomBookViewModel
            //{
            //    Books = books,
            //    //Customers = customers
            //};
            //return View(viewModel);
        }
        [Route("books/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {
            return Content(year + "/" + month);
        }
        //GET: Books
        public ActionResult Index()
        {
            var books = _context.Books.Include(b=>b.Genre).ToList();
            
            return View(books);
        }
        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b=>b.Genre).SingleOrDefault(b => b.Id == id);
            if (book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{ Id = 1, Name="Shrek 1", Author = "Author 1"},
                new Book{ Id = 2, Name="Shrek 2", Author = "Author 2"}
            };
        }
    }
}