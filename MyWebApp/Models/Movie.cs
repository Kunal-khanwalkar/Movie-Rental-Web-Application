using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreID { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Stock must be between 1 and 20")]
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}