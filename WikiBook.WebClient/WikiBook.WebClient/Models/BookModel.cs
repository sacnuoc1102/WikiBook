using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WikiBook.WebClient.Models
{
    public partial class BookModel
    {
        [Display(Name = "Book ID")]
        public int BookId { get; set; }

        public int GoodreadsBookId { get; set; }
        public int BestBookId { get; set; }
        public int WorkId { get; set; }
        [Display(Name = "Books Count")]
        public int BooksCount { get; set; }
        public string Isbn { get; set; }
        public double? Isbn13 { get; set; }
        public string Authors { get; set; }
        [Display(Name ="Original Publication Year")]
        public double? OriginalPublicationYear { get; set; }
        [Display(Name ="Original Title")]
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        [Display(Name ="Language Code")]
        public string LanguageCode { get; set; }
        [Display(Name ="Average Rating")]
        public double AverageRating { get; set; }
        [Display(Name = "Ratings Count")]
        public int RatingsCount { get; set; }
        public int WorkRatingsCount { get; set; }
        public int WorkTextReviewsCount { get; set; }
        public int Ratings1 { get; set; }
        public int Ratings2 { get; set; }
        public int Ratings3 { get; set; }
        public int Ratings4 { get; set; }
        public int Ratings5 { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
    }
}
