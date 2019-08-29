using System;
using System.Collections.Generic;

namespace WikiBookGetApi.DataAccessLayer.Models
{
    public partial class BookTag
    {
        public int GoodreadsBookId { get; set; }
        public int TagId { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
    }
}
