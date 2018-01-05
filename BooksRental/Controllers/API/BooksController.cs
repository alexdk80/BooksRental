using AutoMapper;
using BooksRental.Dtos;
using BooksRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksRental.Controllers.API
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        // GET/api/books
        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Books.ToList().Select(Mapper.Map<Book,BookDto>);
        }
        // GET/api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book==null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Book,BookDto>(book));
        }
        // POST/api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();                
            }

            var book = Mapper.Map<BookDto,Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id),bookDto);
        }
        // PUT/api/books/1
        [HttpPut]
        public void UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(bookDto, bookInDb);
           
            _context.SaveChanges();
        }

        // DELETE/api/books/1
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
        }
    }
}
