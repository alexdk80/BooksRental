using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksRental.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }
        public BookGenre Genre { get; set; }
        [Required]
        [Display(Name="Book Genre")]
        public byte BookGenreId { get; set; }
    }
}