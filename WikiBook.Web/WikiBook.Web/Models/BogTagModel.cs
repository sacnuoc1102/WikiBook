using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiBook.Web.Models
{
    public partial class BookTagModel
    {
        public int GoodreadsBookId { get; set; }
        public int TagId { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
    }
}
