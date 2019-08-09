using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Utilities;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.DataAccessLayer.Data;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private WikiBookDBContext context;


        public BookRepository(WikiBookDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.context.Books.ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return  context.Books.Where(t =>t.Authors.Contains(author)).ToList();
        }

    }
}
