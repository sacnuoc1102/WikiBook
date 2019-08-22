using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace TestApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.bookRepository.GetAllBooks();
        }

        public IEnumerable<Book> GetBook(SearchParameterModel searchParameter)
        {
            return this.bookRepository.GetBook(searchParameter);
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return this.bookRepository.GetBooksByAuthor(author);
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return this.bookRepository.GetBooksByTitle(title);
        }
    }
}
