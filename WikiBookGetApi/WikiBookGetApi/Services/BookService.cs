using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Repositories;
using Books = WikiBookGetApi.Core.Models.Books;

namespace WikiBookGetApi.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IEnumerable<Core.Models.Books> GetAllBooks()
        {
            return this.bookRepository.GetAllBooks();
        }

        public IEnumerable<Core.Models.Books> GetBooksByAuthor(string author)
        {
            return (IEnumerable<Books>) this.bookRepository.GetBooksByAuthor(author);
        }
    }
}
