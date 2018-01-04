using BooksRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksRental.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<BookGenre> BookGenres { get; set; }
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
               
        [Required]
        [Display(Name = "Book Genre")]
        public byte? BookGenreId { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }
        public BookFormViewModel()
        {
            Id = 0;
        }
        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            BookGenreId = book.BookGenreId;
        }

    }
}