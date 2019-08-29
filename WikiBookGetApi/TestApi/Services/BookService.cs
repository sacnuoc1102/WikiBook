using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Models;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace TestApi.Services
{
    public class BookService : IBookService
    { 
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            return mapper.Map<IEnumerable<BookDTO>>(this.bookRepository.GetAllBooks());
        }

        public IEnumerable<BookDTO> GetBook(SearchParameterModel searchParameter)
        {
            return mapper.Map<IEnumerable<BookDTO>>(this.bookRepository.GetBook(searchParameter));
        }

        public BookDTO GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetBooksByAuthor(string author)
        {
            return mapper.Map<IEnumerable<BookDTO>>(this.bookRepository.GetBooksByAuthor(author));
        }

        public IEnumerable<BookDTO> GetBooksByTitle(string title)
        {
            return mapper.Map<IEnumerable<BookDTO>>(this.bookRepository.GetBooksByTitle(title));
        }
    }
}
