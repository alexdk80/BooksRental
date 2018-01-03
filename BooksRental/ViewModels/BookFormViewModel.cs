using BooksRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksRental.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<BookGenre> BookGenres { get; set; }
        public Book Book { get; set; }

    }
}