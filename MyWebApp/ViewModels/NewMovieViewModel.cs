using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MyWebApp.Models;

namespace MyWebApp.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }


        public int? ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreID { get; set; }
        

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Stock must be between 1 and 20")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }


        public String Title
        {
            get
            {
                return ID != 0 ? "Edit Movie" : "New Movie";
            }
        }


        public NewMovieViewModel()
        {
            ID = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreID = movie.GenreID;
        }
    }
}