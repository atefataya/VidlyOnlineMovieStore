﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The name field is required.")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage ="The Release Date is required.")]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Required(ErrorMessage ="The number in stock is required.")]
        [Range(1,20,ErrorMessage ="The field Number in Stock must be between 1 and 20.")]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }
     
        public Genre Genre { get; set; }
        [Required(ErrorMessage ="The Genre field is required.")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }


}