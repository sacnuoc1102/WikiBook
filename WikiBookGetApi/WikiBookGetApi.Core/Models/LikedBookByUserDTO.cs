using System;
using System.Collections.Generic;
using System.Text;

namespace WikiBookGetApi.Core.Models
{
    public class LikedBookByUserDTO
    {
        public string UserIdentity { get; set; }
        public int BookId { get; set; }
    }
}
