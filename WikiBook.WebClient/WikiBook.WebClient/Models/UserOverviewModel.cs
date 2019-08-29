using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiBook.WebClient.Models
{
    public class UserOverviewModel
    {
        public int UserId { get; set; }
        public List<BookModel> LikedBooks { get; set; }
    }
}
