using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiBookGetApi.DataAccessLayer.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly WikiBookDBContext context;

        public UserConnectionRepository(WikiBookDBContext context)
        {
            this.context = context;
        }

        public UserConnectionRepository()
        {
        }

        public IEnumerable<Book> GetUserLikedBooks(string UserIdentity)
        {
            if (string.IsNullOrWhiteSpace(UserIdentity))
            {
                throw new ArgumentNullException(nameof(UserIdentity));
            }
            return context.LikedBookByUser.Where(b => b.UserIdentity == UserIdentity).Select(c=>c.Book);
        }

        public Book LikeABook(string UserIdentity, int BookId)
        {
            if (string.IsNullOrWhiteSpace(UserIdentity) || BookId <= 0)
            {
                throw new ArgumentNullException();
            }
            var temp = new LikedBookByUser() { UserIdentity = UserIdentity, BookId = BookId };
            this.context.LikedBookByUser.Add(temp);
            this.context.SaveChanges();
            return null;
        }


    }
}
