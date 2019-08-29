using System;
using System.Collections.Generic;

namespace WikiBookGetApi.DataAccessLayer.Models
{
    public partial class ToRead
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
