using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public partial class BookModel
    {
        public int BookId { get; set; }
        public int GoodreadsBookId { get; set; }
        public int BestBookId { get; set; }
        public int WorkId { get; set; }
        public int BooksCount { get; set; }
        public string Isbn { get; set; }
        public double? Isbn13 { get; set; }
        public string Authors { get; set; }
        public double? OriginalPublicationYear { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public string LanguageCode { get; set; }
        public double AverageRating { get; set; }
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
