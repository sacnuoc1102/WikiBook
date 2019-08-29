using System;
using System.Collections.Generic;
using System.Text;

namespace WikiBookGetApi.Core.Models
{
    public partial class BookTagDTO
    {
        public int GoodreadsBookId { get; set; }
        public int TagId { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
    }
}
