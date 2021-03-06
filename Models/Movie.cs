//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoviesProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =1)]
        public string title { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true )]
        public Nullable<System.DateTime> releaseDate { get; set; }

        [Required]
        [StringLength(40)]
        public string genre { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(5,1000)]
        public double price { get; set; }
        public string images { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
