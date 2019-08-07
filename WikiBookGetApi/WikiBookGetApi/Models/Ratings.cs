using System;
using System.Collections.Generic;

namespace WikiBookGetApi.Models
{
    public partial class Ratings
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
    }
}
