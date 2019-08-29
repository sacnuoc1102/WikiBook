using System;
using System.Collections.Generic;

namespace WikiBookGetApi.DataAccessLayer.Models
{
    public partial class LikedBookByUser
    {
        public string UserIdentity { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
