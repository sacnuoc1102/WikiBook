using System;
using System.Collections.Generic;

namespace WikiBookGetApi.Models
{
    public partial class BookTags
    {
        public int GoodreadsBookId { get; set; }
        public int TagId { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
    }
}
