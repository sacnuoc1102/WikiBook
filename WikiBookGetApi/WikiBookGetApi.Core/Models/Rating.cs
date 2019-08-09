using System;
using System.Collections.Generic;
using System.Text;

namespace WikiBookGetApi.Core.Models
{
    public partial class Rating
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int RatingPoint { get; set; }
    }
}
