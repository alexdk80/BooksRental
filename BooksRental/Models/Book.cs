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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1,20)]
        [Display(Name="Number in Stock")]
        public byte NumberInStock { get; set; }
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