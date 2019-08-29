using System;
using System.Collections.Generic;

namespace WikiBookGetApi.DataAccessLayer.Models
{
    public partial class Rating
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int RatingValue { get; set; }
    }
}
