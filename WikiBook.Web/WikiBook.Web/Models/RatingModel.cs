using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiBook.Web.Models
{
    public partial class RatingModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
    }
}
