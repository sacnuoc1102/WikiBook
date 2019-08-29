using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.Core.Models;

namespace WikiBookGetApi.Core.Services
{
    public interface IUserConnectionService
    {
        LikedBookByUserDTO LikeABook(string UserIdentity, int BookId);

        IEnumerable<BookDTO> GetUserLikedBooks(string UserIdentity);
    }
}
