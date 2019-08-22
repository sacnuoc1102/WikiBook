using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Utilities;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.DataAccessLayer.Data;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly WikiBookDBContext context;


        public BookRepository(WikiBookDBContext context)
        {
            this.context = context;
        }

        public BookRepository()
        {
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.context.Books;
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException(nameof(author));
            }

            return  context.Books.Where(t =>t.Authors.Contains(author)).ToList();
        }

        public Book GetBookById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return context.Books.Where(b => (b.BookId == id)).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            return context.Books.Where(t => t.Title.Contains(title)).ToList();
        }

        public IEnumerable<Book> GetBook(SearchParameterModel searchParameter)
        {
            IEnumerable<Book> tempResult= null;

            if (!string.IsNullOrWhiteSpace(searchParameter.Author))
            {
                tempResult = context.Books.Where(t => t.Authors.Contains(searchParameter.Author)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchParameter.Title))
            {
                tempResult = tempResult.Where(b => b.Title.Contains(searchParameter.Title)).ToList();
            }
            if (searchParameter.Id >0)
            {
                tempResult = tempResult.Where(b => b.BookId == searchParameter.Id).ToList();
            }

            return tempResult;
        }
    }
}
