using BooksRental.Models;
//using BooksRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksRental.Controllers
{
    public class BooksController : Controller
    {
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
            var books = GetBooks();
            
            return View(books);
        }
        public ActionResult Details(int id)
        {
            var book = GetBooks().FirstOrDefault(b => b.Id == id);
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