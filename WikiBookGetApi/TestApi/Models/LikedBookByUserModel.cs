using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public class LikedBookByUserModel
    {
        public string UserIdentity { get; set; }
        public int BookId { get; set; }
    }
}
