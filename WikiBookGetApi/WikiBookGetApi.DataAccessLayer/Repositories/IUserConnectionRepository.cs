using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.DataAccessLayer.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public interface IUserConnectionRepository
    {
        Book LikeABook(string UserIdentity, int BookId);

        IEnumerable<Book> GetUserLikedBooks(string UserIdentity);
    }
}
