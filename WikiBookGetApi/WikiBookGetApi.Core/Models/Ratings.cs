using System;
using System.Collections.Generic;
using System.Text;

namespace WikiBookGetApi.Core.Models
{
    public partial class Ratings
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
    }
}
