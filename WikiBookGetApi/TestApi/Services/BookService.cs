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
            return this.bookRepository.GetBook(book => true);
        }

        public IEnumerable<BookDTO> GetBook(SearchParameterModel searchParameter)
        {
            IEnumerable<BookDTO> bookList = this.bookRepository.GetBook(book => true);

            if (!string.IsNullOrWhiteSpace(searchParameter.Author))
            {
                bookList = bookList.Where(t => t.Authors.Contains(searchParameter.Author));
            }
            if (!string.IsNullOrWhiteSpace(searchParameter.Title))
            {
                bookList = bookList.Where(b => b.Title.Contains(searchParameter.Title));
            }
            if (searchParameter.Id > 0)
            {
                bookList = bookList.Where(b => b.BookId == searchParameter.Id);
            }

            return bookList;
        }
    }
}
