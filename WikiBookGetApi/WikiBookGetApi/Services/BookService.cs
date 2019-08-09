using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Repositories;
using Book = WikiBookGetApi.Core.Models.Book;

namespace WikiBookGetApi.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.bookRepository.GetAllBooks();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return this.bookRepository.GetBooksByAuthor(author);
        }
    }
}
